using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ActionViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ActionView, ActionPresenter>().AssertNoErrors();
        }

        [Fact]
        public void IsReadOnly__IsBound()
        {
            Assert.True(BoundView<ActionView, ActionPresenter>().WasBoundTo(x => x.IsReadOnly));
        }

        [Fact]
        public void DisplayName__IsBound()
        {
            Assert.True(BoundView<ActionView, ActionPresenter>().WasBoundTo(x => x.DisplayName));
        }
    }
}