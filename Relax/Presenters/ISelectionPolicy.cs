using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public interface ISelectionPolicy
    {
        TItem ModifySelectedItem<TItem>(ISingleSelector<TItem> selector, TItem item) where TItem : class;
    }
}