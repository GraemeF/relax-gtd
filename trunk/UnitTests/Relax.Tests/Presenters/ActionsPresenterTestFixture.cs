using System.Collections.ObjectModel;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ActionsPresenterTestFixture
    {
        private readonly Mock<IActionPresenter> _stubActionPresenter = new Mock<IActionPresenter>();
        private readonly Mock<IWorkspace> _stubWorkspace = new Mock<IWorkspace>();

        public ActionsPresenterTestFixture()
        {
            _stubWorkspace.Setup(x => x.Actions).Returns(new ObservableCollection<IAction>());
        }

        private ActionsPresenter BuildDefaultActionsPresenter()
        {
            return new ActionsPresenter(_stubWorkspace.Object,
                                        x => _stubActionPresenter.Object);
        }

        [Fact]
        public void Constructor__DoesNotThrow()
        {
            new ActionsPresenter(_stubWorkspace.Object, x => _stubActionPresenter.Object);
        }
    }
}