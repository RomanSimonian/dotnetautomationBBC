Feature: BBC1
As a user
I want to test all main site functionality
So that I can be sure that site works correctly

@mytag
Scenario: Checks the name of the headline article
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks the title of the main article with 'North Korea tests biggest missile since 2017'

@mytag
Scenario: Checks secondary article titles
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks actual list secondary article titles with expected list ["Invasion of Ukraine would be 'horrific',US warns","Hong Kong workers cover up Tiananmen memorial","Gun used by Kyle Rittenhouse to be destroyed","Joni Mitchell wants songs off Spotify in Covid row","The British hymn causing a stir in India"]
	

 @mytag
 Scenario:  Checks the name of the first article by search category 
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks the name of the first article with 'China applies to join key Asia-Pacific trade pact' 

@mytag
Scenario Outline: Check the form to ask questions without questions
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
                                          
                                                                                                                                     
