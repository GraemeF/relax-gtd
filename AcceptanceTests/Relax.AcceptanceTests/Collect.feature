Feature: Collect
	In order to empty my head of things I may need to do
	As a busy person
	I want to enter actions for later processing

Scenario: Enter an action
	Given I am in the Collect activity
	And the Inbox is empty
	When I add an action titled "Hello"
	Then the inbox should contain "Hello"
