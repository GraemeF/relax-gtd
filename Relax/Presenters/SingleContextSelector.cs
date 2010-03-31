using System;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (ISingleSelector<IGtdContext>))]
    public class SingleContextSelector : SingleItemSelector<IGtdContext, IGtdContextPresenter>
    {
        private readonly Func<IGtdContext> _contextFactory;
        private readonly IWorkspace _workspace;

        public SingleContextSelector(IWorkspace workspace,
                                 Func<IGtdContext, IGtdContextPresenter> contextPresenterFactory,
                                 Func<IGtdContext> contextFactory)
            : base(workspace.Contexts, contextPresenterFactory)
        {
            _workspace = workspace;
            _contextFactory = contextFactory;
        }

        public void AddContext()
        {
            IGtdContext context = _contextFactory();
            context.Title = "New Context";

            _workspace.Contexts.Add(context);
        }
    }
}