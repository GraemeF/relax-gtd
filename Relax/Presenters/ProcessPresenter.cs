using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IProcessPresenter))]
    public class ProcessPresenter : MultiPresenter, IProcessPresenter
    {
        public ProcessPresenter(IActionQueuePresenter actionQueue, IDoLaterPresenter doLater,
                                IInboxActionsPresenter inbox, IDoNowPresenter doNow)
        {
            ActionQueue = actionQueue;
            Inbox = inbox;
            DoNow = doNow;
            DoLater = doLater;
        }

        #region IProcessPresenter Members

        public IActionQueuePresenter ActionQueue { get; private set; }
        public IInboxActionsPresenter Inbox { get; private set; }
        public IDoNowPresenter DoNow { get; private set; }
        public IDoLaterPresenter DoLater { get; private set; }

        #endregion
    }
}