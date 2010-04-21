using System.Linq;
using Relax.AcceptanceTests.TestEntities;
using Xunit;

namespace Relax.AcceptanceTests
{
    public class ProcessTestFixture
    {
        [Fact]
        public void MarkingTheLastInboxActionAsDoneClearsAndDisablesTheTitle()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();
                relax.AddInboxAction("This is an action in my inbox.");
                relax.StartProcessingInbox();
                relax.Shell.Workspace.ProcessActivity.ApplyButton.Click();

                Assert.True(relax.Shell.Workspace.ProcessActivity.CurrentActionTitle.IsReadOnly);
                Assert.Equal(string.Empty, relax.Shell.Workspace.ProcessActivity.CurrentActionTitle.Text);
            }
        }
    }
}