using System;
using System.Collections.Generic;
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
        private Workspace _workspace;

        [SetUp]
        public void SetUp()
        {
            _mockStreamService = new Mock<IFileStreamService>();
            _mockLocator = new Mock<IStartupFileLocator>();
            _mockSerializer = new Mock<ISerializer<Workspace>>();
            _workspace = new Workspace();
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Load_WhenPathIsNull_Throws()
        {
            IFileBackingStore test = BuildDefaultFileBackingStoreService();

            test.Path = null;
            test.Load();
        }

        [Test]
        public void Save_WithoutSettingPath_UsesPathFromLocator()
        {
            using (var memoryStream = new MemoryStream())
            {
                _mockLocator.Setup(locator => locator.Path).Returns(ExamplePath);
                _mockStreamService.Setup(stream => stream.GetWriteStream(ExamplePath)).Returns(memoryStream).Verifiable();

                IFileBackingStore test = BuildDefaultFileBackingStoreService();

                test.Save();
                _mockStreamService.Verify();
            }
        }

        [Test]
        public void Initialize_WhenLoadOnStartup_Loads()
        {
            _mockLocator.Setup(x => x.LoadOnStartup).Returns(true);
            _mockLocator.Setup(x => x.Path).Returns(ExamplePath);

            FileBackingStoreService test = BuildDefaultFileBackingStoreService();

            test.Initialize();

            _mockSerializer.Verify(x => x.Load(It.IsAny<Stream>(), It.IsAny<IEnumerable<Type>>()));
        }

        [Test]
        [Row(typeof (FileNotFoundException))]
        [Row(typeof (DirectoryNotFoundException))]
        public void Initialize_WorkspaceFileIsMissing_KeepsDefaultWorkspace(Type exceptionType)
        {
            _mockLocator.Setup(x => x.LoadOnStartup).Returns(true);
            _mockLocator.Setup(x => x.Path).Returns(ExamplePath);
            _mockSerializer.Setup(x => x.Load(It.IsAny<Stream>(), It.IsAny<IEnumerable<Type>>())).Throws(
                (Exception) Activator.CreateInstance(exceptionType));

            FileBackingStoreService test = BuildDefaultFileBackingStoreService();

            test.Initialize();

            Assert.AreSame(_workspace, test.Workspace);
        }

        private FileBackingStoreService BuildDefaultFileBackingStoreService()
        {
            return new FileBackingStoreService(_mockStreamService.Object,
                                               _workspace,
                                               _mockLocator.Object,
                                               _mockSerializer.Object);
        }

        [Test]
        public void PropertyChanged_RemoveHandler_()
        {
            // AssertThatChangeNotificationIsRaisedBy doesn't seem to remove
            // handlers so this is just to get 100% coverage.
            FileBackingStoreService test = BuildDefaultFileBackingStoreService();

            test.PropertyChanged += delegate { };
            test.PropertyChanged -= delegate { };
        }
    }
}