using System;
using System.Windows.Data;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IContextsPresenter))]
    public class ContextsPresenter : ListPresenter<IGtdContext, IGtdContextPresenter>, IContextsPresenter
    {
        private readonly Func<IGtdContext> _contextFactory;
        private readonly IWorkspace _workspace;

        public ContextsPresenter(IWorkspace workspace,
                                 Func<IGtdContext, IGtdContextPresenter> contextPresenterFactory,
                                 Func<IGtdContext> contextFactory)
            : base(CollectionViewSource.GetDefaultView(workspace.Contexts), contextPresenterFactory)
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