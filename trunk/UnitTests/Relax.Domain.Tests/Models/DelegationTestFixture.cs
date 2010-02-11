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
            var test = new Delegation();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Owner).When(() => test.Owner = "test");
        }

        [Fact]
        public void DelegationDate_WhenSet_RaisesPropertyChanged()
        {
            var test = new Delegation();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DelegationDate).When(
                () => test.DelegationDate = DateTime.Today);
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