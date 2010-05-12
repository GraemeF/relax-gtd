using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (ICollectPresenter))]
    public class CollectPresenter : ScreenConductor<IScreen>.WithCollection.AllScreensActive, ICollectPresenter
    {
        public CollectPresenter(IInputPresenter inputPresenter, ISingleInboxActionSelector inboxPresenter) : base(true)
        {
            Input = inputPresenter;
            InboxActions = inboxPresenter;
        }

        public ISingleInboxActionSelector InboxActions { get; private set; }
        public IInputPresenter Input { get; private set; }
    }
}