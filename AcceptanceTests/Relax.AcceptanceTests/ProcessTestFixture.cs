using System.Linq;
using Relax.AcceptanceTests.TestEntities;
using Xunit;

namespace Relax.AcceptanceTests
{
    public class ProcessTestFixture
    {
        [Fact]
        public void ProcessButtonIsDisabledWhenInboxIsEmpty()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                Assert.False(relax.Shell.Workspace.ProcessButton.IsEnabled);
            }
        }

        [Fact]
        public void ProcessButtonIsEnabledWhenInboxContainsAnAction()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();
                relax.AddInboxAction("This is an action in my inbox.");

                Assert.True(relax.Shell.Workspace.ProcessButton.IsEnabled);
            }
        }

        [Fact]
        public void ProcessButtonSaysProcessWhenEmpty()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();

                Assert.Equal("Process", relax.Shell.Workspace.ProcessButton.Text);
            }
        }

        [Fact]
        public void ProcessButtonShowsNumberOfInboxActionsWhenNotEmpty()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();

                relax.AddInboxAction("This is an action in my inbox.");
                Assert.Equal("Process (1)", relax.Shell.Workspace.ProcessButton.Text);

                relax.AddInboxAction("This is another action in my inbox.");
                Assert.Equal("Process (2)", relax.Shell.Workspace.ProcessButton.Text);
            }
        }

        [Fact]
        public void ActionTitleIsDisplayedWhenProcessing()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();
                const string actionTitle = "This is an action in my inbox.";
                relax.AddInboxAction(actionTitle);

                relax.StartProcessingInbox();

                Assert.Equal(actionTitle, relax.Shell.Workspace.ProcessActivity.CurrentActionTitle.Text);
            }
        }

        [Fact]
        public void ChangingActionTitleWhenProcessingUpdatesActionTitle()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();
                relax.AddInboxAction("This is an action in my inbox.");

                relax.StartProcessingInbox();

                const string newTitle = "New title";
                relax.Shell.Workspace.ProcessActivity.CurrentActionTitle.Text = newTitle;

                Assert.Equal(newTitle,
                             relax.Shell.Workspace.ProcessActivity.UnprocessedActionList.Actions.Single());
            }
        }
    }
}