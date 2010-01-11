using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class CollectViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void InboxActions__IsBound()
        {
            Assert.IsTrue(BoundView<CollectView, CollectPresenter>().WasBoundTo(x => x.InboxActions));
        }

        [Test]
        public void Input__IsBound()
        {
            Assert.IsTrue(BoundView<CollectView, CollectPresenter>().WasBoundTo(x => x.Input));
        }
    }
}