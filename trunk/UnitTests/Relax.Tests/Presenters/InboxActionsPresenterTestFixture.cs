using System.Windows.Data;
using MbUnit.Framework;
using Moq;
using Relax.Domain.Filters.Interfaces;
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
        public void Constructor_WhenThereIsAnInboxAction_ActivatesInboxActionPresenter()
        {
            IAction inboxAction = AnAction.In(State.Inbox).Build();

            var mockActionPresenter = new Mock<IActionPresenter>();

            var stubFilter = new Mock<IInboxActionsFilter>();
            stubFilter.Setup(x => x.InboxActions).Returns(CollectionViewSource.GetDefaultView(new[] {inboxAction}));

            new InboxActionsPresenter(stubFilter.Object, delegate(IAction action)
                                                             {
                                                                 Assert.AreSame(inboxAction,
                                                                                action);

                                                                 return
                                                                     mockActionPresenter.
                                                                         Object;
                                                             });

            mockActionPresenter.Verify(x => x.Activate(), Times.Once());
        }

        [Test]
        public void Presenters_WhenThereIsAnInboxAction_ContainsInboxActionPresenter()
        {
            IAction inboxAction = AnAction.In(State.Inbox).Build();

            var stubActionPresenter = new Mock<IActionPresenter>();

            var stubFilter = new Mock<IInboxActionsFilter>();
            stubFilter.Setup(x => x.InboxActions).Returns(CollectionViewSource.GetDefaultView(new[] {inboxAction}));

            var test = new InboxActionsPresenter(stubFilter.Object, action => stubActionPresenter.Object);

            Assert.AreElementsEqual(new[] {stubActionPresenter.Object}, test.Presenters);
        }
    }
}