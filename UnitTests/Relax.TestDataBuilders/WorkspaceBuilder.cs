using System.Collections.ObjectModel;
using Moq;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class WorkspaceBuilder : BuilderBase<IWorkspace>
    {
        private ObservableCollection<IAction> _actions = new ObservableCollection<IAction>();
        private ObservableCollection<IGtdContext> _contexts = new ObservableCollection<IGtdContext>();

        public WorkspaceBuilder()
        {
        }

        private WorkspaceBuilder(WorkspaceBuilder other)
        {
            _actions = new ObservableCollection<IAction>(other._actions);
            _contexts = new ObservableCollection<IGtdContext>(other._contexts);
        }

        protected override void SetupMock(Mock<IWorkspace> mock)
        {
            mock.Setup(x => x.Contexts).Returns(new ObservableCollection<IGtdContext>(_contexts));
            mock.Setup(x => x.Actions).Returns(new ObservableCollection<IAction>(_actions));
        }

        public WorkspaceBuilder With(ActionBuilder actionBuilder)
        {
            return With(actionBuilder.Build());
        }

        public WorkspaceBuilder With(IAction action)
        {
            return new WorkspaceBuilder(this) {_actions = new ObservableCollection<IAction>(_actions) {action}};
        }

        public WorkspaceBuilder With(IGtdContext context)
        {
            return new WorkspaceBuilder(this) {_contexts = new ObservableCollection<IGtdContext>(_contexts) {context}};
        }
    }
}