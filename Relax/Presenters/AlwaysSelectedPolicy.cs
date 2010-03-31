using System.Linq;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class AlwaysSelectedPolicy : ISelectionPolicy
    {
        #region ISelectionPolicy Members

        public TItem ModifySelectedItem<TItem>(ISingleSelector<TItem> selector, TItem item)
        {
            if (item == null)
            {
                IModelPresenter<TItem> firstPresenter =
                    selector.Presenters.Cast<IModelPresenter<TItem>>().FirstOrDefault();
                if (firstPresenter != null)
                    return firstPresenter.Model;
            }
            return item;
        }

        #endregion
    }
}