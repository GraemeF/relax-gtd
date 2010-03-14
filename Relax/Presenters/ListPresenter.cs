using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class ListPresenter<TModel, TModelPresenter> : MultiPresenterManager, IListPresenter<TModel>
        where TModelPresenter : IModelPresenter<TModel>
        where TModel : class
    {
        private readonly ObservableCollection<TModel> _collection;
        private readonly Func<TModel, TModelPresenter> _itemPresenterFactory;

        protected ListPresenter(ObservableCollection<TModel> collection, Func<TModel, TModelPresenter> factory)
        {
            _collection = collection;
            _itemPresenterFactory = factory;
        }

        #region IListPresenter<TModel> Members

        public TModel CurrentItem
        {
            get
            {
                return CurrentPresenter != null
                           ? ((TModelPresenter) CurrentPresenter).Model
                           : null;
            }
        }

        #endregion

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _collection.CollectionChanged += CollectionChanged;
            OpenItems(_collection);

            CurrentPresenter = Presenters.FirstOrDefault();
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

        private void OpenItems(IEnumerable<TModel> items)
        {
            foreach (TModel item in items)
                this.Open(_itemPresenterFactory(item));
        }

        private void CloseItems(IEnumerable<TModel> items)
        {
            foreach (TModelPresenter presenter in
                items.Select(closedModel => Presenters.First(x => closedModel.Equals(((TModelPresenter) x).Model))).
                    ToList())
                ClosePresenter(presenter);

            if (items.Contains(CurrentItem))
                OpenFirstPresenter();
        }

        private void OpenFirstPresenter()
        {
            IPresenter firstOrDefault = Presenters.FirstOrDefault();
            if (firstOrDefault != null)
                this.Open(firstOrDefault);
        }

        private void ClosePresenter(TModelPresenter presenter)
        {
            this.Shutdown(presenter);
            Presenters.Remove(presenter);
        }
    }
}