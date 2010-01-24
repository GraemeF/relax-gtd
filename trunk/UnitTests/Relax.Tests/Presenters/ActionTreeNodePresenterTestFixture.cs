using MbUnit.Framework;
using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ActionTreeNodePresenterTestFixture : TestDataBuilder
    {
        [Test]
        public void BlockingActions__ReturnsBlockingActions()
        {
            var stubBlockingActions = new Mock<IBlockingActionsPresenter>();

            var test = new ActionTreeNodePresenter(AnAction.BlockedBy(AnAction).Build(),
                                                   stubBlockingActions.Object);

            Assert.AreSame(stubBlockingActions.Object, test.BlockingActions);
        }
    }
}