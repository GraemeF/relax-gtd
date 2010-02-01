using MbUnit.Framework;
using Relax.AcceptanceTests.TestEntities;

namespace Relax.AcceptanceTests
{
    [TestFixture]
    public class ProcessTestFixture
    {
        [Test]
        public void ProcessButtonIsDisabledWhenInboxIsEmpty()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                Assert.IsFalse(relax.Shell.Workspace.ProcessButton.IsEnabled);
            }
        }

        [Test]
        public void ProcessButtonIsEnabledWhenInboxContainsAnAction()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();
                relax.AddInboxAction("This is an action in my inbox.");

                Assert.IsTrue(relax.Shell.Workspace.ProcessButton.IsEnabled);
            }
        }

        [Test]
        public void ProcessButtonSaysProcessWhenEmpty()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();

                Assert.AreEqual("Process", relax.Shell.Workspace.ProcessButton.Text);
            }
        }

        [Test]
        public void ProcessButtonShowsNumberOfInboxActionsWhenNotEmpty()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();

                relax.AddInboxAction("This is an action in my inbox.");
                Assert.AreEqual("Process (1)", relax.Shell.Workspace.ProcessButton.Text);

                relax.AddInboxAction("This is another action in my inbox.");
                Assert.AreEqual("Process (2)", relax.Shell.Workspace.ProcessButton.Text);
            }
        }

        [Test]
        public void ActionTitleIsEditableWhenProcessing()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();
                const string actionTitle = "This is an action in my inbox.";
                relax.AddInboxAction(actionTitle);

                relax.StartProcessingInbox();

                Assert.AreEqual(actionTitle, relax.Shell.Workspace.ProcessActivity.CurrentActionTitle.Text);
            }
        }
    }
}