using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class InboxActionsPresenterTestFixture
    {
        private static ActionBuilder AnAction
        {
            get { return new ActionBuilder(); }
        }

        private static WorkspaceBuilder AWorkspace
        {
            get { return new WorkspaceBuilder(); }
        }

        [Test]
        public void Constructor_GivenMixedActions_ActivatesOnlyInboxActions()
        {
            Mock<IAction> inboxAction = AnAction.With(State.Inbox).Build();

            Mock<IWorkspace> stubWorkspace =
                AWorkspace
                    .WithAction(AnAction.With(State.Committed))
                    .WithAction(inboxAction.Object)
                    .WithAction(AnAction.With(State.Hold))
                    .WithAction(AnAction.With(State.SomedayMaybe)).Build();

            var mockActionPresenter = new Mock<IActionPresenter>();

            new InboxActionsPresenter(stubWorkspace.Object, delegate(IAction action)
                                                                {
                                                                    Assert.AreSame(inboxAction.Object,
                                                                                   action);

                                                                    return
                                                                        mockActionPresenter.
                                                                            Object;
                                                                });

            mockActionPresenter.Verify(x => x.Activate(), Times.Once());
        }

        [Test]
        public void Presenters_GivenMixedActions_ContainsOnlyInboxActions()
        {
            Mock<IAction> inboxAction = AnAction.With(State.Inbox).Build();

            Mock<IWorkspace> stubWorkspace =
                AWorkspace
                    .WithAction(AnAction.With(State.Committed))
                    .WithAction(inboxAction.Object)
                    .WithAction(AnAction.With(State.Hold))
                    .WithAction(AnAction.With(State.SomedayMaybe)).Build();

            var stubActionPresenter = new Mock<IActionPresenter>();

            var test = new InboxActionsPresenter(stubWorkspace.Object, action => stubActionPresenter.Object);

            Assert.AreElementsEqual(new[] {stubActionPresenter.Object}, test.Presenters);
        }
    }
}