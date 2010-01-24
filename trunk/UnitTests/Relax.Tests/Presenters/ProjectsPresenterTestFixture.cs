using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ProjectsPresenterTestFixture : TestDataBuilder
    {
        [Test]
        public void TopLevelProjects_WhenWorkspaceContainsAnActionThatIsBlockedButNotBlocking_ReturnsAction()
        {
            var stubProjectPresenter = new Mock<IActionTreeNodePresenter>();

            IAction unblockedAction = AnAction.Build();
            IAction blockedAction = AnAction.BlockedBy(unblockedAction).Build();
            var test =
                new ProjectsPresenter(AWorkspace.With(blockedAction).With(unblockedAction).Build(),
                                      delegate(IAction action)
                                          {
                                              Assert.AreSame(blockedAction, action,
                                                             "The wrong action was presented.");
                                              return stubProjectPresenter.Object;
                                          });

            Assert.AreElementsEqual(new[] {stubProjectPresenter.Object}, test.Presenters);
        }
    }
}