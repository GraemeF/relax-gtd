using Relax.Domain.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Domain.Tests.Models
{
    public class ActionQueueTestFixture : TestDataBuilder
    {
        [Fact]
        public void Head_WhenEmpty_IsNull()
        {
            Assert.Null(new ActionQueue().Head);
        }

        [Fact]
        public void Head_WhenThereIsAnAction_ReturnsFirstAction()
        {
            IAction action = AnAction.Build();

            var test = new ActionQueue {action};

            Assert.Same(action, test.Head);
        }

        [Fact]
        public void Requeue_WhenGivenAnAction_PutsActionAtTailOfQueue()
        {
            IAction action = AnAction.Build();

            var test = new ActionQueue {action, AnAction.Build()};
            test.Requeue(action);

            Assert.Same(action, test[1]);
        }
    }
}