using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ActionDetailsViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void BindsWithoutError()
        {
            BoundView<ActionDetailsView, ActionDetailsPresenter>().AssertNoErrors();
        }
    }
}