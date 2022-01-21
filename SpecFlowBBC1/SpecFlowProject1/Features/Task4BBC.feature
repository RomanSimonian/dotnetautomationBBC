Feature: BBCtask4


@tag
Scenario: User checks head title include words
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks news button 
Then User checks head title include '<words>'

Examples:
| homePage |  words |
| https://www.bbc.com/ | Urgent US-Russia talks amid Ukraine tensions |

@tag2
Scenario: User checks head secondly include words
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks news button
Then User checks first title include '<title1>'
Then User checks second title include '<title2>'
Then User checks third title include '<title3>'
Then User checks fourth title include '<title4>'
Then User checks fifth title include '<title5>'

Examples:
| homePage             | title1        | title2    | title 3      | title4        | title5        |
| https://www.bbc.com/ | US and Russia | Meat Loaf | False banana | Tearful Adele | Tonga tsunami |


@tag3
Scenario: User enter category name ling in search field
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks news button
And User enter category name in search
And User checks search page visibility
Then User checks first search title include '<keyword>'


Examples: 
| homePage             | keyword   |
| https://www.bbc.com/ | Science & Environment |

@tag5
Scenario: User send form for question without name
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks news button
And User clicks coronavirus news
And User clicks go to form coronavirus stories
And User enter form without name
Then User checks error '<message>'

Examples: 
| homePage             | message   |
| https://www.bbc.com/ | can't be blank |

Scenario: User send form for question without question
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks news button
And User clicks coronavirus news
And User clicks go to form coronavirus stories
And User enter form without question
Then User checks error '<message>'

Examples: 
| homePage             | message   |
| https://www.bbc.com/ | can't be blank |



Scenario: User send form for question without accept button
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks news button
And User clicks coronavirus news
And User clicks go to form coronavirus stories
And User enter form data
Then User checks error '<acceptMessage>'

Examples: 
| homePage             | acceptMessage   |
| https://www.bbc.com/ | must be accepted |

