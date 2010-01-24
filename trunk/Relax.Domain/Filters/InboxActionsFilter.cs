using System.ComponentModel;
using System.Windows.Data;
using Caliburn.Core.Metadata;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Filters
{
    [PerRequest(typeof (IInboxActionsFilter))]
    public class InboxActionsFilter : IInboxActionsFilter
    {
        public InboxActionsFilter(IWorkspace workspace)
        {
            InboxActions = CollectionViewSource.GetDefaultView(workspace.Actions);
            InboxActions.Filter = action => ((IAction) action).ActionState == State.Inbox;
        }

        #region IInboxActionsFilter Members

        public ICollectionView InboxActions { get; private set; }

        #endregion
    }
}