using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class CollectViewTestFixture : ViewTestFixtureBase<CollectView, CollectPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void InboxActions__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.InboxActions));
        }

        [Fact]
        public void Input__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.Input));
        }
    }
}