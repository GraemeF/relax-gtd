using Relax.Presenters;
using Relax.Tests.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class MakeProjectViewTestFixture : ViewTestFixtureBase<MakeProjectView, MakeProjectPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void Projects__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.Projects));
        }
    }
}