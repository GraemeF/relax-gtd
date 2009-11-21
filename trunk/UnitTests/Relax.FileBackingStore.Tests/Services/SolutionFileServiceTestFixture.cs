using System.IO;
using MbUnit.Framework;
using Moq;
using Relax.Domain.Models;
using Relax.FileBackingStore.Services;
using Relax.FileBackingStore.Services.Interfaces;

namespace Relax.FileBackingStore.Tests.Services
{
    [TestFixture]
    public class FileBackingStoreServiceTestFixture
    {
        private const string ExamplePath = @"C:\Some\Path\To\File.xml";
        private Mock<IStartupFileLocator> _mockLocator;
        private Mock<ISerializer<Workspace>> _mockSerializer;
        private Mock<IFileStreamService> _mockStreamService;

        [SetUp]
        public void SetUp()
        {
            _mockStreamService = new Mock<IFileStreamService>();
            _mockLocator = new Mock<IStartupFileLocator>();
            _mockSerializer = new Mock<ISerializer<Workspace>>();
        }

        [Test]
        public void Save_WithoutSettingPath_UsesPathFromLocator()
        {
            using (var memoryStream = new MemoryStream())
            {
                _mockLocator.Setup(locator => locator.Path).Returns(ExamplePath);
                _mockStreamService.Setup(stream => stream.GetWriteStream(ExamplePath)).Returns(memoryStream).Verifiable();

                IFileBackingStore fileStore = new FileBackingStoreService(_mockStreamService.Object,
                                                                          new Workspace(),
                                                                          _mockLocator.Object,
                                                                          _mockSerializer.Object);

                fileStore.Save();
                _mockStreamService.Verify();
            }
        }
    }
}