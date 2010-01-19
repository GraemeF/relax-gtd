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

            Mock<IAction> unblockedAction = AnAction.Build();
            Mock<IAction> blockedAction = AnAction.BlockedBy(unblockedAction.Object).Build();
            var test =
                new ProjectsPresenter(AWorkspace.With(blockedAction.Object).With(unblockedAction.Object).Build().Object,
                                      delegate(IAction action)
                                          {
                                              Assert.AreSame(blockedAction.Object, action,
                                                             "The wrong action was presented.");
                                              return stubProjectPresenter.Object;
                                          });

            Assert.AreElementsEqual(new[] {stubProjectPresenter.Object}, test.Presenters);
        }
    }
}