using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac.Builder;
using Caliburn.Autofac;
using Caliburn.Core;
using Caliburn.PresentationFramework.ApplicationModel;
using Microsoft.Practices.ServiceLocation;
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

        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IRelaxModule> Modules { get; private set; }

        protected override IServiceLocator CreateContainer()
        {
            var builder = new ContainerBuilder();
            _container = builder.Build();
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

            foreach (string loadedFile in catalog.LoadedFiles)
            {
                Assembly assembly = GetAssembly(loadedFile);
                if (assembly != null)
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

        protected override object CreateRootModel()
        {
            var binder = (DefaultBinder) Container.GetInstance<IBinder>();
            binder.EnableMessageConventions();
            binder.EnableBindingConventions();

            var shell = Container.GetInstance<IShellPresenter>();

            return shell;
        }
    }
}