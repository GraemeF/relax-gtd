using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ContextViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ContextView, ContextPresenter>().AssertNoErrors();
        }

        [Test]
        public void IsReadOnly__IsBound()
        {
            Assert.IsTrue(BoundView<ContextView, ContextPresenter>().WasBoundTo(x => x.IsReadOnly));
        }

        [Test]
        public void DisplayName__IsBound()
        {
            Assert.IsTrue(BoundView<ContextView, ContextPresenter>().WasBoundTo(x => x.DisplayName));
        }
    }
}