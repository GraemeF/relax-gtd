using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IShellPresenter))]
    public class ShellPresenter : MultiPresenter, IShellPresenter
    {
        private readonly IBackingStore _backingStore;

        public ShellPresenter(IBackingStore backingStore, IWorkspacePresenter workspacePresenter)
        {
            _backingStore = backingStore;

            Presenters.Add(workspacePresenter);
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