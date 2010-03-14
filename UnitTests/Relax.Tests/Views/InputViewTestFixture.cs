using Relax.Presenters;
using Relax.Views;
using Xunit;

namespace Relax.Tests.Views
{
    public class InputViewTestFixture : ViewTestFixtureBase<InputView, InputPresenter>
    {
        [Fact]
        public void Constructor__BindsWithoutError()
        {
            BoundView().AssertNoErrors();
        }

        [Fact]
        public void ActionTitle__IsBound()
        {
            BoundView().AssertWasBound(x => x.Action.Title);
        }
    }
}