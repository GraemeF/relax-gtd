using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class BlockingActionsPresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void Presenters_WhenActionHasABlockingAction_ContainsPresenterForBlockingAction()
        {
            IAction blockingAction = AnAction.Build();
            var stubPresenter = new Mock<IActionPresenter>();

            var test = new BlockingActionsPresenter(AnAction.BlockedBy(blockingAction).Build(),
                                                    delegate(IAction action)
                                                        {
                                                            Assert.Same(blockingAction, action);
                                                            return stubPresenter.Object;
                                                        });
            test.Initialize();

            Assert.Contains(stubPresenter.Object, test.Presenters);
        }
    }
}