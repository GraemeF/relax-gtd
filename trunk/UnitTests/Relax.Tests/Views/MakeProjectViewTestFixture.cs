using MbUnit.Framework;
using Relax.Tests.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class MakeProjectViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Projects__IsBound()
        {
            Assert.IsTrue(BoundView<MakeProjectView, MakeProjectPresenter>().WasBoundTo(x => x.Projects));
        }
    }
}