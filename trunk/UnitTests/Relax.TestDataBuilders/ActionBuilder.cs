using System.Collections.ObjectModel;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class ActionBuilder
    {
        private ObservableCollection<IAction> _blockingActions = new ObservableCollection<IAction>();
        private State _state = State.Committed;

        public Mock<IAction> Build()
        {
            var mock = new Mock<IAction>();
            mock.Setup(x => x.ActionState).Returns(_state);

            return mock;
        }

        public ActionBuilder InState(State state)
        {
            return new ActionBuilder {_state = state};
        }

        public ActionBuilder BlockedBy(ActionBuilder action)
        {
            return BlockedBy(action.Build().Object);
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