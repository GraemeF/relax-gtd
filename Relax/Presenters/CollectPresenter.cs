using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Screens;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (ICollectPresenter))]
    public class CollectPresenter : ScreenConductor<IScreen>, ICollectPresenter
    {
        public CollectPresenter(IInputPresenter inputPresenter, ISingleInboxActionSelector inboxPresenter)
        {
            Input = inputPresenter;
            InboxActions = inboxPresenter;
        }

        public ISingleInboxActionSelector InboxActions { get; private set; }
        public IInputPresenter Input { get; private set; }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            this.OpenScreen(Input);
            this.OpenScreen(InboxActions);
        }
    }
}