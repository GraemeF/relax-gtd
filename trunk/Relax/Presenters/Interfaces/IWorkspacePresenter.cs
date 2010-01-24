using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters
{
    public interface IWorkspacePresenter : INavigator
    {
        bool IsProcessingEnabled { get; }
        string ProcessButtonText { get; }
    }
}