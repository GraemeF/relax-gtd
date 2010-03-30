using System;
using System.Collections.ObjectModel;
using Caliburn.Testability.Extensions;
using Moq;
using Relax.Presenters;
using Relax.Tests.TestEntities;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class SingleItemSelectorTestFixture
    {
        private readonly ObservableCollection<ITestItem> _stubModels = new ObservableCollection<ITestItem>();

        private static ITestItemPresenter BuildItemPresenter(ITestItem model)
        {
            var stub = new Mock<ITestItemPresenter>();
            stub.Setup(x => x.Model).Returns(model);

            return stub.Object;
        }

        [Fact]
        public void GettingSelectedItem_Initially_ReturnsFirstItemInList()
        {
            ITestItem firstItem = new Mock<ITestItem>().Object;
            _stubModels.Add(firstItem);
            _stubModels.Add(new Mock<ITestItem>().Object);
            _stubModels.Add(new Mock<ITestItem>().Object);

            var test = new TestSingleItemSelector(_stubModels, BuildItemPresenter);
            test.Initialize();

            Assert.Same(firstItem, test.SelectedItem);
        }

        [Fact]
        public void GettingSelectedItem_WhenThereAreNoItems_IsNull()
        {
            var test = new TestSingleItemSelector(_stubModels, BuildItemPresenter);
            test.Initialize();

            Assert.Null(test.SelectedItem);
        }

        [Fact]
        public void GettingSelectedItem_WhenTheSelectedItemIsRemovedFromTheList_ChangesToTheNextItemInTheList()
        {
            ITestItem firstItem = new Mock<ITestItem>().Object;
            ITestItem secondItem = new Mock<ITestItem>().Object;

            _stubModels.Add(firstItem);
            _stubModels.Add(secondItem);

            var test = new TestSingleItemSelector(_stubModels, BuildItemPresenter);
            test.Initialize();

            _stubModels.Remove(firstItem);

            Assert.Same(secondItem, test.SelectedItem);
        }

        [Fact]
        public void GettingSelectedItem_WhenAnItemIsAddedToAnEmptyList_ChangesToTheNewItem()
        {
            var test = new TestSingleItemSelector(_stubModels, BuildItemPresenter);

            ITestItem item = new Mock<ITestItem>().Object;
            test.Initialize();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.SelectedItem)
                .When(() => _stubModels.Add(item));

            Assert.Same(item, test.SelectedItem);
        }

        [Fact]
        public void SettingSelectedItem_ToAModelInTheList_UpdatesSelectedItem()
        {
            _stubModels.Add(new Mock<ITestItem>().Object);

            ITestItem item = new Mock<ITestItem>().Object;
            _stubModels.Add(item);

            var test = new TestSingleItemSelector(_stubModels, BuildItemPresenter);
            test.Initialize();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.SelectedItem)
                .When(() => test.SelectedItem = item);

            Assert.Same(item, test.SelectedItem);
        }

        #region Nested type: TestSingleItemSelector

        private class TestSingleItemSelector : SingleItemSelector<ITestItem, ITestItemPresenter>
        {
            public TestSingleItemSelector(ObservableCollection<ITestItem> models,
                                          Func<ITestItem, ITestItemPresenter> func)
                : base(models, func)
            {
            }
        }

        #endregion
    }
}