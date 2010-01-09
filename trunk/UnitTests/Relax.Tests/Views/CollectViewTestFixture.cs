using Caliburn.Testability;
using MbUnit.Framework;
using Relax.Presenters;
using Relax.Views;

namespace Relax.Tests.Views
{
    [TestFixture]
    public class CollectViewTestFixture : ViewTestFixtureBase
    {
        [Test]
        public void InboxActions__IsBound()
        {
            BindingValidator<CollectPresenter> validator = Validator.For<CollectView, CollectPresenter>();
            ValidationResult<CollectPresenter> result = validator.Validate();

            Assert.IsTrue(result.WasBoundTo(x => x.InboxActions));
        }

        [Test]
        public void Input__IsBound()
        {
            BindingValidator<CollectPresenter> validator = Validator.For<CollectView, CollectPresenter>();
            ValidationResult<CollectPresenter> result = validator.Validate();

            Assert.IsTrue(result.WasBoundTo(x => x.Input));
        }
    }
}