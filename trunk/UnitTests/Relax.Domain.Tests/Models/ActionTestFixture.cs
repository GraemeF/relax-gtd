using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class ActionTestFixture
    {
        [Test]
        public void TitleSet__UpdatesTitle()
        {
            var test = new Domain.Models.Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Title).When(() => test.Title = "test title");

            Assert.AreEqual("test title", test.Title);
        }

        [Test]
        public void CreatedGet__ReturnsDateTimeOfWhenActionWasCreated()
        {
            DateTime createTime = DateTime.Now;
            var test = new Domain.Models.Action();

            Assert.GreaterThanOrEqualTo(createTime, test.Created);
        }

        [Test]
        public void ActionState_WhenSet_UpdatesActionState()
        {
            var test = new Domain.Models.Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.ActionState).When(() => test.ActionState = State.SomedayMaybe);

            Assert.AreEqual(State.SomedayMaybe, test.ActionState);
        }

        [Test]
        public void BlockingActions_Initially_IsEmpty()
        {
            Assert.IsEmpty(new Domain.Models.Action().BlockingActions);
        }

        [Test]
        public void Notes_Initially_IsEmpty()
        {
            Assert.IsEmpty(new Domain.Models.Action().Notes);
        }

        [Test]
        public void Deadline_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            var stubDeadline = new Mock<IDeadline>();
            test.AssertThatChangeNotificationIsRaisedBy(x => x.Deadline).When(() => test.Deadline = stubDeadline.Object);

            Assert.AreSame(stubDeadline.Object, test.Deadline);
        }

        [Test]
        public void Delegation_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            var stubDelegation = new Mock<IDelegation>();
            test.AssertThatChangeNotificationIsRaisedBy(x => x.Delegation).When(() => test.Delegation = stubDelegation.Object);

            Assert.AreSame(stubDelegation.Object, test.Delegation);
        }

        [Test]
        public void Deferral_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            var stubDeferral = new Mock<IDeferral>();
            test.AssertThatChangeNotificationIsRaisedBy(x => x.Deferral).When(() => test.Deferral = stubDeferral.Object);

            Assert.AreSame(stubDeferral.Object, test.Deferral);
        }

        [Test]
        public void Completion_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            var stubCompletion = new Mock<ICompletion>();
            test.AssertThatChangeNotificationIsRaisedBy(x => x.Completion).When(() => test.Completion = stubCompletion.Object);

            Assert.AreSame(stubCompletion.Object, test.Completion);
        }

        [Test]
        public void Review_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            var stubReview = new Mock<IReview>();
            test.AssertThatChangeNotificationIsRaisedBy(x => x.Review).When(() => test.Review = stubReview.Object);

            Assert.AreSame(stubReview.Object, test.Review);
        }

        [Test]
        public void Priority_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Priority).When(() => test.Priority = Priority.Should);

            Assert.AreEqual(Priority.Should, test.Priority);
        }

        [Test]
        public void Repetition_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            var stubRepetition = new Mock<IRepetition>();
            test.AssertThatChangeNotificationIsRaisedBy(x => x.Repetition).When(() => test.Repetition = stubRepetition.Object);

            Assert.AreSame(stubRepetition.Object, test.Repetition);
        }

        [Test]
        public void Cost_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            var stubCost = new Mock<ICost>();
            test.AssertThatChangeNotificationIsRaisedBy(x => x.Cost).When(() => test.Cost = stubCost.Object);

            Assert.AreSame(stubCost.Object, test.Cost);
        }

        [Test]
        public void Context_WhenSet_UpdatesProperty()
        {
            var test = new Domain.Models.Action();

            var stubContext = new Mock<IGtdContext>();
            test.AssertThatChangeNotificationIsRaisedBy(x => x.Context).When(() => test.Context = stubContext.Object);

            Assert.AreSame(stubContext.Object, test.Context);
        }
    }
}