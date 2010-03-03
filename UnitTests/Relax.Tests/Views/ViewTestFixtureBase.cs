using System.Windows;
using Caliburn.Testability;

namespace Relax.Tests.Views
{
    public class AppInitializer
    {
        static AppInitializer()
        {
            var app = new App();
            app.InitializeComponent();
        }
    }

    public class ViewTestFixtureBase<TView, TPresenter> : AppInitializer
        where TView : FrameworkElement
    {
        protected static ValidationResult<TPresenter> BoundView()
        {
            BindingValidator<TPresenter> validator = Validator.For<TView, TPresenter>();
            return validator.Validate();
        }
    }
}