using Caliburn.PresentationFramework.Screens;

namespace Relax.Presenters.Interfaces
{
    public interface IProcessPresenter : IScreen
    {
        ISingleInboxActionSelector Inbox { get; }
    }
}