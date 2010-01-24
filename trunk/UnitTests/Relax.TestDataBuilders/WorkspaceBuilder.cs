using System.Collections.ObjectModel;
using Moq;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class WorkspaceBuilder : BuilderBase<IWorkspace>
    {
        private ObservableCollection<IAction> _actions = new ObservableCollection<IAction>();

        protected override void SetupMock(Mock<IWorkspace> mock)
        {
            mock.Setup(x => x.Actions).Returns(new ObservableCollection<IAction>(_actions));
        }

        public WorkspaceBuilder With(ActionBuilder actionBuilder)
        {
            return With(actionBuilder.Build());
        }

        public WorkspaceBuilder With(IAction action)
        {
            return new WorkspaceBuilder { _actions = new ObservableCollection<IAction>(_actions) { action } };
        }
    }
}