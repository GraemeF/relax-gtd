using System.Collections.ObjectModel;
using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ContextsPresenterTestFixture
    {
        private Mock<IGtdContextPresenter> _stubContextPresenter;
        private Mock<IGtdContext> _stubNewContext;
        private Mock<IWorkspace> _stubWorkspace;

        [SetUp]
        public void SetUp()
        {
            _stubWorkspace = new Mock<IWorkspace>();
            _stubContextPresenter = new Mock<IGtdContextPresenter>();
            _stubNewContext = new Mock<IGtdContext>();

            _stubWorkspace.Setup(x => x.Contexts).Returns(new ObservableCollection<IGtdContext>());
        }

        private ContextsPresenter BuildDefaultContextsPresenter()
        {
            return new ContextsPresenter(_stubWorkspace.Object,
                                         x => _stubContextPresenter.Object,
                                         () => _stubNewContext.Object);
        }

        [Test]
        public void AddContext__AddsAContextToTheWorkspace()
        {
            BuildDefaultContextsPresenter().AddContext();

            Assert.Contains(_stubWorkspace.Object.Contexts, _stubNewContext.Object);
        }
    }
}