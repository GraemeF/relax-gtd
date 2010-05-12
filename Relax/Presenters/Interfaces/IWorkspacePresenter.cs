using Caliburn.PresentationFramework.Screens;

namespace Relax.Presenters
{
    public interface IWorkspacePresenter : INavigator
    {
        bool IsProcessingEnabled { get; }
        string ProcessButtonText { get; }
    }
}