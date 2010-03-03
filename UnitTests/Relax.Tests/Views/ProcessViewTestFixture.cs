using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ProcessViewTestFixture : ViewTestFixtureBase<ProcessView, ProcessPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void Inbox__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.Inbox));
        }
    }
}