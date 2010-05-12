using Caliburn.PresentationFramework.Screens;

namespace Relax.Presenters.Interfaces
{
    public interface IModelPresenter<TModel> : IScreen
    {
        TModel Model { get; }
    }
}