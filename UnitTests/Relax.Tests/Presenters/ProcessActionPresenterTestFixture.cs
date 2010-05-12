using System.ComponentModel;
using System.Windows.Input;
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
        private readonly Mock<IActionProcessorPresenter> _fakeProcessor = new Mock<IActionProcessorPresenter>();

        [Fact]
        public void DisplayName__ReturnsActionTitle()
        {
            const string titleOfTheAction = "Title of the action";
            var test = new ProcessActionPresenter(AnAction.Called(titleOfTheAction).Build(),
                                                  x => new[] {_fakeProcessor.Object});

            Assert.Equal(titleOfTheAction, test.DisplayName);
        }

        [Fact]
        public void DisplayName_WhenSet_SetsActionTitle()
        {
            Mock<IAction> mockAction = AnAction.Mock();
            var test = new ProcessActionPresenter(mockAction.Object, x => new[] {_fakeProcessor.Object});

            const string newTitle = "New title";
            test.DisplayName = newTitle;

            mockAction.VerifySet(x => x.Title = newTitle);
        }

        [Fact]
        public void DisplayName_WhenActionTitleChanges_RaisesPropertyChanged()
        {
            const string titleOfTheAction = "Title of the action";
            Mock<IAction> stubAction = AnAction.Called(titleOfTheAction).Mock();

            var test = new ProcessActionPresenter(stubAction.Object, x => new[] {_fakeProcessor.Object});

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DisplayName).
                When(() => stubAction.Raise(x => x.PropertyChanged += null,
                                            new PropertyChangedEventArgs("Title")));
        }

        [Fact]
        public void Initialize__PopulatesPresenters()
        {
            var test = new ProcessActionPresenter(AnAction.Build(), x => new[] {_fakeProcessor.Object});

            test.Initialize();

            Assert.NotEmpty(test.Screens);
        }

        [Fact]
        public void Apply__AppliesCurrentPresenter()
        {
            IAction action = AnAction.Build();

            var mockCommand = new Mock<ICommand>();
            _fakeProcessor.Setup(x => x.ApplyCommand).Returns(mockCommand.Object);

            var test = new ProcessActionPresenter(action, x => new[] {_fakeProcessor.Object});
            test.Initialize();

            test.Apply();

            mockCommand.Verify(x => x.Execute(action));
        }
    }
}