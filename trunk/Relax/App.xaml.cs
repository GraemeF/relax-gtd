using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Caliburn.Autofac;
using Caliburn.PresentationFramework.ApplicationModel;
using Microsoft.Practices.ServiceLocation;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax
{
    public partial class App : CaliburnApplication
    {
        private ComposablePartCatalog _catalog;

        [Import]
        public IRelaxModule MessageSender { get; set; }

        protected override IServiceLocator CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.Register<ShellPresenter>();

            IContainer container = builder.Build();
            var adapter = new AutofacAdapter(container);

            return adapter;
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

        protected override object CreateRootModel()
        {
            var binder = (DefaultBinder) Container.GetInstance<IBinder>();
            binder.EnableMessageConventions();
            binder.EnableBindingConventions();

            var shell = Container.GetInstance<IShellPresenter>();

            var container = new CompositionContainer(_catalog);
            container.ComposeParts(this, shell);

            return shell;
        }
    }
}