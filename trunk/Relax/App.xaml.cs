using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
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

        private void Compose(DirectoryCatalog catalog)
        {
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        protected override Assembly[] SelectAssemblies()
        {
            using (var catalog = new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                Compose(catalog);
                return FindAssemblies(catalog).ToArray();
            }
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

            return Container.GetInstance<IShellPresenter>();
        }
    }
}