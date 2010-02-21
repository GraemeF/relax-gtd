using System.Collections.ObjectModel;
using Moq;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class ActionsFilterBuilder<T> : BuilderBase<T> where T : class, IActionsFilter
    {
        private ObservableCollection<IAction> _actions = new ObservableCollection<IAction>();

        protected override void SetupMock(Mock<T> mock)
        {
            mock.Setup(x => x.Actions).Returns(_actions);
        }

        public ActionsFilterBuilder<T> Providing(ActionBuilder actionBuilder)
        {
            return Providing(actionBuilder.Build());
        }

        public ActionsFilterBuilder<T> Providing(IAction action)
        {
            return new ActionsFilterBuilder<T> {_actions = new ObservableCollection<IAction>(_actions) {action}};
        }

        public Mock<T> ProvidingViewOf(ObservableCollection<IAction> actions)
        {
            _actions = actions;
            var mock = new Mock<T>();
            SetupMock(mock);
            return mock;
        }
    }
}