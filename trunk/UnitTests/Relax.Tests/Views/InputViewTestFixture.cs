using Caliburn.Testability;
using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class InputViewTestFixture
    {
        [Test]
        public void Constructor__BindsWithoutError()
        {
            BindingValidator<InputViewPresenter> validator = Validator.For<InputView, InputViewPresenter>();
            ValidationResult<InputViewPresenter> result = validator.Validate();

            result.AssertNoErrors();
        }

        [Test]
        public void ActionTitle__IsBound()
        {
            BindingValidator<InputViewPresenter> validator = Validator.For<InputView, InputViewPresenter>();
            ValidationResult<InputViewPresenter> result = validator.Validate();

            result.AssertWasBound(x => x.Action.Title);
        }
    }
}