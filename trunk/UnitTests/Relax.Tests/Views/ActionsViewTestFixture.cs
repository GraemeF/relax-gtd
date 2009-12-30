using Caliburn.Testability;
using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class ActionsViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void Presenters__IsBound()
        {
            BindingValidator<ActionsPresenter> validator = Validator.For<ActionsView, ActionsPresenter>();
            ValidationResult<ActionsPresenter> result = validator.Validate();

            Assert.IsTrue(result.WasBoundTo(x => x.Presenters));
        }
    }
}