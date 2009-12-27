using Caliburn.Testability;
using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ContextsViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Presenters__IsBound()
        {
            BindingValidator<ContextsPresenter> validator = Validator.For<ContextsView, ContextsPresenter>();
            ValidationResult<ContextsPresenter> result = validator.Validate();

            Assert.IsTrue(result.WasBoundTo(x => x.Presenters));
        }
    }
}