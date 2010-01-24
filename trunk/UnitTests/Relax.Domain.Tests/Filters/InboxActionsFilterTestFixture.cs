using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using Relax.Domain.Filters;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;

namespace Relax.Domain.Tests.Filters
{
    [TestFixture]
    public class InboxActionsFilterTestFixture : TestDataBuilder
    {
        [Test]
        public void InboxActions_WhenWorkspaceHasMixedActions_ContainsOnlyInboxActions()
        {
            IAction inboxAction = AnAction.In(State.Inbox).Build();

            WorkspaceBuilder stubWorkspace =
                AWorkspace
                    .With(AnAction.In(State.Committed))
                    .With(inboxAction)
                    .With(AnAction.In(State.Hold))
                    .With(AnAction.In(State.SomedayMaybe));

            var test = new InboxActionsFilter(stubWorkspace.Build());

            Assert.AreElementsSame(new[] {inboxAction}, test.InboxActions.Cast<IAction>());
        }

        [Test]
        public void InboxActions_WhenFirstInboxActionIsAddedToWorkspace_RaisesCollectionChanged()
        {
            IWorkspace workspace = AWorkspace.Build();
            IAction inboxAction = AnAction.In(State.Inbox).Build();
            IEnumerable<IAction> newItems = null;

            var test = new InboxActionsFilter(workspace);

            test.InboxActions.CollectionChanged +=
                (o, args) => newItems = args.NewItems.Cast<IAction>();

            workspace.Actions.Add(inboxAction);

            Assert.AreElementsSame(new[] {inboxAction}, newItems);
        }
    }
}