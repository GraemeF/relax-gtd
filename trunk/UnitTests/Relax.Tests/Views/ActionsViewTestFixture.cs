using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ActionsViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ActionsView, ActionsPresenter>().AssertNoErrors();
        }

        [Test]
        public void Presenters__IsBound()
        {
            Assert.IsTrue(BoundView<ActionsView, ActionsPresenter>().WasBoundTo(x => x.Presenters));
        }
    }
}