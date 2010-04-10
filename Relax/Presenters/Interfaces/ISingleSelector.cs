using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface ISingleSelector<TItem> : IPresenterHost
    {
        TItem SelectedItem { get; set; }
    }
}