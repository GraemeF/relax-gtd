using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class DoLaterViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<DoLaterView, DoLaterPresenter>().AssertNoErrors();
        }

        [Fact]
        public void ActionTitle__IsBound()
        {
            BoundView<DoLaterView, DoLaterPresenter>().AssertWasBound(x => x.Projects);
        }
    }
}