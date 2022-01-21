Feature: Loremipsum
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
    Then User generates 10 text with lorem compares the average number of lorem words with 2