Feature: BBC1 Task Test
  As a user
  I want to check functionality of a site
  To confirm it works correctly

  @Smoke
  Scenario Outline: User checks form to ask your question without correct values
	Given User opens homepage page BBC
	When User clicks on News tab
	And User clicks on Coronavirus tab
	And User clicks on Your Coronavirus Stories tab
	And User clicks on question field
	Then User fills: <question>, <name>, <email>, <number>, <location>, <age> fields
	And User click on checkbox
	And User pushes submit button
	Then User checks result

	Examples: 
	|question			|name			|email	|number		|location	|age |
	|Example question?	|Bohdan			|email	|+777777777	|Vinnitsa	|29  |
	|Example question?	|				|email	|+777777777	|Vinnitsa	|29  |
	|Example question?	|Bohdan			|		|+777777777	|Vinnitsa	|29  |
	|Example question?	|Bohdan			|email	|			|Vinnitsa	|29  |
	