using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ActionViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void IsReadOnly__IsBound()
        {
            Assert.IsTrue(BoundView<ActionView, ActionPresenter>().WasBoundTo(x => x.IsReadOnly));
        }

        [Test]
        public void DisplayName__IsBound()
        {
            Assert.IsTrue(BoundView<ActionView, ActionPresenter>().WasBoundTo(x => x.DisplayName));
        }
    }
}