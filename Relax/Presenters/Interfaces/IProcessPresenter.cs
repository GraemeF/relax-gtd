using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface IProcessPresenter : IPresenter
    {
        ISingleInboxActionSelector Inbox { get; }
    }
}