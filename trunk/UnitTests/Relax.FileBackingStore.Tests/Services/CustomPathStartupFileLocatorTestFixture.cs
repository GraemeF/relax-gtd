using MbUnit.Framework;
using Relax.FileBackingStore.Services;

namespace Relax.FileBackingStore.Tests.Services
{
    [TestFixture]
    public class CustomPathStartupFileLocatorTestFixture
    {
        private const string _TestPath = @"C:\Hello";

        [Test]
        public void Construct_GivenPath_Succeeds()
        {
            new CustomPathStartupFileLocator(_TestPath);
        }

        [Test]
        public void Construct_GivenNull_Throws()
        {
            new CustomPathStartupFileLocator(null);
        }

        [Test]
        public void Path_GivenPath_ReturnsPath()
        {
            var test = new CustomPathStartupFileLocator(_TestPath);
            Assert.AreEqual(_TestPath, test.Path);
        }

        [Test]
        public void LoadOnStartup_WithoutBeingSet_ReturnsTrue()
        {
            var test = new CustomPathStartupFileLocator(_TestPath);
            Assert.IsTrue(test.LoadOnStartup);
        }

        [Test]
        public void LoadOnStartup_AfterSetToFalse_ReturnsFalse()
        {
            var test = new CustomPathStartupFileLocator(_TestPath) {LoadOnStartup = false};
            Assert.IsFalse(test.LoadOnStartup);
        }
    }
}