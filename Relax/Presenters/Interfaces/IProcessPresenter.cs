using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface IProcessPresenter : IPresenter
    {
        IInboxActionsPresenter Inbox { get; }
        IDoNowPresenter DoNow { get; }
        IDoLaterPresenter DoLater { get; }
        IActionQueuePresenter ActionQueue { get; }
    }
}