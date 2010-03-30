using Caliburn.PresentationFramework;

namespace Relax.Presenters.Interfaces
{
    public interface IMultipleSelector<TItem> : IListPresenter<TItem>
    {
        IObservableCollection<TItem> SelectedItems { get; }
    }
}