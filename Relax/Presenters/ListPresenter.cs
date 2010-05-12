using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Caliburn.PresentationFramework.Screens;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class ListPresenter<TModel, TModelPresenter> : ScreenConductor<TModelPresenter>, IListPresenter<TModel>
        where TModelPresenter : class, IModelPresenter<TModel>
        where TModel : class
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
            ClosePresenters(Screens.ToList());
            OpenItems(_collection);
        }

        private void ClosePresenters(IEnumerable<TModelPresenter> presenters)
        {
            foreach (TModelPresenter presenter in presenters)
                ClosePresenter(presenter);
        }

        protected virtual void OpenItems(IEnumerable<TModel> items)
        {
            foreach (TModel item in items)
                this.OpenScreen(_itemPresenterFactory(item));
        }

        protected virtual void CloseItems(IEnumerable<TModel> items)
        {
            ClosePresenters(
                items.Select(closedModel => Screens.First(x => closedModel.Equals((x).Model))).
                    ToList());
        }

        protected virtual void ClosePresenter(TModelPresenter presenter)
        {
            this.ShutdownScreen(presenter);
            Screens.Remove(presenter);
        }
    }
}