using Moq;
using Relax.Commands;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class DoLaterPresenterTestFixture
    {
        private readonly DoLaterCommand _applyCommand = new DoLaterCommand();
        private readonly Mock<IContextsPresenter> _stubContexts = new Mock<IContextsPresenter>();
        private readonly Mock<IActionDetailsPresenter> _stubDetails = new Mock<IActionDetailsPresenter>();
        private readonly Mock<IProjectsPresenter> _stubProjects = new Mock<IProjectsPresenter>();

        private DoLaterPresenter BuildDefaultDoLaterPresenter()
        {
            return new DoLaterPresenter(_applyCommand,
                                        _stubContexts.Object,
                                        _stubDetails.Object,
                                        _stubProjects.Object);
        }
        
        [Fact]
        public void GettingApplyCommand__ReturnsDoLaterCommand()
        {
            var test = BuildDefaultDoLaterPresenter();

            Assert.Same(_applyCommand, test.ApplyCommand);
        }

        [Fact]
        public void GettingContexts__ReturnsContextsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();

            Assert.Same(_stubContexts.Object, test.Contexts);
        }

        [Fact]
        public void GettingDetails__ReturnsActionDetailsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            Assert.Same(_stubDetails.Object, test.Details);
        }

        [Fact]
        public void GettingProjects__ReturnsProjectsPresenter()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            Assert.Same(_stubProjects.Object, test.Projects);
        }
    }
}