using Caliburn.PresentationFramework.Screens;

namespace Relax.Presenters.Interfaces
{
    internal interface IShellPresenter : IScreenCollection
    {
        IWorkspacePresenter Workspace { get; }
    }
}