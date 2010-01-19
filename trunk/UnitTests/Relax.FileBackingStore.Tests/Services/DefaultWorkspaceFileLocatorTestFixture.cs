using MbUnit.Framework;
using Relax.FileBackingStore.Services;

namespace Relax.FileBackingStore.Tests.Services
{
    [TestFixture]
    public class DefaultWorkspaceFileLocatorTestFixture
    {
        [Test]
        public void Path__ReturnsCorrectPathToWorkspace()
        {
            var test = new DefaultWorkspaceFileLocator();

            Assert.AreEqual(DefaultWorkspaceFileLocator.DefaultBackingStorePath, test.Path);
        }

        [Test]
        public void LoadOnStartup__ReturnsTrue()
        {
            Assert.IsTrue(new DefaultWorkspaceFileLocator().LoadOnStartup);
        }
    }
}