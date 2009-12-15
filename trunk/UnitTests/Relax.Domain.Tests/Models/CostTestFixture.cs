using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Relax.Domain.Models;
using Relax.Infrastructure.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class CostTestFixture
    {
        [Test]
        public void TimeRequired_WhenSet_UpdatesProperty()
        {
            var test = new Cost();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.TimeRequired).When(() => test.TimeRequired = TimeSpan.FromMinutes(30));

            Assert.AreEqual(TimeSpan.FromMinutes(30), test.TimeRequired);
        }

        [Test]
        public void MentalEnergyRequired_WhenSet_UpdatesProperty()
        {
            var test = new Cost();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.MentalEnergyRequired).When(
                () => test.MentalEnergyRequired = EnergyLevel.Medium);

            Assert.AreEqual(EnergyLevel.Medium, test.MentalEnergyRequired);
        }

        [Test]
        public void PhysicalEnergyRequired_WhenSet_UpdatesProperty()
        {
            var test = new Cost();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.PhysicalEnergyRequired).When(
                () => test.PhysicalEnergyRequired = EnergyLevel.Medium);

            Assert.AreEqual(EnergyLevel.Medium, test.PhysicalEnergyRequired);
        }
    }
}