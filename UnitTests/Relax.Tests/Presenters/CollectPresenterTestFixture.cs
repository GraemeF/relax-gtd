using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class CollectPresenterTestFixture
    {
        [Fact]
        public void Input__ReturnsInputPresenter()
        {
            var stubInput = new Mock<IInputPresenter>();
            var test = new CollectPresenter(stubInput.Object, new Mock<IInboxActionsPresenter>().Object);

            Assert.Same(stubInput.Object, test.Input);
        }

        [Fact]
        public void InboxActions__ReturnsInputActions()
        {
            var stubInboxActions = new Mock<IInboxActionsPresenter>();
            var test = new CollectPresenter(new Mock<IInputPresenter>().Object, stubInboxActions.Object);

            Assert.Same(stubInboxActions.Object, test.InboxActions);
        }
    }
}