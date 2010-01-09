using MbUnit.Framework;
using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ProcessPresenterTestFixture
    {
        private Mock<IDoLaterPresenter> _stubDoLater;
        private Mock<IDoNowPresenter> _stubDoNow;
        private Mock<IInboxActionsPresenter> _stubInbox;

        [SetUp]
        public void SetUp()
        {
            _stubDoLater = new Mock<IDoLaterPresenter>();
            _stubInbox = new Mock<IInboxActionsPresenter>();
            _stubDoNow = new Mock<IDoNowPresenter>();
        }

        private ProcessPresenter BuildDefaultProcessPresenter()
        {
            return new ProcessPresenter(_stubDoLater.Object,
                                        _stubInbox.Object,
                                        _stubDoNow.Object);
        }

        [Test]
        public void Inbox__ReturnsInboxPresenter()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            Assert.AreSame(_stubInbox.Object, test.Inbox);
        }

        [Test]
        public void DoLater__ReturnsDoLaterPresenter()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            Assert.AreSame(_stubDoLater.Object, test.DoLater);
        }

        [Test]
        public void DoNow__ReturnsDoNowPresenter()
        {
            ProcessPresenter test = BuildDefaultProcessPresenter();

            Assert.AreSame(_stubDoNow.Object, test.DoNow);
        }
    }
}