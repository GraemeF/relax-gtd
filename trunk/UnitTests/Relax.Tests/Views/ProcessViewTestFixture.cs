using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ProcessViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ProcessView, ProcessPresenter>().AssertNoErrors();
        }

        [Test]
        public void Inbox__IsBound()
        {
            Assert.IsTrue(BoundView<ProcessView, ProcessPresenter>().WasBoundTo(x => x.Inbox));
        }

        [Test]
        public void DoLater__IsBound()
        {
            Assert.IsTrue(BoundView<ProcessView, ProcessPresenter>().WasBoundTo(x => x.DoLater));
        }

        [Test]
        public void DoNow__IsBound()
        {
            Assert.IsTrue(BoundView<ProcessView, ProcessPresenter>().WasBoundTo(x => x.DoNow));
        }
    }
}