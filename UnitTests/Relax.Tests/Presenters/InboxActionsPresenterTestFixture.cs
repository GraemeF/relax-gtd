﻿using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class InboxActionsPresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void Presenters_WhenThereIsAnInboxAction_ContainsInboxActionPresenter()
        {
            IAction inboxAction = AnAction.In(State.Inbox).Build();

            var stubActionPresenter = new Mock<IActionPresenter>();

            var test = new InboxActionsPresenter(AnInboxActionsFilter.Providing(inboxAction).Build(),
                                                 action => stubActionPresenter.Object);
            test.Initialize();

            Assert.Contains(stubActionPresenter.Object, test.Presenters);
        }
    }
}