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

        protected override void ChangeCurrentPresenterCore(IPresenter newCurrent)
        {
            base.ChangeCurrentPresenterCore(newCurrent);
            NotifyOfPropertyChange(() => CurrentItem);
        }

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

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    OpenItems(args.NewItems.Cast<TModel>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    CloseItems(args.OldItems.Cast<TModel>());
                    break;
                default:
                    PopulateWithAllItems();
                    break;
            }
        }

        private void PopulateWithAllItems()
        {
            ClosePresenters(Presenters.ToList());
            OpenItems(_collection);
        }

        private void ClosePresenters(IEnumerable<IPresenter> presenters)
        {
            foreach (TModelPresenter presenter in presenters)
                ClosePresenter(presenter);
        }

        private void OpenItems(IEnumerable<TModel> items)
        {
            foreach (TModel item in items)
                this.Open(_itemPresenterFactory(item));
        }

        private void CloseItems(IEnumerable<TModel> items)
        {
            ClosePresenters(
                items.Select(closedModel => Presenters.First(x => closedModel.Equals(((TModelPresenter) x).Model))).
                    ToList());

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