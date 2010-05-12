using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IShellPresenter))]
    public class ShellPresenter : ScreenConductor<IScreen>, IShellPresenter
    {
        private readonly IBackingStore _backingStore;

        public ShellPresenter(IBackingStore backingStore, IWorkspacePresenter workspacePresenter)
        {
            _backingStore = backingStore;

            Screens.Add(workspacePresenter);
            Workspace = workspacePresenter;
        }

        #region IShellPresenter Members

        public IWorkspacePresenter Workspace { get; private set; }

        #endregion

        protected override void OnInitialize()
        {
            _backingStore.Initialize();
            base.OnInitialize();
        }

        public void Save()
        {
            _backingStore.Save();
        }
    }
}