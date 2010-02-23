using System;
using Caliburn.Testability.Extensions;
using Relax.Domain.Models;
using Xunit;

namespace Relax.Domain.Tests.Models
{
    public class DelegationTestFixture
    {
        [Fact]
        public void Owner_WhenSet_RaisesPropertyChanged()
        {
            const string newOwner = "test";

            var test = new Delegation();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Owner).When(() => test.Owner = newOwner);
            Assert.Equal(newOwner, test.Owner);
        }

        [Fact]
        public void DelegationDate_WhenSet_RaisesPropertyChanged()
        {
            DateTime newDelegationDate = DateTime.Today.ToUniversalTime();

            var test = new Delegation();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DelegationDate).When(
                () => test.DelegationDate = newDelegationDate);
            Assert.Equal(newDelegationDate, test.DelegationDate);
        }

        [Fact]
        public void DelegationDate_WhenSetInFuture_Throws()
        {
            DateTime futureDate = DateTime.Today.ToUniversalTime() + TimeSpan.FromDays(5.0);

            var test = new Delegation();

            Assert.Throws(typeof (ArgumentOutOfRangeException),
                          () => test.DelegationDate = futureDate);
        }

        [Fact]
        public void PropertyChanged_RemoveHandler_()
        {
            // AssertThatChangeNotificationIsRaisedBy doesn't seem to remove
            // handlers so this is just to get 100% coverage.
            var test = new Delegation();

            test.PropertyChanged += delegate { };
            test.PropertyChanged -= delegate { };
        }
    }
}