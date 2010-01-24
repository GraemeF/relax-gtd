using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class ListPresenter<TModel, TModelPresenter> : MultiPresenter, IListPresenter
        where TModelPresenter : IModelPresenter<TModel>
    {
        private readonly Func<TModel, TModelPresenter> _itemPresenterFactory;

        protected ListPresenter(ObservableCollection<TModel> collection, Func<TModel, TModelPresenter> factory)
        {
            _itemPresenterFactory = factory;

            collection.CollectionChanged += CollectionChanged;

            OpenItems(collection);
        }

        protected void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                CloseItems(e.OldItems.Cast<TModel>());
            if (e.NewItems != null)
                OpenItems(e.NewItems.Cast<TModel>());
        }

        protected void OpenItems(IEnumerable<TModel> newItems)
        {
            foreach (TModel newItem in newItems)
                Open(_itemPresenterFactory(newItem), isSuccess => { });
        }

        private void CloseItems(IEnumerable<TModel> oldItems)
        {
            foreach (IPresenter presenter in
                oldItems.Select(context => Presenters.First(x => ((TModelPresenter) x).Model.Equals(context))))
            {
                Shutdown(presenter, isSuccess => { });
                Presenters.Remove(presenter);
            }
        }
    }
}