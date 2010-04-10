using System;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Policies;
using Relax.Presenters.Interfaces;
using Relax.Views;

namespace Relax.Presenters
{
    [View(typeof (ContextsView))]
    [PerRequest(typeof (ISingleSelector<IGtdContext>))]
    public class SingleContextSelector : SingleItemSelector<IGtdContext, IGtdContextPresenter>
    {
        private readonly Func<IGtdContext> _contextFactory;
        private readonly IWorkspace _workspace;

        public SingleContextSelector(IWorkspace workspace,
                                     Func<IGtdContext, IGtdContextPresenter> contextPresenterFactory,
                                     Func<IGtdContext> contextFactory,
                                     AlwaysSelectedPolicy selectionPolicy)
            : base(workspace.Contexts, contextPresenterFactory, selectionPolicy)
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