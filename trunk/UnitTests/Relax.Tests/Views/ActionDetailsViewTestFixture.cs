using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ActionDetailsViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void BindsWithoutError()
        {
            BoundView<ActionDetailsView, ActionDetailsPresenter>().AssertNoErrors();
        }
    }
}