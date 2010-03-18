using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IProcessActionPresenter))]
    public class ProcessActionPresenter : MultiPresenter, IProcessActionPresenter
    {
        private readonly IAction _action;

        public ProcessActionPresenter(IAction action, IDoNowPresenter doNow, IDoLaterPresenter doLater)
        {
            _action = action;
            DoNow = doNow;
            DoLater = doLater;
        }

        #region IProcessActionPresenter Members

        public IDoNowPresenter DoNow { get; private set; }
        public IDoLaterPresenter DoLater { get; private set; }

        public IAction Model
        {
            get { return _action; }
        }

        #endregion
    }
}