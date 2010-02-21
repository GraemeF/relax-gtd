using Relax.Domain.Filters.Interfaces;

namespace Relax.TestDataBuilders
{
    public class TestDataBuilder
    {
        protected static ActionBuilder AnAction
        {
            get { return new ActionBuilder(); }
        }

        protected static WorkspaceBuilder AWorkspace
        {
            get { return new WorkspaceBuilder(); }
        }

        protected static ActionsFilterBuilder<IInboxActionsFilter> AnInboxActionsFilter
        {
            get { return new ActionsFilterBuilder<IInboxActionsFilter>(); }
        }

        protected static ActionsFilterBuilder<IProjectsFilter> AProjectsFilter
        {
            get { return new ActionsFilterBuilder<IProjectsFilter>(); }
        }
    }
}