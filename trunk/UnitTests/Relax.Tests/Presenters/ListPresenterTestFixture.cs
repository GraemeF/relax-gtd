using System;
using System.Collections.ObjectModel;
using Moq;
using Relax.Presenters;
using Relax.Tests.TestEntities;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ListPresenterTestFixture
    {
        private readonly Mock<ITestItemPresenter> _stubItemPresenter = new Mock<ITestItemPresenter>();
        private readonly ObservableCollection<ITestItem> _stubModels = new ObservableCollection<ITestItem>();

        private ListPresenter<ITestItem, ITestItemPresenter> BuildDefaultListPresenter()
        {
            return new TestListPresenter(_stubModels, x => _stubItemPresenter.Object);
        }

        [Fact]
        public void Constructor_WhenThereIsAItem_OpensItemPresenter()
        {
            _stubModels.Add(new Mock<ITestItem>().Object);

            BuildDefaultListPresenter();

            _stubItemPresenter.Verify(x => x.Initialize());
        }

        [Fact]
        public void Presenters_WhenAItemIsRemovedFromTheWorkspace_ShutsDownItemPresenter()
        {
            var stubItem = new Mock<ITestItem>();
            _stubItemPresenter.Setup(x => x.Model).Returns(stubItem.Object);
            _stubModels.Add(stubItem.Object);

            ListPresenter<ITestItem, ITestItemPresenter> test = BuildDefaultListPresenter();

            _stubModels.RemoveAt(0);

            Assert.Empty(test.Presenters);
        }

        [Fact]
        public void Presenters_WhenAItemIsAddedToTheModels_OpensItemPresenter()
        {
            ListPresenter<ITestItem, ITestItemPresenter> test = BuildDefaultListPresenter();

            _stubModels.Add(new Mock<ITestItem>().Object);

            Assert.Equal(1, test.Presenters.Count);
        }

        #region Nested type: TestListPresenter

        private class TestListPresenter : ListPresenter<ITestItem, ITestItemPresenter>
        {
            public TestListPresenter(ObservableCollection<ITestItem> models, Func<ITestItem, ITestItemPresenter> func)
                : base(models, func)
            {
            }
        }

        #endregion
    }
}