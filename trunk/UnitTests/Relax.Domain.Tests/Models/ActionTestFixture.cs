using System;
using Caliburn.Testability.Extensions;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Xunit;
using Action = Relax.Domain.Models.Action;

namespace Relax.Domain.Tests.Models
{
    public class ActionTestFixture
    {
        [Fact]
        public void TimeRequired_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.TimeRequired).
                When(() => test.TimeRequired = TimeSpan.FromMinutes(30));
        }

        [Fact]
        public void MentalEnergyRequired_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.MentalEnergyRequired).
                When(() => test.MentalEnergyRequired = EnergyLevel.Medium);
        }

        [Fact]
        public void PhysicalEnergyRequired_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.PhysicalEnergyRequired).
                When(() => test.PhysicalEnergyRequired = EnergyLevel.Medium);
        }

        [Fact]
        public void ActionState_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.ActionState).
                When(() => test.ActionState = State.SomedayMaybe);
        }

        [Fact]
        public void ActionState_Initially_IsInbox()
        {
            var test = new Action();

            Assert.Equal(State.Inbox, test.ActionState);
        }

        [Fact]
        public void BlockingActions_Initially_IsEmpty()
        {
            Assert.Empty(new Action().BlockingActions);
        }

        [Fact]
        public void Notes_Initially_IsEmpty()
        {
            Assert.Empty(new Action().Notes);
        }

        [Fact]
        public void Deadline_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Deadline).
                When(() => test.Deadline = DateTime.UtcNow);
        }

        [Fact]
        public void Delegation_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Delegation).
                When(() => test.Delegation = new Mock<IDelegation>().Object);
        }

        [Fact]
        public void DeferUntil_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DeferUntil).
                When(() => test.DeferUntil = DateTime.UtcNow);
        }

        [Fact]
        public void CompletedDate_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.CompletedDate).
                When(() => test.CompletedDate = DateTime.UtcNow);
        }

        [Fact]
        public void Review_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Review).
                When(() => test.Review = new Mock<IReview>().Object);
        }

        [Fact]
        public void Priority_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Priority).
                When(() => test.Priority = Priority.Should);
        }

        [Fact]
        public void Repetition_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Repetition).
                When(() => test.Repetition = new Mock<IRepetition>().Object);
        }

        [Fact]
        public void Context_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Context).
                When(() => test.Context = new Mock<IGtdContext>().Object);
        }
    }
}