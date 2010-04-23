using Relax.Commands;
using Relax.Presenters;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class DoNowPresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void GettingDisplayName__ReturnsDoNow()
        {
            var test = new DoNowPresenter(null);

            Assert.Equal("Now", test.DisplayName);
        }

        [Fact]
        public void SettingDisplayName__DoesNothing()
        {
            DoNowPresenter test = new DoNowPresenter(null);

            string originalName = test.DisplayName;
            test.DisplayName = "Another name";

            Assert.Equal(originalName, test.DisplayName);
        }

        [Fact]
        public void GettingApplyCommand__ReturnsDoNowCommand()
        {
            var doNowCommand = new DoNowCommand();

            var test = new DoNowPresenter(doNowCommand);

            Assert.Same(doNowCommand, test.ApplyCommand);
        }
    }
}