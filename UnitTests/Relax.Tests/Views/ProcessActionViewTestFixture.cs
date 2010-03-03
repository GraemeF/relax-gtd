using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ProcessActionViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ProcessActionView, ProcessActionPresenter>().AssertNoErrors();
        }

        [Fact]
        public void DoNow__IsBound()
        {
            Assert.True(BoundView<ProcessActionView, ProcessActionPresenter>().WasBoundTo(x => x.DoNow));
        }

        [Fact]
        public void DoLater__IsBound()
        {
            Assert.True(BoundView<ProcessActionView, ProcessActionPresenter>().WasBoundTo(x => x.DoLater));
        }
    }
}