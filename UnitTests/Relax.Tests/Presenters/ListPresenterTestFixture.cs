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

        private static ITestItemPresenter BuildItemPresenter(ITestItem model)
        {
            var stub = new Mock<ITestItemPresenter>();
            stub.Setup(x => x.Model).Returns(model);

            return stub.Object;
        }

        [Fact]
        public void Initialize_WhenThereIsAItem_OpensItemPresenter()
        {
            _stubModels.Add(new Mock<ITestItem>().Object);

            ListPresenter<ITestItem, ITestItemPresenter> test = new TestListPresenter(_stubModels,
                                                                                      x => _stubItemPresenter.Object);
            test.Initialize();

            _stubItemPresenter.Verify(x => x.Initialize());
        }

        [Fact]
        public void Presenters_WhenAItemIsRemovedFromTheWorkspace_ShutsDownItemPresenter()
        {
            var stubItem = new Mock<ITestItem>();
            _stubItemPresenter.Setup(x => x.Model).Returns(stubItem.Object);
            _stubModels.Add(stubItem.Object);

            ListPresenter<ITestItem, ITestItemPresenter> test = new TestListPresenter(_stubModels, BuildItemPresenter);
            test.Initialize();

            _stubModels.RemoveAt(0);

            Assert.Empty(test.Presenters);
        }

        [Fact]
        public void Presenters_WhenAItemIsAddedToTheModels_OpensItemPresenter()
        {
            ListPresenter<ITestItem, ITestItemPresenter> test = new TestListPresenter(_stubModels, BuildItemPresenter);
            test.Initialize();

            _stubModels.Add(new Mock<ITestItem>().Object);

            Assert.Equal(1, test.Presenters.Count);
        }

        [Fact]
        public void Shutdown__ShutsDownItemPresenters()
        {
            ListPresenter<ITestItem, ITestItemPresenter> test = new TestListPresenter(_stubModels,
                                                                                      x => _stubItemPresenter.Object);
            test.Initialize();

            ITestItem testItem = new Mock<ITestItem>().Object;
            _stubItemPresenter.Setup(x => x.Model).Returns(testItem);
            _stubModels.Add(testItem);
            test.Shutdown();

            _stubItemPresenter.Verify(x => x.Shutdown());
        }

        [Fact]
        public void CurrentItem_Initially_ReturnsFirstItemInList()
        {
            ITestItem firstItem = new Mock<ITestItem>().Object;
            _stubModels.Add(firstItem);
            _stubModels.Add(new Mock<ITestItem>().Object);
            _stubModels.Add(new Mock<ITestItem>().Object);

            var test =
                (ListPresenter<ITestItem, ITestItemPresenter>) new TestListPresenter(_stubModels, BuildItemPresenter);
            test.Initialize();

            Assert.Same(firstItem, test.CurrentItem);
        }

        [Fact]
        public void CurrentItem_WhenThereAreNoItems_IsNull()
        {
            var test =
                (ListPresenter<ITestItem, ITestItemPresenter>) new TestListPresenter(_stubModels, BuildItemPresenter);
            test.Initialize();

            Assert.Null(test.CurrentItem);
        }

        [Fact]
        public void CurrentItem_WhenTheCurrentItemIsRemovedFromTheList_ChangesToTheNextItemInTheList()
        {
            ITestItem firstItem = new Mock<ITestItem>().Object;
            ITestItem secondItem = new Mock<ITestItem>().Object;

            _stubModels.Add(firstItem);
            _stubModels.Add(secondItem);

            var test = new TestListPresenter(_stubModels, BuildItemPresenter);
            test.Initialize();

            _stubModels.Remove(firstItem);

            Assert.Same(secondItem, test.CurrentItem);
        }

        [Fact]
        public void CurrentItem_WhenAnItemIsAddedToAnEmptyList_ChangesToTheNewItem()
        {
            var test =
                (ListPresenter<ITestItem, ITestItemPresenter>) new TestListPresenter(_stubModels, BuildItemPresenter);

            ITestItem item = new Mock<ITestItem>().Object;
            test.Initialize();

            _stubModels.Add(item);

            Assert.Same(item, test.CurrentItem);
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