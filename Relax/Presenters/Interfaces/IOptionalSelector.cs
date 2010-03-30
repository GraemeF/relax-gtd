namespace Relax.Presenters.Interfaces
{
    public interface IOptionalSelector<TItem> : IListPresenter<TItem>
    {
        TItem SelectedItem { get; set; }
    }
}