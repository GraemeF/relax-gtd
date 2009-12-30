using Caliburn.Testability;
using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ActionViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void IsReadOnly__IsBound()
        {
            BindingValidator<ActionPresenter> validator = Validator.For<ActionView, ActionPresenter>();
            ValidationResult<ActionPresenter> result = validator.Validate();

            Assert.IsTrue(result.WasBoundTo(x => x.IsReadOnly));
        }

        [Test]
        public void DisplayName__IsBound()
        {
            BindingValidator<ActionPresenter> validator = Validator.For<ActionView, ActionPresenter>();
            ValidationResult<ActionPresenter> result = validator.Validate();

            Assert.IsTrue(result.WasBoundTo(x => x.DisplayName));
        }
    }
}