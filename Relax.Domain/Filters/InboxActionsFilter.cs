using Caliburn.Core.Metadata;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Filters
{
    [PerRequest(typeof (IInboxActionsFilter))]
    public class InboxActionsFilter : ActionsFilterBase, IInboxActionsFilter
    {
        public InboxActionsFilter(IWorkspace workspace)
            : base(workspace, x => ((IAction) x).ActionState == State.Inbox)
        {
        }
    }
}