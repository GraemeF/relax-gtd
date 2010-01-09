using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ActionsViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Presenters__IsBound()
        {
            Assert.IsTrue(BoundView<ActionsView, ActionsPresenter>().WasBoundTo(x => x.Presenters));
        }
    }
}