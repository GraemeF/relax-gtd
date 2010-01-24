using MbUnit.Framework;
using Moq;
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

            var test =
                new ProjectsPresenter(AProjectsFilter.Providing(AnAction.Build()).Build(),
                                      action => stubProjectPresenter.Object);

            Assert.AreElementsSame(new[] {stubProjectPresenter.Object}, test.Presenters);
        }
    }
}