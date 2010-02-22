using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ContextViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ContextView, ContextPresenter>().AssertNoErrors();
        }

        [Fact]
        public void IsReadOnly__IsBound()
        {
            Assert.True(BoundView<ContextView, ContextPresenter>().WasBoundTo(x => x.IsReadOnly));
        }

        [Fact]
        public void DisplayName__IsBound()
        {
            Assert.True(BoundView<ContextView, ContextPresenter>().WasBoundTo(x => x.DisplayName));
        }
    }
}