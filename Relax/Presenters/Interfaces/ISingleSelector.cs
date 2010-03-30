using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface ISingleSelector<TItem> : IPresenterManager
    {
        TItem SelectedItem { get; set; }
    }
}