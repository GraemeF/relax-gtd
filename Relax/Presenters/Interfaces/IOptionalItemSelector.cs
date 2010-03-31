namespace Relax.Presenters.Interfaces
{
    public interface IOptionalItemSelector<TItem> : IListPresenter<TItem>
    {
        TItem SelectedItem { get; set; }
    }
}