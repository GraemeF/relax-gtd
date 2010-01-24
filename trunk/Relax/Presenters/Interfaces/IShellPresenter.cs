using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    internal interface IShellPresenter : IPresenterHost
    {
        IWorkspacePresenter Workspace { get; }
    }
}