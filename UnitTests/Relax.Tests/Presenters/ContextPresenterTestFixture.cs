using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ContextPresenterTestFixture
    {
        [Fact]
        public void Constructor__DoesNotThrow()
        {
            new ContextPresenter(new Mock<IGtdContext>().Object);
        }
    }
}