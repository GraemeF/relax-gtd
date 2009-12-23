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
        private const string testTitle = "Test Title";

        [Test]
        public void DisplayNameGet__ReturnsModelDisplayName()
        {
            var stubAction = new Mock<IAction>();
            stubAction.Setup(x => x.Title).Returns(testTitle);
            
            var test = new ActionPresenter(stubAction.Object);

            Assert.AreEqual(testTitle, test.DisplayName);
        }

        [Test]
        public void AllProperties_WhenChanged_RaisePropertyChanged()
        {
            var test = new ActionPresenter(new Mock<IAction>().Object);
            test.AssertThatAllProperties().RaiseChangeNotification();
        }
    }
}