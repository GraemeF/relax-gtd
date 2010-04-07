using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax.Policies
{
    public class AllowNullSelectionPolicy : ISelectionPolicy
    {
        #region ISelectionPolicy Members

        public TItem ModifySelectedItem<TItem>(ISingleSelector<TItem> selector, TItem item)
            where TItem : class
        {
            return item;
        }

        #endregion
    }
}