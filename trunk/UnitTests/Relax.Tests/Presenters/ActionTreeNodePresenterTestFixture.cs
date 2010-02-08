using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ActionTreeNodePresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void BlockingActions__ReturnsBlockingActions()
        {
            var stubBlockingActions = new Mock<IBlockingActionsPresenter>();

            var test = new ActionTreeNodePresenter(AnAction.BlockedBy(AnAction).Build(),
                                                   stubBlockingActions.Object);

            Assert.Same(stubBlockingActions.Object, test.BlockingActions);
        }
    }
}