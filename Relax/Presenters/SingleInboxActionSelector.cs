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
    public class SingleInboxActionSelector : SingleItemSelector<IAction, IActionPresenter>, ISingleInboxActionSelector
    {
        private readonly IInboxActionsFilter _inboxActionsFilter;

        public SingleInboxActionSelector(IInboxActionsFilter inboxActionsFilter,
                                         Func<IAction, IActionPresenter> actionPresenterFactory,
                                         AlwaysSelectedPolicy selectionPolicy)
            : base(inboxActionsFilter.Actions, actionPresenterFactory, selectionPolicy)
        {
            _inboxActionsFilter = inboxActionsFilter;
        }
    }
}