Feature: User Registration

  Background:
    Given I navigate to registration page
    Then I am on the registration page

  Scenario: Successful User Registration
    Given I fill in name and surname "Jana Novakova"
    And I enter a valid email
    And I enter password "SecurePassword123"
    And I confirm password "SecurePassword123"
    And I click the "Zaregistrovat" button
    Then The pupils page should load

  # NOTE: tady jsem zaboha nemohla lokalizovat lokator pro tu chybovou hlasku, co se objevi, kdyz nic nevyplnim
  Scenario: Registration Form Validation - Empty Fields
    When I attempt to submit the form with empty fields
    Then I am on the registration page

  Scenario: Registration Form Validation - Weak Passwords
    Given I fill in name and surname "Jana Novakova"
    And I enter a valid email
    When I enter weak password "123"
    And I confirm password "123"
    And I attempt to submit the form
    Then error toast-message is displayed
    And weak password alert is shown

  Scenario: Registration Form Validation - Invalid Email Formats
    Given I fill in name and surname "Jana Novakova"
    And I enter password "SecurePassword123"
    And I confirm password "SecurePassword123"
    When I enter invalid email format "invalid@email"
    And I attempt to submit the form
    Then error toast-message is displayed
    And invalid email alert is shown

  Scenario: Registration Form Validation - Password Mismatch
    Given I fill in name and surname "Jana Novakova"
    And I enter a valid email
    When I enter password "SecurePassword123"
    And I enter different password confirmation "DifferentPassword456"
    And I attempt to submit the form
    Then error toast-message is displayed
    And password mismatch alert is shown

  Scenario: Registration Form Validation - Duplicate Email
    When I enter an email that already exists in the system "test@seznam.cz"
    And I fill in all other fields correctly
    And I attempt to submit the form
    Then error toast-message is displayed
    And duplicated email alert is shown
