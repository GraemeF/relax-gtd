using Moq;
using Relax.Commands;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Commands
{
    public class DoLaterCommandTestFixture : TestDataBuilder
    {
        [Fact]
        public void Execute__()
        {
            Mock<IAction> mockAction = AnAction.Mock();

            var test = new DoLaterCommand();
            test.Execute(mockAction.Object);
        }
    }
}