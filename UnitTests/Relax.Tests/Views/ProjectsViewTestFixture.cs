using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class ProjectsViewTestFixture : ViewTestFixtureBase<ProjectsView, OptionalProjectSelector>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void Presenters__IsBound()
        {
            Assert.True(BoundView().WasBoundTo(x => x.Screens));
        }
    }
}