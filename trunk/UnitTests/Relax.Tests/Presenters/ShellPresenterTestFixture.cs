using Autofac;
using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters;
using Relax.TestDataBuilders;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ShellPresenterTestFixture : TestDataBuilder
    {
        private Mock<IBackingStore> _fakeBackingStore;
        private Mock<IContainer> _stubContainer;

        [SetUp]
        public void Setup()
        {
            _fakeBackingStore = new Mock<IBackingStore>();
            _stubContainer = new Mock<IContainer>();

            _fakeBackingStore.Setup(x => x.Workspace).Returns(AWorkspace.Build());
        }

        private ShellPresenter BuildDefaultShellPresenter()
        {
            return new ShellPresenter(_stubContainer.Object, _fakeBackingStore.Object);
        }

        [Test]
        public void Initialize__InitializesBackingStore()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            test.Initialize();

            _fakeBackingStore.Verify(x => x.Initialize());
        }

        [Test]
        public void Save__SavesToBackingStore()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            test.Save();

            _fakeBackingStore.Verify(x => x.Save());
        }
    }
}