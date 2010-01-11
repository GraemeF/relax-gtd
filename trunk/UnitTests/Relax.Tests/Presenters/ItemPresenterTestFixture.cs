using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Moq;
using Relax.Tests.TestEntities;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ItemPresenterTestFixture
    {
        private const string TestTitle = "Test Title";

        [Test]
        public void DisplayNameGet__ReturnsModelTitle()
        {
            var stubTestItem = new Mock<ITestItem>();
            stubTestItem.Setup(x => x.Title).Returns(TestTitle);

            var test = new TestItemPresenter(stubTestItem.Object);

            Assert.AreEqual(TestTitle, test.DisplayName);
        }

        [Test]
        public void DisplayNameSet__UpdatesModelTitle()
        {
            var stubTestItem = new Mock<ITestItem>();

            new TestItemPresenter(stubTestItem.Object) {DisplayName = TestTitle};

            stubTestItem.VerifySet(x => x.Title = TestTitle);
        }

        [Test]
        public void Rename__SetsReadOnlyToFalse()
        {
            var test = new TestItemPresenter(new Mock<ITestItem>().Object);

            test.Rename();

            Assert.IsFalse(test.IsReadOnly);
        }

        [Test]
        public void FinishRename__SetsReadOnlyToTrue()
        {
            var test = new TestItemPresenter(new Mock<ITestItem>().Object);

            test.Rename();
            test.FinishRename();

            Assert.IsTrue(test.IsReadOnly);
        }

        [Test]
        public void AllProperties_WhenChanged_RaisePropertyChanged()
        {
            var test = new TestItemPresenter(new Mock<ITestItem>().Object);
            test.AssertThatAllProperties().Ignoring(x => x.Model).Ignoring(x => x.DisplayName).RaiseChangeNotification();
        }
    }
}