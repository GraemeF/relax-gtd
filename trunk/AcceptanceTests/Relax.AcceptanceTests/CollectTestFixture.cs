using MbUnit.Framework;
using Relax.AcceptanceTests.TestEntities;

namespace Relax.AcceptanceTests
{
    [TestFixture]
    public class CollectTestFixture
    {
        [Test]
        [Category("Regression")]
        public void When_an_action_is_added_it_is_shown_in_the_Inbox()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                const string newAction = "This is an action in my inbox.";

                relax.StartCollectingActions();
                relax.AddInboxAction(newAction);

                relax.HasInboxActions(new[] {newAction});
            }
        }
    }
}