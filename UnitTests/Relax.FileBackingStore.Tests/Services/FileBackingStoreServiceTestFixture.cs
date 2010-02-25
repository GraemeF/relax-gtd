using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using Relax.Domain.Models;
using Relax.FileBackingStore.Services;
using Relax.FileBackingStore.Services.Interfaces;
using Relax.TestDataBuilders;
using Xunit;
using Xunit.Extensions;

namespace Relax.FileBackingStore.Tests.Services
{
    public class FileBackingStoreServiceTestFixture : TestDataBuilder
    {
        private const string ExamplePath = @"C:\Some\Path\To\File.xml";
        private readonly Mock<IStartupFileLocator> _mockLocator = new Mock<IStartupFileLocator>();
        private readonly Mock<ISerializer<Workspace>> _mockSerializer = new Mock<ISerializer<Workspace>>();
        private readonly Mock<IFileStreamService> _mockStreamService = new Mock<IFileStreamService>();
        private readonly Workspace _workspace = new Workspace(new ActionQueue());

        [Fact]
        public void Load_WhenPathIsNull_Throws()
        {
            IFileBackingStore test = BuildDefaultFileBackingStoreService();

            test.Path = null;
            Assert.Throws(typeof (InvalidOperationException), () => test.Load());
        }

        [Fact]
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

        [Fact]
        public void Initialize_WhenLoadOnStartup_Loads()
        {
            _mockLocator.Setup(x => x.LoadOnStartup).Returns(true);
            _mockLocator.Setup(x => x.Path).Returns(ExamplePath);

            FileBackingStoreService test = BuildDefaultFileBackingStoreService();

            test.Initialize();

            _mockSerializer.Verify(x => x.Load(It.IsAny<Stream>(), It.IsAny<IEnumerable<Type>>()));
        }

        [Theory]
        [InlineData(typeof (FileNotFoundException))]
        [InlineData(typeof (DirectoryNotFoundException))]
        public void Initialize_WorkspaceFileIsMissing_KeepsDefaultWorkspace(Type exceptionType)
        {
            _mockLocator.Setup(x => x.LoadOnStartup).Returns(true);
            _mockLocator.Setup(x => x.Path).Returns(ExamplePath);
            _mockSerializer.Setup(x => x.Load(It.IsAny<Stream>(), It.IsAny<IEnumerable<Type>>())).Throws(
                (Exception) Activator.CreateInstance(exceptionType));

            FileBackingStoreService test = BuildDefaultFileBackingStoreService();

            test.Initialize();

            Assert.Same(_workspace, test.Workspace);
        }

        private FileBackingStoreService BuildDefaultFileBackingStoreService()
        {
            return new FileBackingStoreService(_mockStreamService.Object,
                                               _workspace,
                                               _mockLocator.Object,
                                               _mockSerializer.Object);
        }

        [Fact]
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