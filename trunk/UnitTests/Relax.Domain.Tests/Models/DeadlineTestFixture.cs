using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class DeadlineTestFixture
    {
        [Test]
        public void DeadlineDate_WhenSet_UpdatesProperty()
        {
            var test = new Deadline();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DeadlineDate).When(() => test.DeadlineDate = DateTime.Today);

            Assert.AreEqual(DateTime.Today, test.DeadlineDate);
        }
    }
}