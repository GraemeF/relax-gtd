using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ContextsViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ContextsView, ContextsPresenter>().AssertNoErrors();
        }

        [Test]
        public void Presenters__IsBound()
        {
            Assert.IsTrue(BoundView<ContextsView, ContextsPresenter>().WasBoundTo(x => x.Presenters));
        }
    }
}