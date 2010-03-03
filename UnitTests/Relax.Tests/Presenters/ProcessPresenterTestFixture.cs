using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ProcessPresenterTestFixture
    {
        private readonly Mock<IDoLaterPresenter> _stubDoLater = new Mock<IDoLaterPresenter>();
        private readonly Mock<IDoNowPresenter> _stubDoNow = new Mock<IDoNowPresenter>();
        private readonly Mock<IInboxActionsPresenter> _stubInbox = new Mock<IInboxActionsPresenter>();

        private ProcessPresenter BuildDefaultProcessPresenter()
        {
            return new ProcessPresenter(_stubDoLater.Object,
                                        _stubInbox.Object,
                                        _stubDoNow.Object);
        }

        [Fact]
        public void Inbox__ReturnsInboxPresenter()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            Assert.Same(_stubInbox.Object, test.Inbox);
        }
    }
}