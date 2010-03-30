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
        protected SingleItemSelector(ObservableCollection<TModel> collection, Func<TModel, TModelPresenter> factory)
            : base(collection, factory)
        {
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
                this.Open(Presenters.
                              Cast<TModelPresenter>().
                              First(x => x.Model == value));
            }
        }

        #endregion

        private void OpenFirstPresenter()
        {
            IPresenter firstOrDefault = Presenters.FirstOrDefault();
            if (firstOrDefault != null)
                this.Open(firstOrDefault);
        }

        protected override void ChangeCurrentPresenterCore(IPresenter newCurrent)
        {
            base.ChangeCurrentPresenterCore(newCurrent);
            NotifyOfPropertyChange(() => SelectedItem);
        }

        protected override void CloseItems(IEnumerable<TModel> items)
        {
            base.CloseItems(items);

            if (items.Contains(SelectedItem))
                OpenFirstPresenter();
        }
    }
}