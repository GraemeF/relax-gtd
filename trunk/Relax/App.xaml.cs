using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Autofac.Builder;
using Caliburn.Autofac;
using Caliburn.Core;
using Caliburn.PresentationFramework.ApplicationModel;
using Microsoft.Practices.ServiceLocation;
using NDesk.Options;
using Relax.FileBackingStore.Services;
using Relax.FileBackingStore.Services.Interfaces;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters.Interfaces;
using IContainer = Autofac.IContainer;

namespace Relax
{
    [NoCoverage]
    public partial class App : CaliburnApplication
    {
        private ComposablePartCatalog _catalog;
        private IContainer _container;
        private bool _newWorkspace;
        private string _workspacePath;

        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IRelaxModule> Modules { get; private set; }

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
            _container = new ContainerBuilder().Build();
            return new AutofacAdapter(_container);
        }

        protected override Assembly[] SelectAssemblies()
        {
            var directoryCatalog = new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()), directoryCatalog);

            return FindAssemblies(directoryCatalog).ToArray();
        }

        private IEnumerable<Assembly> FindAssemblies(DirectoryCatalog catalog)
        {
            yield return Assembly.GetEntryAssembly();

            foreach (Assembly assembly in
                catalog.LoadedFiles.Select(loadedFile => GetAssembly(loadedFile)).Where(assembly => assembly != null))
            {
                yield return assembly;
            }
        }

        private Assembly GetAssembly(string file)
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

        protected override void BeforeStart(CoreConfiguration core)
        {
            var builder = new ContainerBuilder();

            Modules = new ObservableCollection<IRelaxModule>();
            using (var compositionContainer = new CompositionContainer(_catalog))
                compositionContainer.ComposeParts(this);

            foreach (IRelaxModule module in Modules)
                builder.RegisterModule(module);

            builder.Build(_container);
        }

        private void ConfigureStartupFileLocator()
        {
            ContainerBuilder builder= new ContainerBuilder();

            if (_workspacePath == null && !_newWorkspace)
                builder.Register<DefaultWorkspaceFileLocator>().As<IStartupFileLocator>();
            else
                builder.Register<IStartupFileLocator>(
                    new CustomPathStartupFileLocator(_workspacePath ??
                                                     DefaultWorkspaceFileLocator.DefaultBackingStorePath)
                        {LoadOnStartup = !_newWorkspace});

            builder.Build(_container);
        }

        protected override object CreateRootModel()
        {
            ConfigureStartupFileLocator();

            var binder = (DefaultBinder)Container.GetInstance<IBinder>();
            binder.EnableMessageConventions();
            binder.EnableBindingConventions();

            var shell = Container.GetInstance<IShellPresenter>();

            return shell;
        }
    }
}