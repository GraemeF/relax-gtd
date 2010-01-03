using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class ListPresenter<TModel, TModelPresenter> : MultiPresenter
        where TModelPresenter : IModelPresenter<TModel>
    {
        protected Func<TModel, TModelPresenter> _itemPresenterFactory;

        protected ListPresenter(ICollectionView collection, Func<TModel, TModelPresenter> factory)
        {
            _itemPresenterFactory = factory;

            collection.CollectionChanged += CollectionChanged;

            OpenItems(collection.Cast<TModel>());
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
            foreach (TModel oldItem in oldItems)
            {
                TModel context = oldItem;
                IPresenter presenter = Presenters.First(x => ((TModelPresenter) x).Model.Equals(context));

                Shutdown(presenter, isSuccess => { });
                Presenters.Remove(presenter);
            }
        }
    }
}