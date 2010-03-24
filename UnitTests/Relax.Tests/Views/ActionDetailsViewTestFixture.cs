using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ActionDetailsViewTestFixture : ViewTestFixtureBase<ActionDetailsView, ActionDetailsPresenter>
    {
        [Fact]
        public void BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }
    }
}