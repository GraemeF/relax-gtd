using Autofac;
using Moq;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ShellPresenterTestFixture : TestDataBuilder
    {
        private readonly Mock<IBackingStore> _fakeBackingStore;
        private readonly Mock<IContainer> _stubContainer;

        public ShellPresenterTestFixture()
        {
            _fakeBackingStore = new Mock<IBackingStore>();
            _stubContainer = new Mock<IContainer>();

            _fakeBackingStore.Setup(x => x.Workspace).Returns(AWorkspace.Build());
        }

        private ShellPresenter BuildDefaultShellPresenter()
        {
            return new ShellPresenter(_stubContainer.Object, _fakeBackingStore.Object);
        }

        [Fact]
        public void Initialize__InitializesBackingStore()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            test.Initialize();

            _fakeBackingStore.Verify(x => x.Initialize());
        }

        [Fact]
        public void Save__SavesToBackingStore()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            test.Save();

            _fakeBackingStore.Verify(x => x.Save());
        }
    }
}