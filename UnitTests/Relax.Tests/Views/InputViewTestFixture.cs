using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class InputViewTestFixture : ViewTestFixtureBase
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView<InputView, InputPresenter>().AssertNoErrors();
        }

        [Fact]
        public void ActionTitle__IsBound()
        {
            BoundView<InputView, InputPresenter>().AssertWasBound(x => x.Action.Title);
        }
    }
}