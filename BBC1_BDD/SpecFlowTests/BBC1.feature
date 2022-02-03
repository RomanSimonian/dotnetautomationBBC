Feature: BBC1
As a user
I want to test all main site functionality
So that I can be sure that site works correctly

@mytag
Scenario: Checks the name of the headline article
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks the title of the main article with 'US troop increase in Europe destructive - Russia'

@mytag
Scenario: Checks secondary article titles
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks actual list secondary article titles with expected list

	| articles  | titles                                             |
    | article 1 | Havana Syndrome may be caused by ‘directed energy’ |
    | article 2 | Life inside the Beijing Winter Olympics bubble     |
    | article 3 | The illegal Brazilian gold you may be wearing      |
    | article 4 | US commandos in major raid in north-west Syria     |
    | article 5 | Iran accused in anti-Israel fake social media plot |
	
 @mytag
 Scenario:  Checks the name of the first article by search category 
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks the name of the first article with 'Europe: Strangers on My Doorstep' 

@mytag
Scenario Outline: Checks message the form without field
	Given User opens '<url>'
	When User click to the News
	And User chooses Coronavirus news
	And User choses Coronavirus stories
	And User choses ask questions
	Then Filled out the form witout '<field>' and corrected the error '<message>'

	Examples:
      | url                  | field         | message                      |
      | https://www.bbc.com/ | question      | can't be blank               |
      | https://www.bbc.com/ | accept        | must be accepted             |
      | https://www.bbc.com/ | email         | Email address can't be blank |
      | https://www.bbc.com/ | name          | Name can't be blank          |                                   
                                                                                                                                     
