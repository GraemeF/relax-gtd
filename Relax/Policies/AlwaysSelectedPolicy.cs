using System.Linq;
using Relax.Presenters.Interfaces;

namespace Relax.Policies
{
    public class AlwaysSelectedPolicy : ISelectionPolicy
    {
        #region ISelectionPolicy Members

        public TItem ModifySelectedItem<TItem>(ISingleSelector<TItem> selector, TItem item)
            where TItem : class
        {
            if (item == null)
            {
                IModelPresenter<TItem> firstPresenter =
                    selector.Screens.Cast<IModelPresenter<TItem>>().FirstOrDefault();
                if (firstPresenter != null)
                    return firstPresenter.Model;
            }
            return item;
        }

        #endregion
    }
}