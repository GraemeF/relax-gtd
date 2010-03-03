using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IProcessActionPresenter))]
    public class ProcessActionPresenter : MultiPresenter, IProcessActionPresenter
    {
        public ProcessActionPresenter(IDoNowPresenter doNow, IDoLaterPresenter doLater)
        {
            DoNow = doNow;
            DoLater = doLater;
        }

        #region IProcessPresenter Members

        public IDoNowPresenter DoNow { get; private set; }
        public IDoLaterPresenter DoLater { get; private set; }

        #endregion
    }
}