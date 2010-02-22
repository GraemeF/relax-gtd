using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ActionPresenterTestFixture
    {
        [Fact]
        public void Constructor__DoesNotThrow()
        {
            new ActionPresenter(new Mock<IAction>().Object);
        }
    }
}