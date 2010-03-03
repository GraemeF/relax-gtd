using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ShellViewTestFixture : ViewTestFixtureBase<ShellView, ShellPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }
    }
}