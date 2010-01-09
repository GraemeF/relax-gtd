using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ContextsViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Presenters__IsBound()
        {
            Assert.IsTrue(BoundView<ContextsView, ContextsPresenter>().WasBoundTo(x => x.Presenters));
        }
    }
}