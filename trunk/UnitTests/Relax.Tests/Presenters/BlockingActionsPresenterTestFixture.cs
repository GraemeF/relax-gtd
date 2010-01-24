using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class BlockingActionsPresenterTestFixture : TestDataBuilder
    {
        [Test]
        public void Presenters_WhenActionHasABlockingAction_ContainsPresenterForBlockingAction()
        {
            IAction blockingAction = AnAction.Build();
            var stubPresenter = new Mock<IActionPresenter>();

            var test = new BlockingActionsPresenter(AnAction.BlockedBy(blockingAction).Build(),
                                                    delegate(IAction action)
                                                        {
                                                            Assert.AreSame(blockingAction, action);
                                                            return stubPresenter.Object;
                                                        });

            Assert.AreElementsEqual(new[] {stubPresenter.Object}, test.Presenters);
        }
    }
}