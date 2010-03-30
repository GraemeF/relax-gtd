using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ProcessPresenterTestFixture : TestDataBuilder
    {
        private readonly Mock<ISingleInboxActionSelector> _fakeInbox = new Mock<ISingleInboxActionSelector>();

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

        [Fact]
        public void CurrentPresenter_WhenInboxHasACurrentItem_IsAPresenter()
        {
            _fakeInbox.Setup(x => x.SelectedItem).Returns(AnAction.Build());
            ProcessPresenter test = BuildDefaultProcessPresenter();

            test.Initialize();

            Assert.NotNull(test.CurrentPresenter);
        }

        [Fact]
        public void CurrentPresenter_WhenInboxHasNoCurrentPresenter_IsNull()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            test.Initialize();

            Assert.Null(test.CurrentPresenter);
        }
    }
}