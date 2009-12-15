using System;
using MbUnit.Framework;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class CompletionTestFixture
    {
        [Test]
        public void CompletedDateGet__ReturnsDateTimeOfWhenActionWasCreated()
        {
            DateTime completedDate = DateTime.Now;
            var test = new Completion();

            Assert.GreaterThanOrEqualTo(completedDate, test.CompletedDate);
        }
    }
}