using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface IDoLaterPresenter : IPresenter
    {
        IContextsPresenter Contexts { get; }
        IActionDetailsPresenter Details { get; }
        IProjectsPresenter Projects { get; }
    }
}