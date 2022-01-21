Feature: Lorem ipsum

@tag
Scenario: User check
Given User opens '<homePage>' page
And User checks buttons language visibility
When User clicks on button '<language>'
Then User checks first paragraph include '<word>'

Examples: 
| homePage                | word | language |
| https://www.lipsum.com/ | рыба | Pyccкий  |

@tag1 
Scenario: User checks paragraph stars with words 
Given User opens '<homePage>' page
When User checks text visibility
And User clicks submit button
Then User checks paragraph starts with '<words>'

Examples: 
| homePage                | words   |
| https://www.lipsum.com/ | Lorem ipsum dolor sit amet, consectetur adipiscing elit |

@tag3
Scenario: User checks generate page include count of character
Given User opens '<homePage>' page
And User checks button generate visibility 
And User checks count field visibility 
And User checks button '<value>' visibility 
When User clicks button '<value>' 
And User enters '<amount>' number 
And User clicks submit button
Then User checks generate page include '<amount>' '<value>'

Examples:
| homePage                | value  | amount |
| https://www.lipsum.com/ | words  |  10    |
| https://www.lipsum.com/ | words  |  -1    |
| https://www.lipsum.com/ | words  |   0	|
| https://www.lipsum.com/ | words  |   5	|
| https://www.lipsum.com/ | words  |   20   |
| https://www.lipsum.com/ | bytes  |   35   | 
| https://www.lipsum.com/ | bytes  |   0    |
| https://www.lipsum.com/ | bytes  |   -5   |

@tag4
Scenario: User checks that page will not start from words 
Given User opens '<homePage>' page
When User checks checkbox start with lorem ipsum visibility 
And User clicks checkbox start with lorem ipsum visibility
And User clicks submit button
Then User checks first paragraph not starts from '<words>'

Examples:
| homePage                | words  | 
| https://www.lipsum.com/ | Lorem ipsum  |

@tag5
Scenario: User count probability lorem word in paragraph
Given User opens '<homePage>' page
And User checks button generate visibility 
Then User clicks submit button and count paragraps include word lorem and checks probability lorem word

Examples:
| homePage                | 
| https://www.lipsum.com/ | 