using Caliburn.Testability;
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
            BindingValidator<ShellPresenter> validator = Validator.For<ShellView, ShellPresenter>();
            ValidationResult<ShellPresenter> result = validator.Validate();

            result.AssertNoErrors();
        }
    }
}