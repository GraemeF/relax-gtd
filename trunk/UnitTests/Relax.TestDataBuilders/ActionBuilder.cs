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

        protected override void SetupMock(Mock<IAction> mock)
        {
            mock.Setup(x => x.ActionState).Returns(_state);
            mock.Setup(x => x.BlockingActions).Returns(new ObservableCollection<IAction>(_blockingActions));
        }

        public ActionBuilder In(State state)
        {
            return new ActionBuilder {_state = state};
        }

        public ActionBuilder BlockedBy(ActionBuilder action)
        {
            return BlockedBy(action.Build());
        }

        public ActionBuilder BlockedBy(IAction action)
        {
            return new ActionBuilder
                       {
                           _state = _state,
                           _blockingActions = new ObservableCollection<IAction>(_blockingActions) {action}
                       };
        }
    }
}