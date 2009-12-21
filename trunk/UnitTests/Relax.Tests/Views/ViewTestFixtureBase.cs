namespace Relax.Tests.Views
{
    public class ViewTestFixtureBase
    {
        static ViewTestFixtureBase()
        {
            var app = new App();
            app.InitializeComponent();
        }
    }
}