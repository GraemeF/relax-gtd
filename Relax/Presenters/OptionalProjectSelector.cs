using System;
using Caliburn.Core.Metadata;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IOptionalProjectSelector))]
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