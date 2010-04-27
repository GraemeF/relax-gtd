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

        [Given(@"I have not added any actions")]
        public void GivenIHaveNotAddedAnyActions()
        {
        }

        [Then(@"the Process button should be disabled")]
        public void ThenTheProcessButtonShouldBeDisabled()
        {
            Assert.False(_relax.Shell.Workspace.ProcessButton.IsEnabled);
        }

        [Then(@"the Process button should be enabled")]
        public void ThenTheProcessButtonShouldBeEnabled()
        {
            Assert.True(_relax.Shell.Workspace.ProcessButton.IsEnabled);
        }

        [Then(@"the Process button should show ""(.*)""")]
        public void ThenTheProcessButtonShouldShowText(string buttonText)
        {
            Assert.Equal(buttonText, _relax.Shell.Workspace.ProcessButton.Text);
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

        [Given(@"I have added an inbox action called ""(.*)""")]
        public void GivenIHaveAddedAnInboxActionWIthTitle(string title)
        {
            _relax.StartCollectingActions();
            _relax.AddInboxAction(title);
        }

        [When(@"I go to the Process activity")]
        public void WhenIGoToTheProcessActivity()
        {
            _relax.StartProcessingInbox();
        }

        [Then(@"the title edit box should show ""(.*)""")]
        public void ThenTheTitleEditBoxShouldShowTitle(string title)
        {
            Assert.Equal(title, _relax.Shell.Workspace.ProcessActivity.CurrentActionTitle.Text);
        }

        [Given(@"have gone to the Process activity")]
        public void GivenHaveGoneToTheProcessActivity()
        {
            _relax.StartProcessingInbox();
        }

        [When(@"I enter ""(.*)"" in the title edit box")]
        public void WhenIEnterTextInTheTitleEditBox(string text)
        {
            _relax.Shell.Workspace.ProcessActivity.CurrentActionTitle.Text = text;
        }

        [Then(@"the title of the first inbox action should be ""(.*)""")]
        public void ThenTheTitleOfTheFirstInboxActionShouldBe(string title)
        {
            Assert.Equal(title, _relax.Shell.Workspace.ProcessActivity.UnprocessedActionList.Actions.First());
        }

        [Given(@"I have gone to the Process activity")]
        public void GivenIHaveGoneToTheProcessActivity()
        {
            _relax.StartProcessingInbox();
        }

        [When(@"I mark the action as done")]
        public void WhenIMarkTheActionAsDone()
        {
            _relax.InProcessActivity.MarkAsDone();
        }

        [Then(@"the inbox should be empty")]
        public void ThenTheInboxShouldBeEmpty()
        {
            Assert.False(_relax.InProcessActivity.UnprocessedActionList.Actions.Any());
        }

        [Then(@"the Process activity should be empty")]
        public void ThenTheProcessActivityShouldBeEmpty()
        {
            Assert.True(_relax.Shell.Workspace.ProcessActivity.IsEmpty);
        }

        [Given(@"I am processing an action")]
        public void GivenIAmProcessingAnAction()
        {
            _relax.StartCollectingActions();
            _relax.AddInboxAction("An Action");
            _relax.StartProcessingInbox();
        }

        [Given(@"I have chosen the (.*) tab")]
        public void GivenIHaveChosenTheTab(string tab)
        {
            _relax.InProcessActivity.ChooseTab(tab);
        }

        [When(@"I add a context called ""(.*)""")]
        public void WhenIAddAContextCalled(string context)
        {
            _relax.InProcessActivity.InDoLaterTab.AddContext(context);
            ScenarioContext.Current.Pending();
        }

        [Then(@"the the context list should contain ""(.*)""")]
        public void ThenTheTheContextListShouldContain(string context)
        {
            ScenarioContext.Current.Pending();
        }
    }
}