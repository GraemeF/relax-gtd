using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using MbUnit.Framework;
using Relax.FileBackingStore.Services;
using Relax.FileBackingStore.Services.Interfaces;

namespace Relax.FileBackingStore.Tests.Services
{
    [TestFixture]
    public class SerializerTestFixture
    {
        private static readonly IEnumerable<Type> KnownTypes = new[] {typeof (TestModel), typeof (int), typeof (string)};

        [Test]
        public void Save_GivenStream_WritesSomething()
        {
            ISerializer<TestModel> fileStore = new Serializer<TestModel>();
            using (var stream = new MemoryStream())
            {
                fileStore.Save(stream, new TestModel(), KnownTypes);

                Assert.GreaterThan(stream.Position, 0L, "The file written to should not be empty.");
            }
        }

        [Test]
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

            Assert.AreNotSame(savedModel, loadedModel);
            Assert.AreEqual(5, loadedModel.TestInt);
            Assert.AreEqual("hello", loadedModel.TestString);
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