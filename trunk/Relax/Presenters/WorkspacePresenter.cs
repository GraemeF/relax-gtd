using System.Linq;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Domain.Filters.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IWorkspacePresenter))]
    public class WorkspacePresenter : Navigator, IWorkspacePresenter
    {
        private readonly ICollectPresenter _collectPresenter;
        private readonly IInboxActionsFilter _inboxActionsFilter;
        private readonly IProcessPresenter _processPresenter;

        public WorkspacePresenter(IInboxActionsFilter inboxActionsFilter,
                                  ICollectPresenter collectPresenter, IProcessPresenter processPresenter)
        {
            _inboxActionsFilter = inboxActionsFilter;
            _collectPresenter = collectPresenter;
            _processPresenter = processPresenter;

            _inboxActionsFilter.Actions.CollectionChanged +=
                (sender, args) => NotifyOfPropertyChange("IsProcessingEnabled");
        }

        #region IWorkspacePresenter Members

        public bool IsProcessingEnabled
        {
            get { return _inboxActionsFilter.Actions.Any(); }
        }

        #endregion

        public void GoCollect()
        {
            Open(_collectPresenter, success => { });
        }

        public void GoProcess()
        {
            Open(_processPresenter, success => { });
        }
    }
}