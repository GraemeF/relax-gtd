using System;
using Relax.FileBackingStore.Services;
using Xunit;

namespace Relax.FileBackingStore.Tests.Services
{
    public class FileStreamServiceTestFixture
    {
        [Fact]
        public void GetWriteStream_NullPath_Throws()
        {
            var test = new FileStreamService();
            Assert.Throws(typeof (ArgumentNullException), () => test.GetWriteStream(null));
        }

        [Fact]
        public void GetReadStream_NullPath_Throws()
        {
            var test = new FileStreamService();
            Assert.Throws(typeof (ArgumentNullException), () => test.GetReadStream(null));
        }
    }
}