using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class CollectViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<CollectView, CollectPresenter>().AssertNoErrors();
        }

        [Fact]
        public void InboxActions__IsBound()
        {
            Assert.True(BoundView<CollectView, CollectPresenter>().WasBoundTo(x => x.InboxActions));
        }

        [Fact]
        public void Input__IsBound()
        {
            Assert.True(BoundView<CollectView, CollectPresenter>().WasBoundTo(x => x.Input));
        }
    }
}