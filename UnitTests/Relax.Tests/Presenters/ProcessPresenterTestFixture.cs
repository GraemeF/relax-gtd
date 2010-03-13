﻿using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ProcessPresenterTestFixture
    {
        private readonly Mock<IInboxActionsPresenter> _fakeInbox = new Mock<IInboxActionsPresenter>();

        private ProcessPresenter BuildDefaultProcessPresenter()
        {
            return new ProcessPresenter(_fakeInbox.Object, x => new Mock<IProcessActionPresenter>().Object);
        }

        [Fact]
        public void Inbox__ReturnsInboxPresenter()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            Assert.Same(_fakeInbox.Object, test.Inbox);
        }

        [Fact]
        public void Initialize__InitializesInboxPresenter()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            test.Initialize();

            _fakeInbox.Verify(x => x.Initialize());
        }
    }
}