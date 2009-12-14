using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Relax.Infrastructure.Models;

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
    }
}