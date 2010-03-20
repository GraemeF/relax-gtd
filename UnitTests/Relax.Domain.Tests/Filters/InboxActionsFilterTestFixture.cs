using System.ComponentModel;
using System.Linq;
using Moq;
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

            bool eventRaised = false;
            test.Actions.CollectionChanged +=
                (o, args) =>
                    {
                        Assert.Same(inboxAction, args.NewItems.Cast<IAction>().Single());
                        eventRaised = true;
                    };

            workspace.Actions.Add(inboxAction);

            Assert.Contains(inboxAction, test.Actions);
            Assert.Equal(1, test.Actions.Count);
            Assert.True(eventRaised);
        }

        [Fact]
        public void Actions_WhenAnActionIsMovedOutOfTheInbox_RaisesCollectionChanged()
        {
            Mock<IAction> stubAction = AnAction.In(State.Inbox).Mock();
            IWorkspace workspace = AWorkspace.With(stubAction.Object).Build();

            var test = new InboxActionsFilter(workspace);

            bool eventRaised = false;
            test.Actions.CollectionChanged += (o, args) => eventRaised = true;

            stubAction.Setup(x => x.ActionState).Returns(State.Committed);
            stubAction.Raise(x => x.PropertyChanged += null, new PropertyChangedEventArgs("ActionState"));

            Assert.DoesNotContain(stubAction.Object, test.Actions);
            Assert.Empty(test.Actions);
            Assert.True(eventRaised);
        }
    }
}