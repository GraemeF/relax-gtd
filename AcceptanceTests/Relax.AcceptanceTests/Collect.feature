Feature: Collect
	In order to empty my head of things I may need to do
	As a busy person
	I want to enter actions for later processing

Scenario: Enter an action
	Given I am in the Collect activity
	When I add an action titled "Hello"
	Then the inbox should contain "Hello"

Scenario: Enter two actions
	Given I am in the Collect activity
	When I add an action titled "Hello"
	And I add an action titled "World"
	Then the inbox should contain "Hello"
	And the inbox should contain "World"

Scenario: Rename an action
	Given I have added an inbox action called "Hello"
	When I select the first inbox action
	And I rename to "World"
	Then the inbox should contain "World"
