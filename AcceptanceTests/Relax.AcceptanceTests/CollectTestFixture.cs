using System.ComponentModel;
using Relax.AcceptanceTests.TestEntities;
using Xunit;

namespace Relax.AcceptanceTests
{
    public class CollectTestFixture
    {
        [Fact]
        [Category("Regression")]
        public void When_an_action_is_added_it_is_shown_in_the_Inbox()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                const string newActionTitle = "This is an action in my inbox.";

                relax.StartCollectingActions();
                relax.AddInboxAction(newActionTitle);

                relax.HasInboxActions(new[] {newActionTitle});
            }
        }
    }
}