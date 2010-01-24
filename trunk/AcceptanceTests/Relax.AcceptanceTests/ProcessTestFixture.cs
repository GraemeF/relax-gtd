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
                Assert.IsFalse(relax.Shell.ProcessButton.IsEnabled);
            }
        }

        [Test]
        public void ProcessButtonIsEnabledWhenInboxContainsAnAction()
        {
            using (RelaxApplication relax = RelaxApplication.Launch())
            {
                relax.StartCollectingActions();
                relax.AddInboxAction("This is an action in my inbox.");

                Assert.IsTrue(relax.Shell.ProcessButton.IsEnabled);
            }
        }
    }
}