using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ActionPresenterTestFixture
    {
        private const string TestTitle = "Test Title";

        [Test]
        public void DisplayNameGet__ReturnsModelTitle()
        {
            var stubAction = new Mock<IAction>();
            stubAction.Setup(x => x.Title).Returns(TestTitle);

            var test = new ActionPresenter(stubAction.Object);

            Assert.AreEqual(TestTitle, test.DisplayName);
        }

        [Test]
        public void DisplayNameSet__UpdatesModelTitle()
        {
            var mockAction = new Mock<IAction>();

            new ActionPresenter(mockAction.Object) {DisplayName = TestTitle};

            mockAction.VerifySet(x => x.Title = TestTitle);
        }

        [Test]
        public void AllProperties_WhenChanged_RaisePropertyChanged()
        {
            var test = new ActionPresenter(new Mock<IAction>().Object);
            test.AssertThatAllProperties().Ignoring(x => x.DisplayName).RaiseChangeNotification();
        }
    }
}