using System.Windows;
using Caliburn.Testability;

namespace Relax.Tests.Views
{
    public class ViewTestFixtureBase
    {
        static ViewTestFixtureBase()
        {
            var app = new App();
            app.InitializeComponent();
        }

        protected static ValidationResult<TPresenter> BoundView<TView, TPresenter>()
            where TView : FrameworkElement
        {
            BindingValidator<TPresenter> validator = Validator.For<TView, TPresenter>();
            return validator.Validate();
        }
    }
}