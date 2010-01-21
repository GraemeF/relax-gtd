using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class DoNowViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BoundView<DoNowView, DoNowPresenter>().AssertNoErrors();
        }
    }
}