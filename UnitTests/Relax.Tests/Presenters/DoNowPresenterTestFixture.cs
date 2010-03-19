using System;
using Caliburn.PresentationFramework.ApplicationModel;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class DoNowPresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void Apply__MarksActionAsCompleted()
        {
            DateTime timeAtStart = DateTime.UtcNow;
            Mock<IAction> mockAction = AnAction.Mock();
            var test = new DoNowPresenter(mockAction.Object) {Parent = new Mock<IPresenterHost>().Object};

            test.Apply();

            mockAction.VerifySet(x => x.CompletedDate = It.IsInRange(timeAtStart, DateTime.UtcNow, Range.Inclusive));
        }

        [Fact]
        public void Apply__ShutsDownPresenter()
        {
            var mockParent = new Mock<IPresenterHost>();
            var test = new DoNowPresenter(AnAction.Build()) {Parent = mockParent.Object};

            test.Apply();

            mockParent.Verify(x => x.Shutdown(test, It.IsAny<Action<bool>>()));
        }
    }
}