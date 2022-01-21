Feature: My cool feature

A short summary of the feature

@tag1
Scenario: My cool test and stuff2
	When I go to google.com
	Then I should be at gooble
	When I go to google.com
	When I go to google.com
	When I go to google.com
	Then I should be at gooble
	Then I should be at gooble
	Then I should be at gooble

	Scenario Outline: My cool test and stuff
	Then I select username '<epam>'

	Examples: 
        | email     | organisation | password  | passwordConfirmation | username  | role  |
        | usernamea | Bytes        | password1 | password1            | usernamea | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernameb | Bytes        | password2 | password2            | usernameb | Admin |
        | usernamec | Bytes        | password3 | password3            | usernamec | Admin |
        | usernamec | Bytes        | password3 | password3            | usernamec | Admin |
        | usernamec | Bytes        | password3 | password3            | usernamec | Admin |
        | usernamec | Bytes        | password3 | password3            | usernamec | Admin |
        | usernamec | Bytes        | password3 | password3            | usernamec | Admin |
        | usernamec | Bytes        | password3 | password3            | usernamec | Admin |
        | usernamed | Bytes        | password4 | password4            | usernamed | Admin |
        | usernamee | Bytes        | password5 | password5            | usernamee | Admin |