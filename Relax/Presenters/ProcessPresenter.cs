using System;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IProcessPresenter))]
    public class ProcessPresenter : MultiPresenter, IProcessPresenter
    {
        private readonly Func<IAction, IProcessActionPresenter> _processActionPresenterFactory;

        public ProcessPresenter(IInboxActionsPresenter inbox,
                                Func<IAction, IProcessActionPresenter> processActionPresenterFactory)
        {
            _processActionPresenterFactory = processActionPresenterFactory;
            Inbox = inbox;
        }

        #region IProcessPresenter Members

        public IInboxActionsPresenter Inbox { get; private set; }
        public IProcessActionPresenter ProcessAction { get; private set; }

        #endregion
    }
}