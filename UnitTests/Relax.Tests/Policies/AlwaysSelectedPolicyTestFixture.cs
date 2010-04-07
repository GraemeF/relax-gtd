using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;
using Moq;
using Relax.Policies;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Policies
{
    public class AlwaysSelectedPolicyTestFixture
    {
        [Fact]
        public void ModifySelectedItem_GivenNull_ReturnsFirstItemFromSelector()
        {
            var stubSelector = new Mock<ISingleSelector<object>>();
            var stubFirstPresenter = new Mock<IModelPresenter<object>>();
            var firstItem = new object();

            stubFirstPresenter.Setup(x => x.Model).Returns(firstItem);
            stubSelector.Setup(x => x.Presenters).Returns(new BindableCollection<IPresenter> {stubFirstPresenter.Object});

            var test = new AlwaysSelectedPolicy();

            Assert.Same(firstItem, test.ModifySelectedItem(stubSelector.Object, null));
        }

        [Fact]
        public void ModifySelectedItem_GivenItem_ReturnsItem()
        {
            var test = new AlwaysSelectedPolicy();
            var item = new object();
            Assert.Same(item, test.ModifySelectedItem(new Mock<ISingleSelector<object>>().Object, item));
        }
    }
}