using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ProcessViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ProcessView, ProcessPresenter>().AssertNoErrors();
        }

        [Fact]
        public void Inbox__IsBound()
        {
            Assert.True(BoundView<ProcessView, ProcessPresenter>().WasBoundTo(x => x.Inbox));
        }
    }
}