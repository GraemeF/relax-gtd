using Relax.FileBackingStore.Services;
using Xunit;

namespace Relax.FileBackingStore.Tests.Services
{
    public class DefaultWorkspaceFileLocatorTestFixture
    {
        [Fact]
        public void Path__ReturnsCorrectPathToWorkspace()
        {
            var test = new DefaultWorkspaceFileLocator();

            Assert.Equal(DefaultWorkspaceFileLocator.DefaultBackingStorePath, test.Path);
        }

        [Fact]
        public void LoadOnStartup__ReturnsTrue()
        {
            Assert.True(new DefaultWorkspaceFileLocator().LoadOnStartup);
        }
    }
}