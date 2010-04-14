using System;
using System.Collections.ObjectModel;
using Caliburn.Testability.Extensions;
using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
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
        public void GettingSelectedItem_Initially_ReturnsItemFromSelectionPolicy()
        {
            ITestItem firstItem = new Mock<ITestItem>().Object;
            _stubModels.Add(firstItem);
            _stubModels.Add(new Mock<ITestItem>().Object);
            _stubModels.Add(new Mock<ITestItem>().Object);

            _fakeSelectionPolicy.
                Setup(x => x.ModifySelectedItem(It.IsAny<TestSingleItemSelector>(), null)).
                Returns(firstItem).
                Verifiable();

            TestSingleItemSelector test = BuildTestSubject();
            test.Initialize();

            Assert.Same(firstItem, test.SelectedItem);
            _fakeSelectionPolicy.VerifyAll();
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

        [Fact]
        public void GettingSelectedItem_AfterSelectedItemIsRemovedFromTheList_ReturnsTheItemSuppliedByTheSelectionPolicy
            ()
        {
            ITestItem firstItem = new Mock<ITestItem>().Object;
            ITestItem secondItem = new Mock<ITestItem>().Object;

            _stubModels.Add(firstItem);
            _stubModels.Add(secondItem);

            TestSingleItemSelector test = BuildTestSubject();

            _fakeSelectionPolicy.
                Setup(x => x.ModifySelectedItem(test, firstItem)).
                Returns(firstItem);
            _fakeSelectionPolicy.
                Setup(x => x.ModifySelectedItem(test, null)).
                Returns(firstItem);

            test.Initialize();

            _fakeSelectionPolicy.
                Setup(x => x.ModifySelectedItem(test, null)).
                Returns(secondItem);

            _stubModels.Remove(firstItem);

            Assert.Same(secondItem, test.SelectedItem);
        }

        [Fact]
        public void GettingSelectedItem_WhenAnItemIsAddedToAnEmptyList_ChangesToTheItemGivenByPolicy()
        {
            TestSingleItemSelector test = BuildTestSubject();

            ITestItem item = new Mock<ITestItem>().Object;
            test.Initialize();

            _fakeSelectionPolicy.
                Setup(x => x.ModifySelectedItem(test, (ITestItem) null)).
                Returns(item);

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