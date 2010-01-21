using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ShellViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BoundView<ShellView, ShellPresenter>().AssertNoErrors();
        }
    }
}