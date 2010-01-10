using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class DoLaterViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BoundView<DoLaterView, DoLaterPresenter>().AssertNoErrors();
        }

        [Test]
        public void ActionTitle__IsBound()
        {
            BoundView<DoLaterView, DoLaterPresenter>().AssertWasBound(x => x.Projects);
        }
    }
}