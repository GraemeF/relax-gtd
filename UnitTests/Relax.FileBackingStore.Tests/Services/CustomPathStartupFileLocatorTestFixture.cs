using Xunit;
using Relax.FileBackingStore.Services;

namespace Relax.FileBackingStore.Tests.Services
{
    public class CustomPathStartupFileLocatorTestFixture
    {
        private const string _TestPath = @"C:\Hello";

        [Fact]
        public void Construct_GivenPath_Succeeds()
        {
            new CustomPathStartupFileLocator(_TestPath);
        }

        [Fact]
        public void Construct_GivenNull_Throws()
        {
            new CustomPathStartupFileLocator(null);
        }

        [Fact]
        public void Path_GivenPath_ReturnsPath()
        {
            var test = new CustomPathStartupFileLocator(_TestPath);
            Assert.Equal(_TestPath, test.Path);
        }

        [Fact]
        public void LoadOnStartup_WithoutBeingSet_ReturnsTrue()
        {
            var test = new CustomPathStartupFileLocator(_TestPath);
            Assert.True(test.LoadOnStartup);
        }

        [Fact]
        public void LoadOnStartup_AfterSetToFalse_ReturnsFalse()
        {
            var test = new CustomPathStartupFileLocator(_TestPath) {LoadOnStartup = false};
            Assert.False(test.LoadOnStartup);
        }
    }
}