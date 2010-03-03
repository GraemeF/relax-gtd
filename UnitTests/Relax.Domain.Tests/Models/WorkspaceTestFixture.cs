using Moq;
using Relax.Domain.Models;
using Relax.Infrastructure.Models.Interfaces;
using Xunit;

namespace Relax.Domain.Tests.Models
{
    public class WorkspaceTestFixture:TestDataBuilders.TestDataBuilder
    {
        [Fact]
        public void Contexts_Initially_IsEmpty()
        {
            var test = new Workspace();

            Assert.Empty(test.Contexts);
        }

        [Fact]
        public void Add_GivenAction_AddsActionToActions()
        {
            var test = new Workspace();

            var stubAction = new Mock<IAction>();
            test.Add(stubAction.Object);

            Assert.Contains(stubAction.Object, test.Actions);
        }
    }
}