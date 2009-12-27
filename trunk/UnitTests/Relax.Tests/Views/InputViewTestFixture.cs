using Caliburn.Testability;
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
            BindingValidator<InputPresenter> validator = Validator.For<InputView, InputPresenter>();
            ValidationResult<InputPresenter> result = validator.Validate();

            result.AssertNoErrors();
        }

        [Test]
        public void ActionTitle__IsBound()
        {
            BindingValidator<InputPresenter> validator = Validator.For<InputView, InputPresenter>();
            ValidationResult<InputPresenter> result = validator.Validate();

            result.AssertWasBound(x => x.Action.Title);
        }
    }
}