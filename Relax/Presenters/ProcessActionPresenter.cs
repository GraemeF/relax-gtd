using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IProcessActionPresenter))]
    public class ProcessActionPresenter : MultiPresenter, IProcessActionPresenter
    {
        private readonly IAction _action;
        private PropertyObserver<IAction> _propertyObserver;

        public ProcessActionPresenter(IAction action, IDoNowPresenter doNow, IDoLaterPresenter doLater)
        {
            _action = action;
            DoNow = doNow;
            DoLater = doLater;

            _propertyObserver = new PropertyObserver<IAction>(Model).
                RegisterHandler(x => x.Title,
                                y => NotifyOfPropertyChange(() => DisplayName));
        }

        #region IProcessActionPresenter Members

        public override string DisplayName
        {
            get { return Model.Title; }
            set { Model.Title = value; }
        }

        public IDoNowPresenter DoNow { get; private set; }
        public IDoLaterPresenter DoLater { get; private set; }

        public IAction Model
        {
            get { return _action; }
        }

        #endregion
    }
}