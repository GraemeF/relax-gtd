using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class SingleItemSelector<TModel, TModelPresenter> : ListPresenter<TModel, TModelPresenter>,
                                                               ISingleSelector<TModel>
        where TModelPresenter : IModelPresenter<TModel>
        where TModel : class
    {
        private readonly ISelectionPolicy _selectionPolicy;

        private TModel _selectedItem;

        protected SingleItemSelector(ObservableCollection<TModel> collection,
                                     Func<TModel, TModelPresenter> factory,
                                     ISelectionPolicy selectionPolicy)
            : base(collection, factory)
        {
            _selectionPolicy = selectionPolicy;
        }

        #region ISingleSelector<TModel> Members

        public TModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = _selectionPolicy.ModifySelectedItem(this, value);
                if (_selectedItem != null)
                    this.Open(Presenters.
                                  Cast<TModelPresenter>().
                                  First(x => x.Model == _selectedItem));
                NotifyOfPropertyChange(() => SelectedItem);
            }
        }

        #endregion

        protected override void CloseItems(IEnumerable<TModel> items)
        {
            base.CloseItems(items);

            if (items.Contains(SelectedItem))
                SelectedItem = null;
        }

        protected override void OpenItems(IEnumerable<TModel> items)
        {
            base.OpenItems(items);

            ApplySelectionPolicy();
        }

        private void ApplySelectionPolicy()
        {
            SelectedItem = SelectedItem;
        }
    }
}