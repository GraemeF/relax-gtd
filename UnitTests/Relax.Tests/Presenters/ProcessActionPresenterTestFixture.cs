using System;
using System.ComponentModel;
using System.Windows.Input;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.Testability.Extensions;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ProcessActionPresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void DisplayName__ReturnsActionTitle()
        {
            const string titleOfTheAction = "Title of the action";
            var test = new ProcessActionPresenter(AnAction.Called(titleOfTheAction).Build());

            Assert.Equal(titleOfTheAction, test.DisplayName);
        }

        [Fact]
        public void DisplayName_WhenSet_SetsActionTitle()
        {
            Mock<IAction> mockAction = AnAction.Mock();
            var test = new ProcessActionPresenter(mockAction.Object);

            const string newTitle = "New title";
            test.DisplayName = newTitle;

            mockAction.VerifySet(x => x.Title = newTitle);
        }

        [Fact]
        public void DisplayName_WhenActionTitleChanges_RaisesPropertyChanged()
        {
            const string titleOfTheAction = "Title of the action";
            Mock<IAction> stubAction = AnAction.Called(titleOfTheAction).Mock();

            var test = new ProcessActionPresenter(stubAction.Object);

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DisplayName).
                When(() => stubAction.Raise(x => x.PropertyChanged += null,
                                            new PropertyChangedEventArgs("Title")));
        }

        [Fact]
        public void Initialize__PopulatesPresenters()
        {
            var test = new ProcessActionPresenter(AnAction.Build());

            test.Initialize();

            Assert.NotEmpty(test.Presenters);
        }

        [Fact]
        public void Apply__AppliesCurrentPresenter()
        {
            IAction action = AnAction.Build();
            var test = new ProcessActionPresenter(action);

            var mockProcessor = new Mock<IActionProcessorPresenter>();
            var mockCommand = new Mock<ICommand>();
            mockProcessor.Setup(x => x.ApplyCommand).Returns(mockCommand.Object);

            test.CurrentPresenter = mockProcessor.Object;
            test.Apply();

            mockCommand.Verify(x => x.Execute(action));
        }
    }
}