using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface IListPresenter<TModel> : IPresenterManager
    {
        TModel CurrentItem { get; set; }
    }
}