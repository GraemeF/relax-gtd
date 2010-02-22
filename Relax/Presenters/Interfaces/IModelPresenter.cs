using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface IModelPresenter<TModel> : IPresenter
    {
        TModel Model { get; }
    }
}