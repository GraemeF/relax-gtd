using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class DoNowViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<DoNowView, DoNowPresenter>().AssertNoErrors();
        }
    }
}