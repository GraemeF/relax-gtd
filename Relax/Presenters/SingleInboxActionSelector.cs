using System;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;
using Relax.Views;

namespace Relax.Presenters
{
    [PerRequest(typeof (ISingleInboxActionSelector))]
    [View(typeof (ActionsView))]
    public class SingleInboxActionSelector : ListPresenter<IAction, IActionPresenter>, ISingleInboxActionSelector
    {
        private readonly IInboxActionsFilter _inboxActionsFilter;

        public SingleInboxActionSelector(IInboxActionsFilter inboxActionsFilter,
                                     Func<IAction, IActionPresenter> actionPresenterFactory)
            : base(inboxActionsFilter.Actions, actionPresenterFactory)
        {
            _inboxActionsFilter = inboxActionsFilter;
        }
    }
}