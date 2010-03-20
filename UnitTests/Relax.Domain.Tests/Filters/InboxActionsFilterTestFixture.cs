using System.Linq;
using Relax.Domain.Filters;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Domain.Tests.Filters
{
    public class InboxActionsFilterTestFixture : TestDataBuilder
    {
        [Fact]
        public void Actions_WhenWorkspaceHasMixedActions_ContainsOnlyInboxActions()
        {
            IAction inboxAction = AnAction.In(State.Inbox).Build();

            WorkspaceBuilder stubWorkspace =
                AWorkspace
                    .With(AnAction.In(State.Committed))
                    .With(inboxAction)
                    .With(AnAction.In(State.Hold))
                    .With(AnAction.In(State.SomedayMaybe));

            var test = new InboxActionsFilter(stubWorkspace.Build());

            Assert.Contains(inboxAction, test.Actions);
            Assert.Equal(1, test.Actions.Count);
        }

        [Fact]
        public void Actions_WhenFirstInboxActionIsAddedToWorkspace_RaisesCollectionChanged()
        {
            IWorkspace workspace = AWorkspace.Build();
            IAction inboxAction = AnAction.In(State.Inbox).Build();

            var test = new InboxActionsFilter(workspace);

            test.Actions.CollectionChanged +=
                (o, args) => args.NewItems.Cast<IAction>();

            workspace.Actions.Add(inboxAction);

            Assert.Contains(inboxAction, test.Actions);
            Assert.Equal(1, test.Actions.Count);
        }
    }
}