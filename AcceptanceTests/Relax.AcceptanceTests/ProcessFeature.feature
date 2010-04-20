Feature: Process
	In order to decide what actions are required
	As a busy person
	I want to go through each item in my inbox

Scenario: Process button is disabled when the inbox is empty
	Given I have not added any actions
	Then the Process button should be disabled
