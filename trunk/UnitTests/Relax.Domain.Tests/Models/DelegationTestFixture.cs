using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class DelegationTestFixture
    {
        [Test]
        public void Owner_WhenSet_UpdatesProperty()
        {
            var test = new Delegation();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Owner).When(() => test.Owner = "test");

            Assert.AreEqual("test", test.Owner);
        }

        [Test]
        public void DelegationDate_WhenSet_UpdatesProperty()
        {
            var test = new Delegation();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DelegationDate).When(() => test.DelegationDate = DateTime.Today);

            Assert.AreEqual(DateTime.Today, test.DelegationDate);
        }
    }
}