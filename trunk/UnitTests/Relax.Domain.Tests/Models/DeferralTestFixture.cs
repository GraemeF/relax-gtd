using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class DeferralTestFixture
    {
        [Test]
        public void DeferralDate_WhenSet_UpdatesProperty()
        {
            var test = new Deferral();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DeferUntil).When(() => test.DeferUntil = DateTime.Today);

            Assert.AreEqual(DateTime.Today, test.DeferUntil);
        }
    }
}