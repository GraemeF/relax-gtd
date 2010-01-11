using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class InputViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BoundView<InputView, InputPresenter>().AssertNoErrors();
        }

        [Test]
        public void ActionTitle__IsBound()
        {
            BoundView<InputView, InputPresenter>().AssertWasBound(x => x.Action.Title);
        }
    }
}