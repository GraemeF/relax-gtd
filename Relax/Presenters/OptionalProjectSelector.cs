using System;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Views;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Policies;
using Relax.Presenters.Interfaces;
using Relax.Views;

namespace Relax.Presenters
{
    [PerRequest(typeof (IOptionalProjectSelector))]
    [View(typeof (ProjectsView))]
    public class OptionalProjectSelector : SingleItemSelector<IAction, IActionTreeNodePresenter>,
                                           IOptionalProjectSelector
    {
        public OptionalProjectSelector(IProjectsFilter filter,
                                       Func<IAction, IActionTreeNodePresenter> presenterFactory,
                                       AllowNullSelectionPolicy selectionPolicy)
            : base(filter.Actions, presenterFactory, selectionPolicy)
        {
        }
    }
}