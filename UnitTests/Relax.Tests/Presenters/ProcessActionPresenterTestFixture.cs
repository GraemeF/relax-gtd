using System.ComponentModel;
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
        private readonly Mock<IDoLaterPresenter> _stubDoLater = new Mock<IDoLaterPresenter>();
        private readonly Mock<IDoNowPresenter> _stubDoNow = new Mock<IDoNowPresenter>();

        private ProcessActionPresenter BuildDefaultProcessActionPresenter()
        {
            return new ProcessActionPresenter(AnAction.Build(), _stubDoNow.Object, _stubDoLater.Object);
        }

        [Fact]
        public void DoLater__ReturnsDoLaterPresenter()
        {
            ProcessActionPresenter test = BuildDefaultProcessActionPresenter();

            Assert.Same(_stubDoLater.Object, test.DoLater);
        }

        [Fact]
        public void DoNow__ReturnsDoNowPresenter()
        {
            ProcessActionPresenter test = BuildDefaultProcessActionPresenter();

            Assert.Same(_stubDoNow.Object, test.DoNow);
        }

        [Fact]
        public void DisplayName__ReturnsActionTitle()
        {
            const string titleOfTheAction = "Title of the action";
            var test = new ProcessActionPresenter(AnAction.Called(titleOfTheAction).Build(),
                                                  _stubDoNow.Object,
                                                  _stubDoLater.Object);

            Assert.Equal(titleOfTheAction, test.DisplayName);
        }

        [Fact]
        public void DisplayName_WhenSet_SetsActionTitle()
        {
            Mock<IAction> mockAction = AnAction.Mock();
            var test = new ProcessActionPresenter(mockAction.Object,
                                                  _stubDoNow.Object,
                                                  _stubDoLater.Object);

            const string newTitle = "New title";
            test.DisplayName = newTitle;

            mockAction.VerifySet(x => x.Title = newTitle);
        }

        [Fact]
        public void DisplayName_WhenActionTitleChanges_RaisesPropertyChanged()
        {
            const string titleOfTheAction = "Title of the action";
            Mock<IAction> stubAction = AnAction.Called(titleOfTheAction).Mock();

            var test = new ProcessActionPresenter(stubAction.Object,
                                                  _stubDoNow.Object,
                                                  _stubDoLater.Object);

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DisplayName).
                When(() => stubAction.Raise(x => x.PropertyChanged += null,
                                            new PropertyChangedEventArgs("Title")));
        }
    }
}