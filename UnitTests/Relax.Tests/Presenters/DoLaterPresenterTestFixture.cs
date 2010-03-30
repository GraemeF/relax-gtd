using System;
using System.ComponentModel;
using Moq;
using Relax.Commands;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class DoLaterPresenterTestFixture : TestDataBuilder
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
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();

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

        [Fact]
        public void GettingContextsCurrentItem_Initially_ReturnsContextFromCommand()
        {
            IGtdContext context = AContext.Build();
            _applyCommand.Context = context;

            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            test.Initialize();

            _stubContexts.VerifySet(x => x.CurrentItem = context);
        }

        [Fact]
        public void GettingApplyCommandContext_WhenContextHasBeenSelected_ReturnsTheContext()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            test.Initialize();

            IGtdContext context = AContext.Build();
            ContextIsSelected(context);

            GC.KeepAlive(test);
            Assert.Same(context, _applyCommand.Context);
        }

        [Fact]
        public void GettingApplyCommandProject_WhenProjectHasBeenSelected_ReturnsTheProject()
        {
            DoLaterPresenter test = BuildDefaultDoLaterPresenter();
            test.Initialize();

            IAction project = AnAction.Build();
            ProjectIsSelected(project);

            GC.KeepAlive(test);
            Assert.Same(project, _applyCommand.Project);
        }

        private void ContextIsSelected(IGtdContext gtdContext)
        {
            _stubContexts.Setup(x => x.CurrentItem).Returns(gtdContext);
            _stubContexts.Raise(x => x.PropertyChanged += null, new PropertyChangedEventArgs("CurrentItem"));
        }

        private void ProjectIsSelected(IAction project)
        {
            _stubProjects.Setup(x => x.CurrentItem).Returns(project);
            _stubProjects.Raise(x => x.PropertyChanged += null, new PropertyChangedEventArgs("CurrentItem"));
        }
    }
}