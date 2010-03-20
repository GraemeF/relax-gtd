using Relax.Presenters;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class DoNowPresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void GettingApplyCommand__ReturnsDoNowCommand()
        {
            var doNowCommand = new DoNowCommand();
            
            var test = new DoNowPresenter(doNowCommand);

            Assert.Same(doNowCommand, test.ApplyCommand);
        }
    }
}