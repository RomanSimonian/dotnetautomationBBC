  Feature: BBC1 Task Test
	As a user
	I want to check functionality of a fill form
	To confirm it works correctly

  @Smoke
  Scenario Outline: User checks form to ask your question without correct values
	Given User opens homepage page BBC
	When User clicks on News tab
	And User clicks on Coronavirus tab
	And User clicks on Your Coronavirus Stories tab
	And User clicks on question field
	Then User fills: '<question>', '<name>', '<email>', '<number>', '<location>', '<age>' fields
	And User click on checkbox
	And User pushes submit button
	Then User checks result with expected '<error>' message

	Examples: 
	|question		|name		|email	|number		|location	|age |error							|
	|				|Bohdan		|email	|+777777777	|Vinnitsa	|29  |can't be blank				|
	|Example ?		|			|email	|+777777777	|Vinnitsa	|29  |Name can't be blank			|
	|Example none?	|Bohdan		|		|+777777777	|Vinnitsa	|29  |Email address can't be blank	|


  Scenario: 
	Given User opens homepage page BBC
	When User clicks on News tab 
	And User stores the text of the Category link of headline article 
	And User enter this text in the Search bar
	Then User check the name of the first article against a text of headline article
