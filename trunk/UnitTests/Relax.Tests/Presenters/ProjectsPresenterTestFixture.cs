using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.TestDataBuilders;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ProjectsPresenterTestFixture : TestDataBuilder
    {
        [Test]
        public void TopLevelProjects_WhenWorkspaceContainsAnActionThatIsBlockedButNotBlocking_ReturnsAction()
        {
            Mock<IWorkspace> stubWorkspace = AWorkspace.With(AnAction.BlockedBy(AnAction)).Build();
            var stubProjectPresenter = new Mock<IProjectPresenter>();

            var test = new ProjectsPresenter(stubWorkspace.Object);

            Assert.AreElementsEqual(new []{stubProjectPresenter.Object},test.TopLevelProjects);
        }
    }
}