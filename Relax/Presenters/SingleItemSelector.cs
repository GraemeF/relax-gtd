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
            get
            {
                return CurrentPresenter != null
                           ? ((TModelPresenter) CurrentPresenter).Model
                           : null;
            }
            set
            {
                TModel newSelection = _selectionPolicy.ModifySelectedItem(this, value);
                if (newSelection != null)
                    this.Open(Presenters.
                                  Cast<TModelPresenter>().
                                  First(x => x.Model == newSelection));
                else
                {
                    this.ShutdownCurrent();
                    CurrentPresenter = null;
                }
            }
        }

        #endregion

        protected override void ChangeCurrentPresenterCore(IPresenter newCurrent)
        {
            base.ChangeCurrentPresenterCore(newCurrent);
            NotifyOfPropertyChange(() => SelectedItem);
        }

        protected override void CloseItems(IEnumerable<TModel> items)
        {
            base.CloseItems(items);

            if (items.Contains(SelectedItem))
                SelectedItem = null;
        }
    }
}