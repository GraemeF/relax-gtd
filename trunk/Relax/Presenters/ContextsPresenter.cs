using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IContextsPresenter))]
    public class ContextsPresenter : MultiPresenter, IContextsPresenter
    {
        private readonly ContextPresenter.Factory _contextPresenterFactory;
        private readonly IWorkspace _workspace;

        public ContextsPresenter(IWorkspace workspace, ContextPresenter.Factory contextPresenterFactory)
        {
            _workspace = workspace;
            _contextPresenterFactory = contextPresenterFactory;

            _workspace.Contexts.CollectionChanged += Contexts_CollectionChanged;

            OpenContexts(_workspace.Contexts);
        }

        private void Contexts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                OpenContexts(e.NewItems.Cast<IContext>());
        }

        private void OpenContexts(IEnumerable<IContext> newItems)
        {
            foreach (IContext newItem in newItems)
                Open(_contextPresenterFactory(newItem), isSuccess => { });
        }

        public override string ToString()
        {
            return "Hello from ContextsPresenter";
        }

        public void AddContext()
        {
            return;
        }
    }
}