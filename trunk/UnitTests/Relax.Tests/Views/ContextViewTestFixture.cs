using Caliburn.Testability;
using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ContextViewTestFixture
    {
        [Test]
        public void IsReadOnly__IsBound()
        {
            BindingValidator<ContextPresenter> validator = Validator.For<ContextView, ContextPresenter>();
            ValidationResult<ContextPresenter> result = validator.Validate();

            Assert.IsTrue(result.WasBoundTo(x => x.IsReadOnly));
        }
    }
}