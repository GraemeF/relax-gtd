using System;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;
using Relax.Views;

namespace Relax.Presenters
{
    [PerRequest(typeof (IInboxActionsPresenter))]
    [View(typeof (ActionsView))]
    public class InboxActionsPresenter : ListPresenter<IAction, IActionPresenter>, IInboxActionsPresenter
    {
        private readonly IInboxActionsFilter _inboxActionsFilter;

        public InboxActionsPresenter(IInboxActionsFilter inboxActionsFilter,
                                     Func<IAction, IActionPresenter> actionPresenterFactory)
            : base(inboxActionsFilter.Actions, actionPresenterFactory)
        {
            _inboxActionsFilter = inboxActionsFilter;
        }
    }
}