using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ProcessActionViewTestFixture : ViewTestFixtureBase<ProcessActionView, ProcessActionPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void DoNow__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.DoNow));
        }

        [Fact]
        public void DoLater__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.DoLater));
        }
    }
}