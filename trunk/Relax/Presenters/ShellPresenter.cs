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
    public class ShellPresenter : Navigator, IShellPresenter
    {
        private readonly IBackingStore _backingStore;
        private readonly IContainer _container;

        public ShellPresenter(IContainer container, IBackingStore backingStore)
        {
            _container = container;
            _backingStore = backingStore;
        }

        #region IShellPresenter Members

        public override void Initialize()
        {
            var builder = new ContainerBuilder();
            _backingStore.Initialize();

            builder.Register(_backingStore.Workspace);
            builder.RegisterGeneratedFactory<Func<IGtdContext, IGtdContextPresenter>>(
                new TypedService(typeof (IGtdContextPresenter)));
            builder.RegisterGeneratedFactory<Func<IGtdContext>>(new TypedService(typeof (IGtdContext)));
            builder.RegisterGeneratedFactory<Func<IInputPresenter>>(new TypedService(typeof (IGtdContext)));
            builder.RegisterGeneratedFactory<Func<IAction, IActionPresenter>>(new TypedService(typeof (IActionPresenter)));
            builder.RegisterGeneratedFactory<Func<IAction>>(new TypedService(typeof (IAction)));
            builder.RegisterGeneratedFactory<Func<IAction, IActionTreeNodePresenter>>(
                new TypedService(typeof (IActionTreeNodePresenter)));

            builder.Build(_container);

            Workspace = _container.Resolve<IWorkspacePresenter>();
        }

        public IWorkspacePresenter Workspace { get; private set; }

        #endregion

        public void Save()
        {
            _backingStore.Save();
        }
    }
}