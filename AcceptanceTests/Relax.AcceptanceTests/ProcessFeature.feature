Feature: Process
	In order to decide what actions are required
	As a busy person
	I want to go through each item in my inbox

Scenario: Process button is disabled when the inbox is empty
	Given I have not added any actions
	Then the Process button should be disabled
	And the Process button should show "Process"
	
Scenario: Process button is enabled when the inbox contains an action
	Given I am in the Collect activity
	When I add an action titled "Hello"
	Then the Process button should be enabled
	And the Process button should show "Process (1)"
	
Scenario: Process button shows number of actions in the inbox
	Given I am in the Collect activity
	When I add an action titled "Hello"
	And I add an action titled "World"
	Then the Process button should be enabled
	And the Process button should show "Process (2)"
