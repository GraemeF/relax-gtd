using Moq;
using Relax.Domain.Models;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ActionQueuePresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void Presenters_WhenThereAreActions_ContainsAnOpenPresenterForEachAction()
        {
            var mockPresenter = new Mock<IActionPresenter>();

            var test = new ActionQueuePresenter(new ActionQueue {AnAction.Build()},
                                                x => mockPresenter.Object);

            Assert.Equal(1, test.Presenters.Count);
            Assert.Same(mockPresenter.Object, test.Presenters[0]);
            mockPresenter.Verify(x => x.Initialize());
        }

        [Fact]
        public void Presenters_WhenAnActionIsRemovedFromTheQueue_ShutsDownThePresenterAndRemovesIt()
        {
            var mockPresenter = new Mock<IActionPresenter>();

            var actionQueue = new ActionQueue {AnAction.Build()};
            var test = new ActionQueuePresenter(actionQueue,
                                                x => mockPresenter.Object);
            actionQueue.RemoveAt(0);

            Assert.Equal(0, test.Presenters.Count);
            mockPresenter.Verify(x => x.Shutdown());
        }
    }
}