using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.ViewModels;
using Caliburn.Unity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NDesk.Options;
using Relax.FileBackingStore.Services;
using Relax.FileBackingStore.Services.Interfaces;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax
{
    [NoCoverage]
    public partial class App : CaliburnApplication
    {
        private UnityContainer _container;
        private bool _newWorkspace;
        private string _workspacePath;

        protected override void OnStartup(StartupEventArgs e)
        {
            ParseStartupArguments(e);
            base.OnStartup(e);
        }

        private void ParseStartupArguments(StartupEventArgs startupEventArgs)
        {
            var p = new OptionSet
                        {
                            {"w|workspace=", "the {PATH} of the workspace.", v => _workspacePath = v},
                            {"n|new", "create a new workspace.", v => _newWorkspace = v != null},
                        };

            try
            {
                p.Parse(startupEventArgs.Args);
            }
            catch (OptionException e)
            {
                Console.WriteLine(e.Message);
                Current.Shutdown();
            }
        }

        protected override IServiceLocator CreateContainer()
        {
            _container = new UnityContainer();
            return new UnityAdapter(_container);
        }

        protected override Assembly[] SelectAssemblies()
        {
            var directoryCatalog = new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            return FindAssemblies(directoryCatalog).ToArray();
        }

        private static IEnumerable<Assembly> FindAssemblies(DirectoryCatalog catalog)
        {
            return catalog.LoadedFiles.
                Select(loadedFile => GetAssembly(loadedFile)).
                Where(assembly => assembly != null).
                Where(assembly => assembly.FullName.StartsWith("Relax")).
                Concat(new[] {Assembly.GetEntryAssembly()});
        }

        private static Assembly GetAssembly(string file)
        {
            try
            {
                return Assembly.LoadFile(file);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (FileLoadException)
            {
                return null;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (BadImageFormatException)
            {
                return null;
            }
        }

        private void ConfigureStartupFileLocator()
        {
            if (_workspacePath == null && !_newWorkspace)
                RegisterType<IStartupFileLocator, DefaultWorkspaceFileLocator>();
            else
                RegisterInstance<IStartupFileLocator>(
                    new CustomPathStartupFileLocator(_workspacePath ??
                                                     DefaultWorkspaceFileLocator.DefaultBackingStorePath)
                        {LoadOnStartup = !_newWorkspace});
        }

        protected override object CreateRootModel()
        {
            ConfigureStartupFileLocator();

            ConfigureContainer();

            var binder = (DefaultViewModelBinder) Container.GetInstance<IViewModelBinder>();
            binder.ApplyConventionsByDefault = true;

            var shell = Container.GetInstance<IShellPresenter>();

            return shell;
        }

        private void RegisterType<TInterface, TAs>() where TAs : TInterface
        {
            _container.RegisterType<TInterface, TAs>();
        }

        private void RegisterInstance<TInterface>(TInterface instance)
        {
            _container.RegisterInstance(instance);
        }

        private void ConfigureContainer()
        {
            var backingStore = _container.Resolve<IBackingStore>();
            backingStore.Initialize();

            RegisterInstance(backingStore.Workspace);
            RegisterInstance<Func<IGtdContext, IGtdContextPresenter>>(GtdContextPresenterFactory);
            RegisterInstance<Func<IGtdContext>>(() => _container.Resolve<IGtdContext>());
            RegisterInstance<Func<IAction, IActionPresenter>>(ActionPresenterFactory);
            RegisterInstance<Func<IAction, IProcessActionPresenter>>(ProcessActionPresenterFactory);
            RegisterInstance<Func<IAction>>(() => _container.Resolve<IAction>());
            RegisterInstance<Func<IAction, IActionTreeNodePresenter>>(ActionTreeNodePresenterFactory);
            RegisterInstance<Func<IAction, IEnumerable<IActionProcessorPresenter>>>(ActionProcessorPresentersFactory);

            RegisterType<ICachingDictionary<IAction, IProcessActionPresenter>,
                FactoryCachingDictionary<IAction, IProcessActionPresenter>>();
        }

        private IActionTreeNodePresenter ActionTreeNodePresenterFactory(IAction arg)
        {
            IUnityContainer childContainer = _container.CreateChildContainer();
            childContainer.RegisterInstance(arg);
            return childContainer.Resolve<IActionTreeNodePresenter>();
        }

        private IActionPresenter ActionPresenterFactory(IAction arg)
        {
            IUnityContainer childContainer = _container.CreateChildContainer();
            childContainer.RegisterInstance(arg);
            return childContainer.Resolve<IActionPresenter>();
        }

        private IGtdContextPresenter GtdContextPresenterFactory(IGtdContext arg)
        {
            IUnityContainer childContainer = _container.CreateChildContainer();
            childContainer.RegisterInstance(arg);
            return childContainer.Resolve<IGtdContextPresenter>();
        }

        private IProcessActionPresenter ProcessActionPresenterFactory(IAction action)
        {
            IUnityContainer childContainer = _container.CreateChildContainer();
            childContainer.RegisterInstance(action);
            return childContainer.Resolve<IProcessActionPresenter>();
        }

        private IEnumerable<IActionProcessorPresenter> ActionProcessorPresentersFactory(IAction action)
        {
            IUnityContainer childContainer = _container.CreateChildContainer();
            childContainer.RegisterInstance(action);
            return childContainer.ResolveAll<IActionProcessorPresenter>();
        }
    }
}