using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ProcessPresenterTestFixture : TestDataBuilder
    {
        private readonly Mock<ISingleInboxActionSelector> _fakeInbox = new Mock<ISingleInboxActionSelector>();
        private readonly Mock<ICachingDictionary<IAction, IProcessActionPresenter>> _fakePresenterProvider = new Mock<ICachingDictionary<IAction, IProcessActionPresenter>>();

        private ProcessPresenter BuildDefaultProcessPresenter()
        {
            _fakePresenterProvider.
                Setup(x => x.GetOrCreate(It.IsAny<IAction>())).
                Returns(() => new Mock<IProcessActionPresenter>().Object);
            return new ProcessPresenter(_fakeInbox.Object, _fakePresenterProvider.Object);
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