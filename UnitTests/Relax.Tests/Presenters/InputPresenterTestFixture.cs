using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class InputPresenterTestFixture : TestDataBuilder
    {
        private readonly Mock<IWorkspace> _fakeWorkspace = AWorkspace.Mock();
        private Mock<IAction> _fakeAction = AnAction.Mock();

        private InputPresenter BuildDefaultInputViewPresenter()
        {
            return new InputPresenter(_fakeWorkspace.Object, () => _fakeAction.Object);
        }

        [Fact]
        public void Action__ReturnsAction()
        {
            InputPresenter test = BuildDefaultInputViewPresenter();

            Assert.Same(_fakeAction.Object, test.Action);
        }

        [Fact]
        public void Add_WhenTitleIsNotEmpty_AddsItemToInbox()
        {
            InputPresenter test = BuildDefaultInputViewPresenter();

            test.Add();

            _fakeWorkspace.Verify(x => x.Add(_fakeAction.Object));
        }

        [Fact]
        public void CanAdd_WhenTitleIsEmpty_IsFalse()
        {
            _fakeAction = AnAction.Called(string.Empty).Mock();

            InputPresenter test = BuildDefaultInputViewPresenter();

            Assert.False(test.CanAdd());
        }

        [Fact]
        public void CanAdd_WhenTitleIsNotEmpty_IsTrue()
        {
            _fakeAction = AnAction.Called("This action has a title").Mock();

            InputPresenter test = BuildDefaultInputViewPresenter();

            Assert.True(test.CanAdd());
        }

        [Fact]
        public void Constructor__SetsActionStateToInbox()
        {
            InputPresenter test = BuildDefaultInputViewPresenter();

            _fakeAction.VerifySet(x => x.ActionState = State.Inbox);
        }
    }
}