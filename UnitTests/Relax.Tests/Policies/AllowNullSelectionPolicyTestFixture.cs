using Moq;
using Relax.Policies;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Policies
{
    public class AllowNullSelectionPolicyTestFixture
    {
        [Fact]
        public void ModifySelectedItem_GivenNull_ReturnsNull()
        {
            var test = new AllowNullSelectionPolicy();
            Assert.Null(test.ModifySelectedItem(new Mock<ISingleSelector<object>>().Object, null));
        }

        [Fact]
        public void ModifySelectedItem_GivenItem_ReturnsItem()
        {
            var test = new AllowNullSelectionPolicy();
            var item = new object();
            Assert.Same(item, test.ModifySelectedItem(new Mock<ISingleSelector<object>>().Object, item));
        }
    }
}