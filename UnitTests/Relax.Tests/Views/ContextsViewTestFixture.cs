using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ContextsViewTestFixture : ViewTestFixtureBase<ContextsView, ContextsPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void Presenters__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.Presenters));
        }
    }
}