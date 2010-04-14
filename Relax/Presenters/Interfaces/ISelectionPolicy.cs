namespace Relax.Presenters.Interfaces
{
    public interface ISelectionPolicy
    {
        TItem ModifySelectedItem<TItem>(ISingleSelector<TItem> selector, TItem item) where TItem : class;
    }
}