using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    /// <summary>
    /// Presents the UI to put an action in a list for doing later.
    /// </summary>
    public interface IDoLaterPresenter : IPresenter
    {
        IContextsPresenter Contexts { get; }
        IActionDetailsPresenter Details { get; }
        IProjectsPresenter Projects { get; }
    }
}