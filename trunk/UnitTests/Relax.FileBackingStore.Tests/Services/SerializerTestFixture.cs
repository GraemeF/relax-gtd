using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Relax.FileBackingStore.Services;
using Relax.FileBackingStore.Services.Interfaces;
using Xunit;

namespace Relax.FileBackingStore.Tests.Services
{
    public class SerializerTestFixture
    {
        private static readonly IEnumerable<Type> KnownTypes = new[] {typeof (TestModel), typeof (int), typeof (string)};

        [Fact]
        public void Save_GivenStream_WritesSomething()
        {
            ISerializer<TestModel> fileStore = new Serializer<TestModel>();
            using (var stream = new MemoryStream())
            {
                fileStore.Save(stream, new TestModel(), KnownTypes);

                Assert.True(stream.Position> 0L, "The file written to should not be empty.");
            }
        }

        [Fact]
        public void Load_GivenSerializedSolutionModel_MatchesSaved()
        {
            var savedModel = new TestModel {TestInt = 5, TestString = "hello"};
            TestModel loadedModel;

            ISerializer<TestModel> test = new Serializer<TestModel>();

            using (var stream = new MemoryStream())
            {
                test.Save(stream, savedModel, KnownTypes);
                stream.Seek(0L, SeekOrigin.Begin);
                loadedModel = test.Load(stream, KnownTypes);
            }

            Assert.NotSame(savedModel, loadedModel);
            Assert.Equal(5, loadedModel.TestInt);
            Assert.Equal("hello", loadedModel.TestString);
        }

        #region Nested type: TestModel

        [DataContract]
        private class TestModel
        {
            [DataMember]
            public int TestInt { get; set; }

            [DataMember]
            public string TestString { get; set; }
        }

        #endregion
    }
}