using System;
using Caliburn.Testability.Extensions;
using Relax.Domain.Models;
using Xunit;

namespace Relax.Domain.Tests.Models
{
    public class ItemTestFixture
    {
        [Fact]
        public void Title_WhenSet_RaisesPropertyChanged()
        {
            var test = new TestItem();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Title).When(() => test.Title = "test title");
        }

        [Fact]
        public void Title_WhenSetToNull_Throws()
        {
            var test = new TestItem();

            Assert.Throws(typeof (ArgumentNullException), () => test.Title = null);
        }

        [Fact]
        public void CreatedGet__ReturnsDateTimeOfWhenItemWasCreated()
        {
            DateTime createTime = DateTime.UtcNow;
            var test = new TestItem();

            Assert.True(test.Created >= createTime);
        }

        [Fact]
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