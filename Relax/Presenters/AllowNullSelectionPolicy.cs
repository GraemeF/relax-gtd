using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class AllowNullSelectionPolicy : ISelectionPolicy
    {
        #region ISelectionPolicy Members

        public TItem ModifySelectedItem<TItem>(ISingleSelector<TItem> selector, TItem item)
        {
            return item;
        }

        #endregion
    }
}