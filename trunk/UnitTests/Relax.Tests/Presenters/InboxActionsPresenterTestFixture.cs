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
    public class InboxActionsPresenterTestFixture : TestDataBuilder
    {
        [Test]
        public void Constructor_GivenMixedActions_ActivatesOnlyInboxActions()
        {
            Mock<IAction> inboxAction = AnAction.InState(State.Inbox).Build();

            Mock<IWorkspace> stubWorkspace =
                AWorkspace
                    .With(AnAction.InState(State.Committed))
                    .With(inboxAction.Object)
                    .With(AnAction.InState(State.Hold))
                    .With(AnAction.InState(State.SomedayMaybe)).Build();

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
            Mock<IAction> inboxAction = AnAction.InState(State.Inbox).Build();

            Mock<IWorkspace> stubWorkspace =
                AWorkspace
                    .With(AnAction.InState(State.Committed))
                    .With(inboxAction.Object)
                    .With(AnAction.InState(State.Hold))
                    .With(AnAction.InState(State.SomedayMaybe)).Build();

            var stubActionPresenter = new Mock<IActionPresenter>();

            var test = new InboxActionsPresenter(stubWorkspace.Object, action => stubActionPresenter.Object);

            Assert.AreElementsEqual(new[] {stubActionPresenter.Object}, test.Presenters);
        }
    }
}