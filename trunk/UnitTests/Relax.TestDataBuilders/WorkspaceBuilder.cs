using System.Collections.ObjectModel;
using Moq;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class WorkspaceBuilder
    {
        private ObservableCollection<IAction> _actions = new ObservableCollection<IAction>();

        public WorkspaceBuilder WithAction(ActionBuilder actionBuilder)
        {
            return WithAction(actionBuilder.Build().Object);
        }

        public WorkspaceBuilder WithAction(IAction action)
        {
            return new WorkspaceBuilder {_actions = new ObservableCollection<IAction>(_actions) {action}};
        }

        public Mock<IWorkspace> Build()
        {
            var mock = new Mock<IWorkspace>();
            mock.Setup(x => x.Actions).Returns(_actions);

            return mock;
        }
    }
}