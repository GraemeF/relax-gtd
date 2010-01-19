using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ContextPresenterTestFixture
    {
        [Test]
        public void Constructor__DoesNotThrow()
        {
            new ContextPresenter(new Mock<IGtdContext>().Object);
        }
    }
}