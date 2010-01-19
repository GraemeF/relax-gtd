using MbUnit.Framework;
using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class CollectPresenterTestFixture
    {
        [Test]
        public void Input__ReturnsInputPresenter()
        {
            var stubInput = new Mock<IInputPresenter>();
            var test = new CollectPresenter(stubInput.Object, new Mock<IInboxActionsPresenter>().Object);

            Assert.AreSame(stubInput.Object, test.Input);
        }

        [Test]
        public void InboxActions__ReturnsInputActions()
        {
            var stubInboxActions = new Mock<IInboxActionsPresenter>();
            var test = new CollectPresenter(new Mock<IInputPresenter>().Object, stubInboxActions.Object);

            Assert.AreSame(stubInboxActions.Object, test.InboxActions);
        }
    }
}