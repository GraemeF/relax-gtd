using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IProcessPresenter))]
    public class ProcessPresenter : MultiPresenterManager, IProcessPresenter
    {
        private readonly ICachingDictionary<IAction, IProcessActionPresenter> _processActionCachingDictionary;
        private PropertyObserver<ISingleInboxActionSelector> _currentActionObserver;

        public ProcessPresenter(ISingleInboxActionSelector inbox,
                                ICachingDictionary<IAction, IProcessActionPresenter> processActionCachingDictionary)
        {
            _processActionCachingDictionary = processActionCachingDictionary;
            Inbox = inbox;

            _currentActionObserver = new PropertyObserver<ISingleInboxActionSelector>(Inbox).
                RegisterHandler(x => x.SelectedItem,
                                y => OpenPresenterForSelectedInboxAction());
        }

        #region IProcessPresenter Members

        public ISingleInboxActionSelector Inbox { get; private set; }

        #endregion

        private void OpenPresenterForSelectedInboxAction()
        {
            IAction action = Inbox.SelectedItem;

            if (action != null)
                this.Open(_processActionCachingDictionary.GetOrCreate(action));
            else
                this.ShutdownCurrent();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Inbox.Initialize();

            OpenPresenterForSelectedInboxAction();
        }
    }
}