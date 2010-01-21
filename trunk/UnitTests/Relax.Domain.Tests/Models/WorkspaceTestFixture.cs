using MbUnit.Framework;
using Moq;
using Relax.Domain.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class WorkspaceTestFixture
    {
        [Test]
        public void Contexts_Initially_IsEmpty()
        {
            var test = new Workspace();

            Assert.IsEmpty(test.Contexts);
        }

        [Test]
        public void Add_GivenAction_AddsActionToActions()
        {
            var test = new Workspace();

            var stubAction = new Mock<IAction>();
            test.Add(stubAction.Object);

            Assert.Contains(test.Actions, stubAction.Object);
        }
    }
}