using System;
using Autofac;
using Autofac.Builder;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IShellPresenter))]
    public class ShellPresenter : MultiPresenter, IShellPresenter
    {
        private readonly IBackingStore _backingStore;
        private readonly IContainer _container;

        public ShellPresenter(IContainer container, IBackingStore backingStore)
        {
            _container = container;
            _backingStore = backingStore;
        }

        public IContextsPresenter Contexts { get; private set; }

        #region IShellPresenter Members

        public override void Initialize()
        {
            var builder = new ContainerBuilder();
            _backingStore.Initialize();

            builder.Register(_backingStore.Workspace);
            builder.RegisterGeneratedFactory<Func<IGtdContext, IGtdContextPresenter>>(new TypedService(typeof (IGtdContextPresenter)));
            builder.RegisterGeneratedFactory<Func<IGtdContext>>(new TypedService(typeof (IGtdContext)));

            builder.Build(_container);

            Contexts = _container.Resolve<IContextsPresenter>();
        }

        #endregion

        public void Save()
        {
            _backingStore.Save();
        }
    }
}