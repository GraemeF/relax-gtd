using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ProcessPresenterTestFixture
    {
        private readonly Mock<IInboxActionsPresenter> _stubInbox = new Mock<IInboxActionsPresenter>();

        private ProcessPresenter BuildDefaultProcessPresenter()
        {
            return new ProcessPresenter(_stubInbox.Object, x => new Mock<IProcessActionPresenter>().Object);
        }

        [Fact]
        public void Inbox__ReturnsInboxPresenter()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            Assert.Same(_stubInbox.Object, test.Inbox);
        }

        [Fact]
        public void CurrentPresenter_WhenInboxHasACurrentPresenter_IsAPresenter()
        {
            _stubInbox.Setup(x => x.CurrentPresenter).Returns(new Mock<IActionPresenter>().Object);
            ProcessPresenter test = BuildDefaultProcessPresenter();

            Assert.NotNull(test.CurrentPresenter);
        }

        [Fact]
        public void CurrentPresenter_WhenInboxHasNoCurrentPresenter_IsNull()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            Assert.Null(test.CurrentPresenter);
        }
    }
}