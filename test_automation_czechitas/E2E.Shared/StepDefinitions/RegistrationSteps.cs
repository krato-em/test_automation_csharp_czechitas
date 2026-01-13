using System;
using Microsoft.Playwright;
using Reqnroll;
using test_automation_czechitas.E2E.Shared.Pages;

namespace test_automation_czechitas.E2E.Shared.StepDefinitions;

[Binding]
public class RegistrationSteps
{
    private readonly IPage _page;
    private readonly RegistrationPage _registrationPage;

    public RegistrationSteps(ScenarioContext scenarioContext)
    {
        _page = (IPage)scenarioContext["Page"];
        _registrationPage = new RegistrationPage(_page);
    }

    [Given(@"I navigate to registration page")]
    public async Task GivenINavigateToRegistrationPage()
    {
        await _registrationPage.NavigateAsync();
    }

    [Then(@"I am on the registration page")]
    [When]
    public async Task ThenIAmOnTheRegistrationPage()
    {
        var isOnPage = await _registrationPage.IsOnPageAsync();
        Assert.IsTrue(isOnPage, "Not on registration page");
    }

    [Given(@"I fill in name and surname ""(.*)""")]
    public async Task GivenIFillInNameAndSurname(string fullName)
    {
        await _registrationPage.FillNameAsync(fullName);
    }

    [Given(@"I enter a valid email")]
    public async Task GivenIEnterAValidEmail()
    {
        var email = $"test_{Guid.NewGuid()}@test.cz";
        await _registrationPage.FillEmailAsync(email);
    }

    [Given(@"I enter password ""(.*)""")]
    [When(@"I enter password ""(.*)""")]
    public async Task GivenIEnterPassword(string password)
    {
        await _registrationPage.FillPasswordAsync(password);
    }

    [Given(@"I confirm password ""(.*)""")]
    [When(@"I confirm password ""(.*)""")]
    public async Task GivenIConfirmPassword(string confirmPassword)
    {
        await _registrationPage.FillConfirmPasswordAsync(confirmPassword);
    }

    [Given(@"I click the ""(.*)"" button")]
    public async Task GivenIClickTheButton(string buttonText)
    {
        await _registrationPage.ClickRegisterButtonAsync();
    }

    [Then(@"The pupils page should load")]
    public async Task ThenThePupilsPageShouldLoad()
    {
        await _page.WaitForURLAsync("**/zaci");
        Assert.IsTrue(_page.Url.Contains("/zaci"), "Not on pupils page");
    }

    [When(@"I attempt to submit the form with empty fields")]
    public async Task WhenIAttemptToSubmitFormWithEmptyFields()
    {
        await _registrationPage.ClickRegisterButtonAsync();
    }

    [Then(@"warning message should be displayed")]
    public async Task ThenWarningMessageShouldBeDisplayed()
    {
        var isDisplayed = await _registrationPage.IsErrorToastDisplayedAsync();
        Assert.IsTrue(isDisplayed, "Warning message not displayed");
    }

    [When(@"I enter weak password ""(.*)""")]
    public async Task WhenIEnterWeakPassword(string weakPassword)
    {
        await _registrationPage.FillPasswordAsync(weakPassword);
    }

    [When(@"I attempt to submit the form")]
    public async Task WhenIAttemptToSubmitTheForm()
    {
        await _registrationPage.ClickRegisterButtonAsync();
    }

    [Then(@"error toast-message is displayed")]
    public async Task ThenErrorToastMessageIsDisplayed()
    {
        var isDisplayed = await _registrationPage.IsErrorToastDisplayedAsync();
        Assert.IsTrue(isDisplayed, "Error toast not displayed");
    }

    [When(@"I enter invalid email format ""(.*)""")]
    public async Task WhenIEnterInvalidEmailFormat(string invalidEmail)
    {
        await _registrationPage.FillEmailAsync(invalidEmail);
    }

    [When(@"I enter different password confirmation ""(.*)""")]
    public async Task WhenIEnterDifferentPasswordConfirmation(string differentPassword)
    {
        await _registrationPage.FillConfirmPasswordAsync(differentPassword);
    }

    [When(@"I enter an email that already exists in the system ""(.*)""")]
    public async Task WhenIEnterAnEmailThatAlreadyExists(string existingEmail)
    {
        await _registrationPage.FillEmailAsync(existingEmail);
    }

    [When(@"I fill in all other fields correctly")]
    public async Task WhenIFillInAllOtherFieldsCorrectly()
    {
        await _registrationPage.FillNameAsync("Test User");
        await _registrationPage.FillPasswordAsync("SecurePassword123");
        await _registrationPage.FillConfirmPasswordAsync("SecurePassword123");
    }

    [Then(@"duplicated email alert is shown")]
    public async Task ThenDuplicatedEmailAlertIsShown()
    {
        var isDisplayed = await _registrationPage.IsDuplicatedEmailAlertDisplayedAsync();
        Assert.IsTrue(isDisplayed, "Duplicated email alert not displayed");
    }

    [Then(@"password mismatch alert is shown")]
    public async Task ThenPasswordMismatchAlertIsShown()
    {
        var isDisplayed = await _registrationPage.IsPasswordMismatchAlertDisplayedAsync();
        Assert.IsTrue(isDisplayed, "Password mismatch alert not displayed");
    }

    [Then(@"weak password alert is shown")]
    public async Task ThenWeakPasswordAlertIsShown()
    {
        var isDisplayed = await _registrationPage.IsShortPasswordAlertDisplayedAsync();
        Assert.IsTrue(isDisplayed, "Weak password alert not displayed");
    }

    [Then(@"invalid email alert is shown")]
    public async Task ThenInvalidEmailAlertIsShown()
    {
        var isDisplayed = await _registrationPage.IsEmailAlertDisplayedAsync();
        Assert.IsTrue(isDisplayed, "Invalid email alert not displayed");
    }
}
