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
        private readonly ISelectionPolicy _selectionPolicy = new Mock<ISelectionPolicy>().Object;
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

            TestSingleItemSelector test = BuildTestSubject();
            test.Initialize();

            Assert.Same(firstItem, test.SelectedItem);
        }

        private TestSingleItemSelector BuildTestSubject()
        {
            return new TestSingleItemSelector(_stubModels, BuildItemPresenter, _selectionPolicy);
        }

        [Fact]
        public void GettingSelectedItem_WhenThereAreNoItems_IsNull()
        {
            TestSingleItemSelector test = BuildTestSubject();
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

            TestSingleItemSelector test = BuildTestSubject();
            test.Initialize();

            _stubModels.Remove(firstItem);

            Assert.Same(secondItem, test.SelectedItem);
        }

        [Fact]
        public void GettingSelectedItem_WhenAnItemIsAddedToAnEmptyList_ChangesToTheNewItem()
        {
            TestSingleItemSelector test = BuildTestSubject();

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

            TestSingleItemSelector test = BuildTestSubject();
            test.Initialize();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.SelectedItem)
                .When(() => test.SelectedItem = item);

            Assert.Same(item, test.SelectedItem);
        }

        #region Nested type: TestSingleItemSelector

        private class TestSingleItemSelector : SingleItemSelector<ITestItem, ITestItemPresenter>
        {
            public TestSingleItemSelector(ObservableCollection<ITestItem> models,
                                          Func<ITestItem, ITestItemPresenter> func,
                                          ISelectionPolicy selectionPolicy)
                : base(models, func, selectionPolicy)
            {
            }
        }

        #endregion
    }
}