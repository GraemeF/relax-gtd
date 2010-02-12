using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ActionsViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ActionsView, ActionsPresenter>().AssertNoErrors();
        }

        [Fact]
        public void Presenters__IsBound()
        {
            Assert.True(BoundView<ActionsView, ActionsPresenter>().WasBoundTo(x => x.Presenters));
        }
    }
}