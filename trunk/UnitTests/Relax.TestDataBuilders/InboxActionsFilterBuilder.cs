using System.Collections.ObjectModel;
using System.Windows.Data;
using Moq;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class InboxActionsFilterBuilder : BuilderBase<IInboxActionsFilter>
    {
        private ObservableCollection<IAction> _actions = new ObservableCollection<IAction>();

        protected override void SetupMock(Mock<IInboxActionsFilter> mock)
        {
            mock.Setup(x => x.InboxActions).Returns(
                CollectionViewSource.GetDefaultView(new ObservableCollection<IAction>(_actions)));
        }

        public InboxActionsFilterBuilder Providing(ActionBuilder actionBuilder)
        {
            return Providing(actionBuilder.Build());
        }

        public InboxActionsFilterBuilder Providing(IAction action)
        {
            return new InboxActionsFilterBuilder {_actions = new ObservableCollection<IAction>(_actions) {action}};
        }
    }
}