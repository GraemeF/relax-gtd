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
        private readonly ObservableCollection<TModel> _collection;
        private readonly Func<TModel, TModelPresenter> _itemPresenterFactory;

        protected ListPresenter(ObservableCollection<TModel> collection, Func<TModel, TModelPresenter> factory)
        {
            _collection = collection;
            _itemPresenterFactory = factory;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _collection.CollectionChanged += CollectionChanged;
            OpenItems(_collection);
        }

        protected override void OnShutdown()
        {
            CloseItems(_collection);
            _collection.CollectionChanged -= CollectionChanged;

            base.OnShutdown();
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                CloseItems(e.OldItems.Cast<TModel>());
            if (e.NewItems != null)
                OpenItems(e.NewItems.Cast<TModel>());
        }

        private void OpenItems(IEnumerable<TModel> newItems)
        {
            foreach (TModel newItem in newItems)
                this.Open(_itemPresenterFactory(newItem));
        }

        private void CloseItems(IEnumerable<TModel> oldItems)
        {
            foreach (IPresenter presenter in
                oldItems.Select(closedModel => Presenters.First(x => closedModel.Equals(((TModelPresenter) x).Model))).
                    ToList())
            {
                this.Shutdown(presenter);
                Presenters.Remove(presenter);
            }
        }
    }
}