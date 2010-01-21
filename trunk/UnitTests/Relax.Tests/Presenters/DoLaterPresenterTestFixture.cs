using MbUnit.Framework;
using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class DoLaterPresenterTestFixture
    {
        private Mock<IContextsPresenter> _stubContexts;
        private Mock<IActionDetailsPresenter> _stubDetails;
        private Mock<IProjectsPresenter> _stubProjects;

        [SetUp]
        public void SetUp()
        {
            _stubContexts = new Mock<IContextsPresenter>();
            _stubDetails = new Mock<IActionDetailsPresenter>();
            _stubProjects = new Mock<IProjectsPresenter>();
        }

        private DoLaterPresenter BuildDefaultDoLaterPresenter()
        {
            return new DoLaterPresenter(_stubContexts.Object, _stubDetails.Object, _stubProjects.Object);
        }

        [Test]
        public void Contexts__ReturnsContextsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();

            Assert.AreSame(_stubContexts.Object, test.Contexts);
        }

        [Test]
        public void Details__ReturnsActionDetailsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            Assert.AreSame(_stubDetails.Object, test.Details);
        }

        [Test]
        public void Projects__ReturnsProjectsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            Assert.AreSame(_stubProjects.Object, test.Projects);
        }
    }
}