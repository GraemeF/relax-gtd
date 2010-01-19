using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using MbUnit.Framework;
using Moq;
using Relax.Presenters;
using Relax.Tests.TestEntities;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ListPresenterTestFixture
    {
        private Mock<ITestItemPresenter> _stubItemPresenter;
        private ObservableCollection<ITestItem> _stubModels;

        [SetUp]
        public void SetUp()
        {
            _stubModels = new ObservableCollection<ITestItem>();
            _stubItemPresenter = new Mock<ITestItemPresenter>();
        }

        private ListPresenter<ITestItem, ITestItemPresenter> BuildDefaultListPresenter()
        {
            return new TestListPresenter(_stubModels, x => _stubItemPresenter.Object);
        }

        [Test]
        public void Constructor_WhenThereIsAItem_OpensItemPresenter()
        {
            _stubModels.Add(new Mock<ITestItem>().Object);

            BuildDefaultListPresenter();

            _stubItemPresenter.Verify(x => x.Initialize());
        }

        [Test]
        public void Presenters_WhenAItemIsRemovedFromTheWorkspace_ShutsDownItemPresenter()
        {
            var stubItem = new Mock<ITestItem>();
            _stubItemPresenter.Setup(x => x.Model).Returns(stubItem.Object);
            _stubModels.Add(stubItem.Object);

            ListPresenter<ITestItem, ITestItemPresenter> test = BuildDefaultListPresenter();

            _stubModels.RemoveAt(0);

            Assert.IsEmpty(test.Presenters);
        }

        [Test]
        public void Presenters_WhenAItemIsAddedToTheModels_OpensItemPresenter()
        {
            ListPresenter<ITestItem, ITestItemPresenter> test = BuildDefaultListPresenter();

            _stubModels.Add(new Mock<ITestItem>().Object);

            Assert.AreEqual(1, test.Presenters.Count);
        }

        #region Nested type: TestListPresenter

        private class TestListPresenter : ListPresenter<ITestItem, ITestItemPresenter>
        {
            public TestListPresenter(ObservableCollection<ITestItem> models, Func<ITestItem, ITestItemPresenter> func)
                : base(CollectionViewSource.GetDefaultView(models), func)
            {
            }
        }

        #endregion
    }
}