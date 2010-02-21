using System.Linq;
using Caliburn.Core.Metadata;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Filters
{
    [PerRequest(typeof (IProjectsFilter))]
    public class ProjectsFilter : ActionsFilterBase, IProjectsFilter
    {
        public ProjectsFilter(IWorkspace workspace)
            : base(
                workspace,
                action =>
                ((IAction) action).BlockingActions.Any() &&
                !workspace.Actions.Any(x => x.BlockingActions.Contains((IAction) action)))
        {
        }
    }
}