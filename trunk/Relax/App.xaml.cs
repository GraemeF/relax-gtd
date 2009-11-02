using Autofac;
using Autofac.Builder;
using Caliburn.Autofac;
using Caliburn.PresentationFramework.ApplicationModel;
using Microsoft.Practices.ServiceLocation;
using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax
{
    public partial class App : CaliburnApplication
    {
        protected override IServiceLocator CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.Register<ShellPresenter>();

            IContainer container = builder.Build();
            var adapter = new AutofacAdapter(container);

            return adapter;
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