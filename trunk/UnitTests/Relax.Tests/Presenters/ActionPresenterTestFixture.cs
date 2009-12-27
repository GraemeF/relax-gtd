using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ActionPresenterTestFixture
    {
        [Test]
        public void Constructor__DoesNotThrow()
        {
            new ActionPresenter(new Mock<IAction>().Object);
        }
    }
}