using System.Collections.ObjectModel;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class ActionBuilder : BuilderBase<IAction>
    {
        private ObservableCollection<IAction> _blockingActions = new ObservableCollection<IAction>();
        private State _state = State.Committed;
        public string _title = "Unspecified";

        public ActionBuilder()
        {
        }

        private ActionBuilder(ActionBuilder other)
        {
            _blockingActions = new ObservableCollection<IAction>(other._blockingActions);
            _state = other._state;
        }

        protected override void SetupMock(Mock<IAction> mock)
        {
            mock.Setup(x => x.Title).Returns(_title);
            mock.Setup(x => x.ActionState).Returns(_state);
            mock.Setup(x => x.BlockingActions).Returns(new ObservableCollection<IAction>(_blockingActions));
        }

        public ActionBuilder In(State state)
        {
            return new ActionBuilder(this) {_state = state};
        }

        public ActionBuilder BlockedBy(ActionBuilder action)
        {
            return BlockedBy(action.Build());
        }

        public ActionBuilder BlockedBy(IAction action)
        {
            return new ActionBuilder(this)
                       {_blockingActions = new ObservableCollection<IAction>(_blockingActions) {action}};
        }

        public ActionBuilder Called(string title)
        {
            return new ActionBuilder(this) {_title = title};
        }
    }
}