Feature: BBCtask4


@tag
Scenario: User checks head title include words
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks '<category>' button 
Then User checks head title include '<words>'

Examples:
| homePage             | words                                        |category  |
| https://www.bbc.com/ | Urgent US-Russia talks amid Ukraine tensions |News  |

@tag2
Scenario: User checks head secondly include words
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks '<category>' button 
Then User checks '<title1>' '<title2>' '<title3>' '<title4>' 

Examples:
| homePage             | title1        | title2    | title 3      | title4        |  category |
| https://www.bbc.com/ | South Africa  | Meat Loaf | False banana | Tearful Adele |  News |


@tag3
Scenario: User enter category name ling in search field
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks '<category>' button 
And User enter category name in search
And User checks search page visibility
Then User checks first search title include '<keyword>'


Examples: 
| homePage             | keyword               | category  |
| https://www.bbc.com/ | Science & Environment | News |

@tag5
Scenario: User send form for question without name
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks '<category>' button 
And User clicks coronavirus news
And User clicks go to form coronavirus stories
And User enter form without name
Then User checks error '<message>'

Examples: 
| homePage             | message        | category |
| https://www.bbc.com/ | can't be blank | News |

Scenario: User send form for question without question
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks '<category>' button 
And User clicks coronavirus news
And User clicks go to form coronavirus stories
And User enter form without question
Then User checks error '<message>'

Examples: 
| homePage             | message        | category |
| https://www.bbc.com/ | can't be blank | News  |



Scenario: User send form for question without accept button
Given User opens '<homePage>' page 
When User checks news page button visibility 
And User clicks '<category>' button 
And User clicks coronavirus news
And User clicks go to form coronavirus stories
And User enter form data
Then User checks error '<acceptMessage>'

Examples: 
| homePage             | acceptMessage    | category |
| https://www.bbc.com/ | must be accepted | News |

