Feature: BBC1 with Lorem ipsum
As a user
I want to test all main site functionality
So that I can be sure that site works correctly

@mytag
Scenario: Checking that text contains word
    Given User opens '<homePage>' page
    When User chooses Russian language
    Then User checks that text first paragraph contains word '<word>'

    Examples:
      | homePage                | word |
      | https://www.lipsum.com/ | рыба |

@mytag
 Scenario Outline: Checking that the created Lorem starts with text
    Given User opens '<homePage>' page
    When User generates a new lorem
    Then User checks that the created Lorem starts with text '<text>'

    Examples:
      | homePage                | text                                                    |
      | https://www.lipsum.com/ | Lorem ipsum dolor sit amet, consectetur adipiscing elit |

@mytag
 Scenario Outline: Checking created word lorem is the actual result
    Given User opens '<homePage>' page
    When User input an element '<element>' and count <count>
    Then User Checking created '<element>' lorem is the <expected_result>

    Examples:
      | homePage                | count | element | expected_result|
      | https://www.lipsum.com/ |   10  |  words  | 10             |
      | https://www.lipsum.com/ |    0  |  words  | 5              |
      | https://www.lipsum.com/ |   -1  |  words  | 5              |
      | https://www.lipsum.com/ |   20  |  words  | 20             |
      | https://www.lipsum.com/ |    5  |  words  | 5              |
      | https://www.lipsum.com/ |   10  |  bytes  | 10             |
      | https://www.lipsum.com/ |  -10  |  bytes  | 5              |
      | https://www.lipsum.com/ |    0  |  bytes  | 5              |

@mytag
Scenario Outline: Checking created lorem not start with text
    Given User opens '<homePage>' page
    When User disables checkbox begin with lorem
    And User generates a new lorem
    Then User checking created lorem not start with '<text>'

    Examples:
      | homePage                | text                                                    |
      | https://www.lipsum.com/ | Lorem ipsum dolor sit amet, consectetur adipiscing elit |

@mytag
Scenario: Checking probability contains word "lorem"
    Given User opens 'https://www.lipsum.com/' page
    When User generates 10 text with lorem 
    Then Compares that the average number is greater than 2


@mytag
Scenario: Checks the name of the headline article
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks the title of the main article with 'Charles leads Jubilee tributes to 'remarkable' Queen'

@mytag
Scenario: Checks secondary article titles
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks actual list secondary article titles with expected list

	| articles  | titles                                             |
	| article 1 | Beloved Indian singer Lata Mangeshkar dies at 92   |
	| article 2 | Tragic end for boy trapped in Moroccan well        |
	| article 3 | Russia 70% ready to invade Ukraine, US sources say |
	| article 4 | The fast fashion graveyard in a desert             |     
    | article 5 | The fast fashion graveyard in a desert             |
	
 @mytag
 Scenario:  Checks the name of the first article by search category 
	Given User opens 'https://www.bbc.com/'
	When User click to the News
	Then User checks the name of the first article with 'UK' 

@mytag
Scenario Outline: Checks message the form without field
	Given User opens 'https://www.lipsum.com/'
	And User generates the text of the question
	And User opens 'https://www.bbc.com/'
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
                                                                                                                                     
