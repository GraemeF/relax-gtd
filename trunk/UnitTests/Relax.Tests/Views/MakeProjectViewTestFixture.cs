using Relax.Tests.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class MakeProjectViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<MakeProjectView, MakeProjectPresenter>().AssertNoErrors();
        }

        [Fact]
        public void Projects__IsBound()
        {
            Assert.True(BoundView<MakeProjectView, MakeProjectPresenter>().WasBoundTo(x => x.Projects));
        }
    }
}