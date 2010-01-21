using System.Collections.ObjectModel;
using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ActionsPresenterTestFixture
    {
        private Mock<IActionPresenter> _stubActionPresenter;
        private Mock<IWorkspace> _stubWorkspace;

        [SetUp]
        public void SetUp()
        {
            _stubWorkspace = new Mock<IWorkspace>();
            _stubActionPresenter = new Mock<IActionPresenter>();

            _stubWorkspace.Setup(x => x.Actions).Returns(new ObservableCollection<IAction>());
        }

        private ActionsPresenter BuildDefaultActionsPresenter()
        {
            return new ActionsPresenter(_stubWorkspace.Object,
                                        x => _stubActionPresenter.Object);
        }

        [Test]
        public void Constructor__DoesNotThrow()
        {
            new ActionsPresenter(_stubWorkspace.Object, x => _stubActionPresenter.Object);
        }
    }
}