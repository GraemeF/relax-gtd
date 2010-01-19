using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class ItemTestFixture
    {
        [VerifyContract]
        public readonly IContract Title = new AccessorContract<TestItem, string>
                                              {
                                                  PropertyName = "Title",
                                                  AcceptNullValue = false,
                                                  ValidValues = {"Some title", string.Empty}
                                              };

        [Test]
        public void Title_WhenSet_RaisesPropertyChanged()
        {
            var test = new TestItem();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Title).When(() => test.Title = "test title");
        }

        [Test]
        public void CreatedGet__ReturnsDateTimeOfWhenItemWasCreated()
        {
            DateTime createTime = DateTime.UtcNow;
            var test = new TestItem();

            Assert.GreaterThanOrEqualTo(test.Created, createTime);
        }

        [Test]
        public void PropertyChanged_RemoveHandler_()
        {
            // AssertThatChangeNotificationIsRaisedBy doesn't seem to remove
            // handlers so this is just to get 100% coverage.
            var test = new TestItem();

            test.PropertyChanged += delegate { };
            test.PropertyChanged -= delegate { };
        }

        #region Nested type: TestItem

        private class TestItem : Item
        {
        }

        #endregion
    }
}