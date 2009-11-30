using System;
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
        private readonly Func<IGtdContext> _contextFactory;
        private readonly Func<IGtdContext, IGtdContextPresenter> _contextPresenterFactory;
        private readonly IWorkspace _workspace;

        public ContextsPresenter(IWorkspace workspace,
                                 Func<IGtdContext, IGtdContextPresenter> contextPresenterFactory,
                                 Func<IGtdContext> contextFactory)
        {
            _workspace = workspace;
            _contextPresenterFactory = contextPresenterFactory;
            _contextFactory = contextFactory;

            _workspace.Contexts.CollectionChanged += Contexts_CollectionChanged;

            OpenContexts(_workspace.Contexts);
        }

        private void Contexts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                CloseContexts(e.OldItems.Cast<IGtdContext>());
            if (e.NewItems != null)
                OpenContexts(e.NewItems.Cast<IGtdContext>());
        }

        private void OpenContexts(IEnumerable<IGtdContext> newItems)
        {
            foreach (IGtdContext newItem in newItems)
                Open(_contextPresenterFactory(newItem), isSuccess => { });
        }

        private void CloseContexts(IEnumerable<IGtdContext> oldItems)
        {
            foreach (IGtdContext oldItem in oldItems)
                Shutdown(Presenters.First(x => ((IGtdContextPresenter) x).Context == oldItem), isSuccess => { });
        }

        public void AddContext()
        {
            IGtdContext context = _contextFactory();
            context.Title = "New Context";

            _workspace.Contexts.Add(context);
        }
    }
}