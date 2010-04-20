// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.2.0.0
//      Runtime Version:2.0.50727.4927
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace Relax.AcceptanceTests
{
    using TechTalk.SpecFlow;
    
    
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Process")]
    public partial class ProcessFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ProcessFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Process", "In order to decide what actions are required\r\nAs a busy person\r\nI want to go thro" +
                    "ugh each item in my inbox", ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Process button is disabled when the inbox is empty")]
        public virtual void ProcessButtonIsDisabledWhenTheInboxIsEmpty()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Process button is disabled when the inbox is empty", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have not added any actions");
#line 8
 testRunner.Then("the Process button should be disabled");
#line 9
 testRunner.And("the Process button should show \"Process\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Process button is enabled when the inbox contains an action")]
        public virtual void ProcessButtonIsEnabledWhenTheInboxContainsAnAction()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Process button is enabled when the inbox contains an action", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given("I am in the Collect activity");
#line 13
 testRunner.When("I add an action titled \"Hello\"");
#line 14
 testRunner.Then("the Process button should be enabled");
#line 15
 testRunner.And("the Process button should show \"Process (1)\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Process button shows number of actions in the inbox")]
        public virtual void ProcessButtonShowsNumberOfActionsInTheInbox()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Process button shows number of actions in the inbox", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("I am in the Collect activity");
#line 19
 testRunner.When("I add an action titled \"Hello\"");
#line 20
 testRunner.And("I add an action titled \"World\"");
#line 21
 testRunner.Then("the Process button should be enabled");
#line 22
 testRunner.And("the Process button should show \"Process (2)\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
