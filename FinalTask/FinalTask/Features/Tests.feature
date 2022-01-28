Feature: BBC1 Task Test
  As a user
  I want to check functionality of a site
  To confirm it works correctly

  Scenario: User checks form to ask your question without correct values1
    Given User opens homepage page BBC
    When User clicks on News tab
    And User clicks on Coronavirus tab
    And User clicks on Your Coronavirus Stories tab
    And User clicks on question field
    And User fills question field
    And User fills name field
    And User fills email field
    And User fills number field
    And User fills location field
    And User fills age field
    And User click on checkbox
    And User pushes submit button
    Then User checks result
