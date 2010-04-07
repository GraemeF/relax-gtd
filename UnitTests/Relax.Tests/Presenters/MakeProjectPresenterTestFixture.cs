using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class MakeProjectPresenterTestFixture
    {
        [Fact]
        public void Projects__ReturnsProjectsPresenter()
        {
            var stubProjects = new Mock<IOptionalProjectSelector>();
            var test = new MakeProjectPresenter(stubProjects.Object);

            Assert.Same(stubProjects.Object, test.Projects);
        }
    }
}