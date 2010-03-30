using System;
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
        private readonly Func<IAction, IProcessActionPresenter> _processActionPresenterFactory;
        private PropertyObserver<ISingleInboxActionSelector> _currentActionObserver;

        public ProcessPresenter(ISingleInboxActionSelector inbox,
                                Func<IAction, IProcessActionPresenter> processActionPresenterFactory)
        {
            _processActionPresenterFactory = processActionPresenterFactory;
            Inbox = inbox;

            _currentActionObserver = new PropertyObserver<ISingleInboxActionSelector>(Inbox).
                RegisterHandler(x => x.SelectedItem,
                                y => OpenProcessActionPresenter());
        }

        #region IProcessPresenter Members

        public ISingleInboxActionSelector Inbox { get; private set; }

        #endregion

        private void OpenProcessActionPresenter()
        {
            IAction action = Inbox.SelectedItem;

            if (action != null)
                this.Open(_processActionPresenterFactory(action));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Inbox.Initialize();

            OpenProcessActionPresenter();
        }
    }
}