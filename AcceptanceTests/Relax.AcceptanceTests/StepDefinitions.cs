using System.Linq;
using Relax.AcceptanceTests.TestEntities;
using TechTalk.SpecFlow;
using Xunit;

namespace Relax.AcceptanceTests
{
    [Binding]
    public class StepDefinitions
    {
        private RelaxApplication _relax;

        [BeforeScenario]
        public void StartApplication()
        {
            _relax = RelaxApplication.Launch();
        }

        [AfterScenario]
        public void StopApplication()
        {
            _relax.Dispose();
            _relax = null;
        }

        [Given(@"I am in the Collect activity")]
        public void GivenIAmInTheCollectActivity()
        {
            _relax.StartCollectingActions();
        }

        [Then(@"the Inbox is empty")]
        public void ThenTheInboxIsEmpty()
        {
            Assert.False(_relax.InboxActions.Any());
        }

        [When(@"I add an action titled ""(.*)""")]
        public void WhenIAddAnActionTitled(string title)
        {
            _relax.AddInboxAction(title);
        }

        [Then(@"the inbox should contain ""(.*)""")]
        public void ThenTheInboxShouldContain(string title)
        {
            Assert.True(_relax.InboxActions.Any(x => x == title));
        }
    }
}