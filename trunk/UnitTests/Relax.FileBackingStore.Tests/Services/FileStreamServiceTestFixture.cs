using MbUnit.Framework;
using Relax.FileBackingStore.Services;

namespace Relax.FileBackingStore.Tests.Services
{
    [TestFixture]
    public class FileStreamServiceTestFixture
    {
        [Test, ExpectedArgumentNullException]
        public void GetWriteStream_NullPath_Throws()
        {
            var test = new FileStreamService();
            test.GetWriteStream(null);
        }

        [Test, ExpectedArgumentNullException]
        public void GetReadStream_NullPath_Throws()
        {
            var test = new FileStreamService();
            test.GetReadStream(null);
        }
    }
}