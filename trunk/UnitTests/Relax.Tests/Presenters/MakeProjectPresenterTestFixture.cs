using MbUnit.Framework;
using Moq;
using Relax.Presenters.Interfaces;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class MakeProjectPresenterTestFixture
    {
        [Test]
        public void Projects__ReturnsProjectsPresenter()
        {
            var stubProjects = new Mock<IProjectsPresenter>();
            var test = new MakeProjectPresenter(stubProjects.Object);

            Assert.AreSame(stubProjects.Object, test.Projects);
        }
    }
}