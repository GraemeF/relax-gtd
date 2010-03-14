using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class DoLaterPresenterTestFixture
    {
        private readonly Mock<IContextsPresenter> _stubContexts = new Mock<IContextsPresenter>();
        private readonly Mock<IActionDetailsPresenter> _stubDetails = new Mock<IActionDetailsPresenter>();
        private readonly Mock<IProjectsPresenter> _stubProjects = new Mock<IProjectsPresenter>();

        private DoLaterPresenter BuildDefaultDoLaterPresenter()
        {
            return new DoLaterPresenter(_stubContexts.Object, _stubDetails.Object, _stubProjects.Object);
        }

        [Fact]
        public void Contexts__ReturnsContextsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();

            Assert.Same(_stubContexts.Object, test.Contexts);
        }

        [Fact]
        public void Details__ReturnsActionDetailsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            Assert.Same(_stubDetails.Object, test.Details);
        }

        [Fact]
        public void Projects__ReturnsProjectsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            Assert.Same(_stubProjects.Object, test.Projects);
        }
    }
}