using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (ICollectPresenter))]
    public class CollectPresenter : MultiPresenter, ICollectPresenter
    {
        public CollectPresenter(IInputPresenter inputPresenter, ISingleInboxActionSelector inboxPresenter)
        {
            Input = inputPresenter;
            InboxActions = inboxPresenter;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            this.Open(Input);
            this.Open(InboxActions);
        }

        public ISingleInboxActionSelector InboxActions { get; private set; }
        public IInputPresenter Input { get; private set; }
    }
}