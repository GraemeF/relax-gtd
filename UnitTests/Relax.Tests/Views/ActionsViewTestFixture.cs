using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ActionsViewTestFixture : ViewTestFixtureBase<ActionsView, ActionsPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void Screens__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.Screens));
        }
    }
}