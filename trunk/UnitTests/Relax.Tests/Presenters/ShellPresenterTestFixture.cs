using System;
using Autofac;
using Caliburn.PresentationFramework.ApplicationModel;
using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ShellPresenterTestFixture : TestDataBuilder
    {
        private Mock<IBackingStore> _fakeBackingStore;
        private Mock<IContainer> _stubContainer;

        [SetUp]
        public void Setup()
        {
            _fakeBackingStore = new Mock<IBackingStore>();
            _stubContainer = new Mock<IContainer>();

            _fakeBackingStore.Setup(x => x.Workspace).Returns(AWorkspace.Build());
        }

        private ShellPresenter BuildDefaultShellPresenter()
        {
            return new ShellPresenter(_stubContainer.Object, _fakeBackingStore.Object);
        }

        [Test]
        public void Initialize__InitializesBackingStore()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            test.Initialize();

            _fakeBackingStore.Verify(x => x.Initialize());
        }

        [Test]
        public void Initialize__PresentsContexts()
        {
            var stubContextsPresenter = new Mock<IContextsPresenter>();
            _stubContainer.Setup(x => x.Resolve<IContextsPresenter>()).Returns(stubContextsPresenter.Object);

            ShellPresenter test = BuildDefaultShellPresenter();
            test.Initialize();

            Assert.AreSame(stubContextsPresenter.Object, test.Contexts);
        }

        [Test]
        public void Save__SavesToBackingStore()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            test.Save();

            _fakeBackingStore.Verify(x => x.Save());
        }

        [Test]
        public void AddInboxAction__ShowsInput()
        {
            var stubInputPresenter = new Mock<IInputPresenter>();
            _stubContainer.Setup(x => x.Resolve<IInputPresenter>()).Returns(stubInputPresenter.Object);

            ShellPresenter test = BuildDefaultShellPresenter();

            test.AddInboxAction();

            Assert.AreSame(stubInputPresenter.Object, test.DialogModel);
        }

        [Test]
        public void Open_GivenPresenterType_ActivatesThePresenter()
        {
            var mockPresenter = new Mock<IPresenter>();
            _stubContainer.Setup(x => x.Resolve<IPresenter>()).Returns(mockPresenter.Object);

            ShellPresenter test = BuildDefaultShellPresenter();

            test.Open<IPresenter>();

            mockPresenter.Verify(x => x.Activate());
        }

        [Test]
        public void GoCollect__ActivatesCollectPresenter()
        {
            var mockPresenter = new Mock<ICollectPresenter>();
            _stubContainer.Setup(x => x.Resolve<ICollectPresenter>()).Returns(mockPresenter.Object);

            ShellPresenter test = BuildDefaultShellPresenter();

            test.GoCollect();

            mockPresenter.Verify(x => x.Activate());
        }

        [Test]
        public void GoProcess__ActivatesProcessPresenter()
        {
            var mockPresenter = new Mock<IProcessPresenter>();
            _stubContainer.Setup(x => x.Resolve<IProcessPresenter>()).Returns(mockPresenter.Object);

            ShellPresenter test = BuildDefaultShellPresenter();

            test.GoProcess();

            mockPresenter.Verify(x => x.Activate());
        }

        [Test]
        public void IsProcessingEnabled_WhenThereAreNoInboxActions_IsFalse()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            _fakeBackingStore.Setup(x => x.Workspace).Returns(AWorkspace.Build());

            Assert.IsFalse(test.IsProcessingEnabled);
        }

        [Test]
        public void IsProcessingEnabled_WhenThereIsAnInboxAction_IsTrue()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            _fakeBackingStore.Setup(x => x.Workspace).Returns(AWorkspace.With(AnAction.In(State.Inbox)).Build());

            Assert.IsTrue(test.IsProcessingEnabled);
        }

        [Test]
        public void IsProcessingEnabled_WhenAnInboxActionIsAdded_RaisesPropertyChanged()
        {
            ShellPresenter test = BuildDefaultShellPresenter();

            IWorkspace workspace = AWorkspace.Build();
            _fakeBackingStore.Setup(x => x.Workspace).Returns(workspace);

            bool eventRaised = false;

            test.PropertyChanged += (sender, args) => eventRaised |= args.PropertyName == "IsProcessingEnabled";

            workspace.Actions.Add(AnAction.In(State.Inbox).Build());
            GC.KeepAlive(test);

            Assert.IsTrue(eventRaised);
        }
    }
}