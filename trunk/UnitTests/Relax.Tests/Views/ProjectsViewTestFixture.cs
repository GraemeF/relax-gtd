using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ProjectsViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Presenters__IsBound()
        {
            Assert.IsTrue(BoundView<ProjectsView, ProjectsPresenter>().WasBoundTo(x => x.Presenters));
        }
    }
}