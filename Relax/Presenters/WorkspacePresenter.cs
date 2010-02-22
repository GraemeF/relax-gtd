using System.Collections.Specialized;
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

            _inboxActionsFilter.Actions.CollectionChanged += OnInboxActionsChanged;
        }

        #region IWorkspacePresenter Members

        public string ProcessButtonText
        {
            get
            {
                int count = _inboxActionsFilter.Actions.Count;
                return count == 0 ? "Process" : string.Format("Process ({0})", count);
            }
        }

        public bool IsProcessingEnabled
        {
            get { return _inboxActionsFilter.Actions.Any(); }
        }

        #endregion

        private void OnInboxActionsChanged(object o, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            NotifyOfPropertyChange("IsProcessingEnabled");
            NotifyOfPropertyChange("ProcessButtonText");
        }

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