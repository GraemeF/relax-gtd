using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class ActionBuilder
    {
        private State _state = State.Committed;

        public ActionBuilder With(State state)
        {
            return new ActionBuilder {_state = state};
        }

        public Mock<IAction> Build()
        {
            var mock = new Mock<IAction>();
            mock.Setup(x => x.ActionState).Returns(_state);

            return mock;
        }
    }
}