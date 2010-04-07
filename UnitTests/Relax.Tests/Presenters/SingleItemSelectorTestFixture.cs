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
        private readonly Mock<ISelectionPolicy> _fakeSelectionPolicy = new Mock<ISelectionPolicy>();
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
            return new TestSingleItemSelector(_stubModels, BuildItemPresenter, _fakeSelectionPolicy.Object);
        }

        [Fact]
        public void GettingSelectedItem_WhenThereAreNoItems_IsNull()
        {
            TestSingleItemSelector test = BuildTestSubject();
            test.Initialize();

            Assert.Null(test.SelectedItem);
        }

        [Fact]
        public void GettingSelectedItem_AfterSelectionHasChanged_ReturnsTheItemSuppliedByTheSelectionPolicy()
        {
            ITestItem firstItem = new Mock<ITestItem>().Object;

            _stubModels.Add(firstItem);

            TestSingleItemSelector test = BuildTestSubject();
            test.Initialize();

            _fakeSelectionPolicy.
                Setup(x => x.ModifySelectedItem(test, null)).
                Returns(firstItem);

            test.SelectedItem = null;

            Assert.Same(firstItem, test.SelectedItem);
        }

        [Fact(Skip = "Shouldn't be using the active presenter for this.")]
        public void GettingSelectedItem_AfterSelectedItemIsRemovedFromTheList_ReturnsTheItemSuppliedByTheSelectionPolicy
            ()
        {
            ITestItem firstItem = new Mock<ITestItem>().Object;

            _stubModels.Add(firstItem);

            TestSingleItemSelector test = BuildTestSubject();
            test.Initialize();

            test.SelectedItem = firstItem;

            _fakeSelectionPolicy.
                Setup(x => x.ModifySelectedItem(test, null)).
                Returns((ITestItem) null).
                Verifiable();

            _stubModels.Remove(firstItem);

            Assert.Same(null, test.SelectedItem);
            _fakeSelectionPolicy.VerifyAll();
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