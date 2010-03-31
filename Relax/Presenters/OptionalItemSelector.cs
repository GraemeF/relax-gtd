using System;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class OptionalItemSelector<TModel, TModelPresenter> : ListPresenter<TModel, TModelPresenter>,
                                                                 IOptionalItemSelector<TModel>
        where TModelPresenter : IModelPresenter<TModel>
        where TModel : class
    {
        protected OptionalItemSelector(ObservableCollection<TModel> collection, Func<TModel, TModelPresenter> factory)
            : base(collection, factory)
        {
        }

        #region IOptionalItemSelector<TModel> Members

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
                              FirstOrDefault(x => x.Model == value));
            }
        }

        #endregion

        protected override void ChangeCurrentPresenterCore(IPresenter newCurrent)
        {
            base.ChangeCurrentPresenterCore(newCurrent);
            NotifyOfPropertyChange(() => SelectedItem);
        }
    }
}