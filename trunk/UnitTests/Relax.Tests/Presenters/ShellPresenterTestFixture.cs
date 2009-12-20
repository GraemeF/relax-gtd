using Autofac;
using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ShellPresenterTestFixture
    {
        [Test]
        public void Initialize__InitializesBackingStore()
        {
            var mockBackingStore = new Mock<IBackingStore>();
            var test = new ShellPresenter(new Mock<IContainer>().Object, mockBackingStore.Object);

            test.Initialize();

            mockBackingStore.Verify(x => x.Initialize());
        }
    }
}