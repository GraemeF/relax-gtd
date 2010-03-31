using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ProjectsPresenterTestFixture : TestDataBuilder
    {
        [Fact]
        public void TopLevelProjects_WhenWorkspaceContainsAnActionThatIsBlockedButNotBlocking_ReturnsAction()
        {
            var stubProjectPresenter = new Mock<IActionTreeNodePresenter>();

            var test =
                new ProjectSelector(AProjectsFilter.Providing(AnAction.Build()).Build(),
                                    action => stubProjectPresenter.Object,
                                    new AllowNullSelectionPolicy());
            test.Initialize();

            Assert.Contains(stubProjectPresenter.Object, test.Presenters);
        }
    }
}