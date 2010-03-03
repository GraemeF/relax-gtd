using Caliburn.Testability.Extensions;
using Moq;
using Relax.Tests.TestEntities;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ItemPresenterTestFixture
    {
        private const string TestTitle = "Test Title";

        [Fact]
        public void DisplayNameGet__ReturnsModelTitle()
        {
            var stubTestItem = new Mock<ITestItem>();
            stubTestItem.Setup(x => x.Title).Returns(TestTitle);

            var test = new TestItemPresenter(stubTestItem.Object);

            Assert.Equal(TestTitle, test.DisplayName);
        }

        [Fact]
        public void DisplayNameSet__UpdatesModelTitle()
        {
            var stubTestItem = new Mock<ITestItem>();

            new TestItemPresenter(stubTestItem.Object) {DisplayName = TestTitle};

            stubTestItem.VerifySet(x => x.Title = TestTitle);
        }

        [Fact]
        public void Rename__SetsReadOnlyToFalse()
        {
            var test = new TestItemPresenter(new Mock<ITestItem>().Object);

            test.Rename();

            Assert.False(test.IsReadOnly);
        }

        [Fact]
        public void FinishRename__SetsReadOnlyToTrue()
        {
            var test = new TestItemPresenter(new Mock<ITestItem>().Object);

            test.Rename();
            test.FinishRename();

            Assert.True(test.IsReadOnly);
        }

        [Fact]
        public void AllProperties_WhenChanged_RaisePropertyChanged()
        {
            var test = new TestItemPresenter(new Mock<ITestItem>().Object);
            test.AssertThatAllProperties().Ignoring(x => x.Model).Ignoring(x => x.DisplayName).RaiseChangeNotification();
        }
    }
}