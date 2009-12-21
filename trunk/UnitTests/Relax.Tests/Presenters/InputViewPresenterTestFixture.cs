using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class InputViewPresenterTestFixture
    {
        private Mock<IAction> _fakeAction;
        private Mock<IWorkspace> _fakeWorkspace;

        [SetUp]
        public void SetUp()
        {
            _fakeWorkspace = new Mock<IWorkspace>();
            _fakeAction = new Mock<IAction>();
        }

        private InputViewPresenter BuildDefaultInputViewPresenter()
        {
            return new InputViewPresenter(_fakeWorkspace.Object, _fakeAction.Object);
        }

        [Test]
        public void Action__ReturnsAction()
        {
            InputViewPresenter test = BuildDefaultInputViewPresenter();

            Assert.AreSame(_fakeAction.Object, test.Action);
        }

        [Test]
        public void Add_WhenTitleIsNotEmpty_AddsItemToInbox()
        {
            InputViewPresenter test = BuildDefaultInputViewPresenter();

            test.Add();

            _fakeWorkspace.Verify(x => x.Add(_fakeAction.Object));
        }

        [Test]
        public void Constructor__SetsActionStateToInbox()
        {
            InputViewPresenter test = BuildDefaultInputViewPresenter();

            _fakeAction.VerifySet(x => x.ActionState = State.Inbox);
        }
    }
}