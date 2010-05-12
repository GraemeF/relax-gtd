using System;
using System.Collections.ObjectModel;
using Moq;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class WorkspacePresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void GoCollect__ActivatesCollectPresenter()
        {
            var mockPresenter = new Mock<ICollectPresenter>();

            var test = new WorkspacePresenter(AnInboxActionsFilter.Build(), mockPresenter.Object, null);
            test.Activate();

            test.GoCollect();

            mockPresenter.Verify(x => x.Activate());
        }

        [Fact]
        public void GoProcess__ActivatesProcessPresenter()
        {
            var mockPresenter = new Mock<IProcessPresenter>();

            var test = new WorkspacePresenter(AnInboxActionsFilter.Build(), null, mockPresenter.Object);
            test.Activate();

            test.GoProcess();

            mockPresenter.Verify(x => x.Activate());
        }

        [Fact]
        public void IsProcessingEnabled_WhenThereAreNoInboxActions_IsFalse()
        {
            var test = new WorkspacePresenter(AnInboxActionsFilter.Build(), null, null);
            Assert.False(test.IsProcessingEnabled);
        }

        [Fact]
        public void IsProcessingEnabled_WhenThereIsAnInboxAction_IsTrue()
        {
            var test = new WorkspacePresenter(AnInboxActionsFilter.Providing(AnAction.In(State.Inbox)).Build(), null,
                                              null);
            Assert.True(test.IsProcessingEnabled);
        }


        [Fact]
        public void ProcessButtonText_WhenThereAreNoInboxActions_IsProcess()
        {
            var test = new WorkspacePresenter(AnInboxActionsFilter.Build(), null, null);
            Assert.Equal("Process", test.ProcessButtonText);
        }

        [Fact]
        public void ProcessButtonText_WhenThereIsAnInboxAction_ContainsNumber()
        {
            var test = new WorkspacePresenter(AnInboxActionsFilter.Providing(AnAction.In(State.Inbox)).Build(), null,
                                              null);
            Assert.Equal("Process (1)", test.ProcessButtonText);
        }

        [Fact]
        public void IsProcessingEnabled_WhenAnInboxActionIsAdded_RaisesPropertyChanged()
        {
            var actions = new ObservableCollection<IAction>();
            Mock<IInboxActionsFilter> inboxActionsFilter = AnInboxActionsFilter.ProvidingViewOf(actions);

            var test = new WorkspacePresenter(inboxActionsFilter.Object, null, null);

            bool eventRaised = false;

            test.PropertyChanged += (sender, args) => eventRaised |= args.PropertyName == "IsProcessingEnabled";

            actions.Add(AnAction.In(State.Inbox).Build());
            GC.KeepAlive(test);

            Assert.True(eventRaised);
        }
    }
}