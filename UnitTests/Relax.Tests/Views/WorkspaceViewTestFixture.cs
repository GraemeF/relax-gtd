using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class WorkspaceViewTestFixture : ViewTestFixtureBase<WorkspaceView, WorkspacePresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }
    }
}