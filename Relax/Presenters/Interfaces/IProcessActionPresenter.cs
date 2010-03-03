using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface IProcessActionPresenter : IPresenter
    {
        IDoNowPresenter DoNow { get; }
        IDoLaterPresenter DoLater { get; }
    }
}