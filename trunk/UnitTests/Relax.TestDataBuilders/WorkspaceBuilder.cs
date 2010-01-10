using System.Collections.ObjectModel;
using Moq;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class WorkspaceBuilder
    {
        private ObservableCollection<IAction> _actions = new ObservableCollection<IAction>();

        public Mock<IWorkspace> Build()
        {
            var mock = new Mock<IWorkspace>();
            mock.Setup(x => x.Actions).Returns(new ObservableCollection<IAction>(_actions));

            return mock;
        }

        public WorkspaceBuilder With(ActionBuilder actionBuilder)
        {
            return With(actionBuilder.Build().Object);
        }

        public WorkspaceBuilder With(IAction action)
        {
            return new WorkspaceBuilder {_actions = new ObservableCollection<IAction>(_actions) {action}};
        }
    }
}