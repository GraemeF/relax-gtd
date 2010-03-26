using Moq;
using Relax.Commands;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Commands
{
    public class DoLaterCommandTestFixture : TestDataBuilder
    {
        private readonly Mock<IAction> _fakeAction = AnAction.Mock();
        private readonly DoLaterCommand _test = new DoLaterCommand();

        [Fact]
        public void CanExecute_WhenContextIsNull_IsFalse()
        {
            Assert.False(_test.CanExecute(_fakeAction.Object));
        }

        [Fact]
        public void CanExecute_WhenContextSet_IsTrue()
        {
            _test.Context = AContext.Build();

            Assert.True(_test.CanExecute(_fakeAction.Object));
        }

        [Fact]
        public void Execute_GivenContext_SetsContextOnAction()
        {
            IGtdContext context = AContext.Build();
            _test.Context = context;

            _test.Execute(_fakeAction.Object);

            _fakeAction.VerifySet(x => x.Context = context);
        }

        [Fact]
        public void Execute_GivenProject_AddsActionToProjectBlockingActions()
        {
            Mock<IAction> mockProject = AnAction.Mock();
            _test.Context = AContext.Build();
            _test.Project = mockProject.Object;

            _test.Execute(_fakeAction.Object);

            mockProject.Verify(x => x.AddBlockingAction(_fakeAction.Object));
        }

        [Fact]
        public void Execute_GivenContext_SetsActionStateToCommitted()
        {
            _test.Context = AContext.Build();

            _test.Execute(_fakeAction.Object);

            _fakeAction.VerifySet(x => x.ActionState = State.Committed);
        }
    }
}