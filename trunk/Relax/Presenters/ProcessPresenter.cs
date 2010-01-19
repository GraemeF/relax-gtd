using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IProcessPresenter))]
    public class ProcessPresenter : MultiPresenter, IProcessPresenter
    {
        public ProcessPresenter(IDoLaterPresenter doLater, IInboxActionsPresenter inbox, IDoNowPresenter doNow)
        {
            Inbox = inbox;
            DoNow = doNow;
            DoLater = doLater;
        }

        #region IProcessPresenter Members

        public IInboxActionsPresenter Inbox { get; private set; }
        public IDoNowPresenter DoNow { get; private set; }
        public IDoLaterPresenter DoLater { get; private set; }

        #endregion
    }
}