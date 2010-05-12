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

            Assert.Contains(_stubItemPresenter.Object, test.Screens);
        }

        [Fact]
        public void GettingScreens_WhenTheLastModelIsRemoved_IsEmpty()
        {
            var stubItem = new Mock<ITestItem>();
            _stubItemPresenter.Setup(x => x.Model).Returns(stubItem.Object);
            _stubModels.Add(stubItem.Object);

            ListPresenter<ITestItem, ITestItemPresenter> test = new TestListPresenter(_stubModels, BuildItemPresenter);
            test.Initialize();

            _stubModels.RemoveAt(0);

            Assert.Empty(test.Screens);
        }

        [Fact]
        public void GettingPresenters_WhenAModelIsAdded_ContainsOnePresenter()
        {
            ListPresenter<ITestItem, ITestItemPresenter> test = new TestListPresenter(_stubModels, BuildItemPresenter);
            test.Initialize();

            _stubModels.Add(new Mock<ITestItem>().Object);

            Assert.Equal(1, test.Screens.Count);
        }

        [Fact]
        public void GettingScreens_WhenTheModelsListIsCleared_IsEmpty()
        {
            var models = new ObservableCollection<ITestItem> {new Mock<ITestItem>().Object};

            ListPresenter<ITestItem, ITestItemPresenter> test = new TestListPresenter(models, BuildItemPresenter);
            test.Initialize();

            models.Clear();

            Assert.Equal(0, test.Screens.Count);
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

        private class TestListPresenter : ListPresenter<ITestItem, ITestItemPresenter>
        {
            public TestListPresenter(ObservableCollection<ITestItem> models, Func<ITestItem, ITestItemPresenter> func)
                : base(models, func)
            {
            }
        }
    }
}