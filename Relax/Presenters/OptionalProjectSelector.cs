using System;
using Caliburn.Core.Metadata;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof(IOptionalProjectSelector))]
    public class OptionalProjectSelector : OptionalItemSelector<IAction,IActionTreeNodePresenter>, IOptionalProjectSelector
    {
        public OptionalProjectSelector(IProjectsFilter filter,
                                       Func<IAction, IActionTreeNodePresenter> presenterFactory)
            : base(filter.Actions, presenterFactory)
        {
        }
    }
}