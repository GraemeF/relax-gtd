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

Scenario: Action title is shown when processing
	Given I have added an inbox action called "Hello"
	When I go to the Process activity
	Then the title edit box should show "Hello"

Scenario: Changing the action title when processing updates the action title
	Given I have added an inbox action called "Hello"
	And have gone to the Process activity
	When I enter "World" in the title edit box
	Then the title of the first inbox action should be "World"
	
Scenario: Marking an inbox action as done removes it from the inbox
	Given I have added an inbox action called "Hello"
	And I have gone to the Process activity
	When I mark the action as done
	Then the inbox should be empty

Scenario: Adding a new context displays it in the contexts list
	Given I am processing an action
	And I have chosen the Later tab
	When I add a context called "MyContext"
	Then the the context list should contain "MyContext"

Scenario: Processing the last inbox action clears the Process activity
	Given I have added an inbox action called "Hello"
	And I have gone to the Process activity
	When I mark the action as done
	Then the Process activity should be empty
