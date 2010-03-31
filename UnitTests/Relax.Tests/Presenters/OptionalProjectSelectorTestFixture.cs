using Moq;
using Relax.Domain.Filters.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class OptionalProjectSelectorTestFixture : TestDataBuilder
    {
        private readonly Mock<IActionTreeNodePresenter> _stubProjectPresenter = new Mock<IActionTreeNodePresenter>();

        private OptionalProjectSelector BuildTestSubject()
        {
            return new OptionalProjectSelector(new Mock<IProjectsFilter>().Object,
                                               x => _stubProjectPresenter.Object,
                                               new AllowNullSelectionPolicy());
        }

        [Fact]
        public void GettingSelectedItem_Initially_ReturnsNull()
        {
            OptionalProjectSelector test = BuildTestSubject();

            Assert.Null(test.SelectedItem);
        }

        [Fact]
        public void SettingSelectedItem_ToNullWhenThereIsASelectedItem_UpdatesSelectedItem()
        {
            OptionalProjectSelector test = BuildTestSubject();

            Assert.Null(test.SelectedItem);
        }
    }
}