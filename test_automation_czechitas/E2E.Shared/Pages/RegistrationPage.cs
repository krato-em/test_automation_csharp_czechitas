using System;
using Microsoft.Playwright;

namespace test_automation_czechitas.E2E.Shared.Pages;

public class RegistrationPage : BasePage
{
    protected override string PagePath => "/registrace";

    private ILocator NameField => Page.GetByRole(AriaRole.Textbox, new() { Name = "Jméno a příjmení" });
    private ILocator EmailField => Page.GetByRole(AriaRole.Textbox, new() { Name = "Email" });
    private ILocator PasswordField => Page.GetByRole(AriaRole.Textbox, new() { Name = "Heslo" });
    private ILocator ConfirmPasswordField => Page.GetByRole(AriaRole.Textbox, new() { Name = "Kontrola hesla" });
    private ILocator RegisterButton => Page.GetByRole(AriaRole.Button, new() { Name = "Zaregistrovat" });
    private ILocator ErrorToastMessage => Page.Locator(".toast-error");
    private ILocator InvalidEmailAlertMessage => Page.GetByText("Zadaná adresa neexistuje,");
    private ILocator ShortPasswordAlertMessage => Page.GetByText("Heslo musí obsahovat minimáln");
    private ILocator PasswordMismatchAlertMessage => Page.GetByText("Hesla se neshodují");
    private ILocator DuplicatedEmailAlertMessage => Page.GetByText("Účet s tímto emailem již existuje");

    public RegistrationPage(IPage page) : base(page)
    {
    }

    public async Task FillNameAsync(string name)
    {
        await NameField.FillAsync(name);
    }

    public async Task FillEmailAsync(string email)
    {
        await EmailField.FillAsync(email);
    }

    public async Task FillPasswordAsync(string password)
    {
        await PasswordField.FillAsync(password);
    }

    public async Task FillConfirmPasswordAsync(string confirmPassword)
    {
        await ConfirmPasswordField.FillAsync(confirmPassword);
    }

    public async Task ClickRegisterButtonAsync()
    {
        await RegisterButton.ClickAsync();
    }

    public async Task<bool> IsErrorToastDisplayedAsync()
    {
        try
        {
            await ErrorToastMessage.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 5000 });
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> IsEmailAlertDisplayedAsync()
    {
        return await InvalidEmailAlertMessage.IsVisibleAsync();
    }

    public async Task<bool> IsShortPasswordAlertDisplayedAsync()
    {
        return await ShortPasswordAlertMessage.IsVisibleAsync();
    }

    public async Task<bool> IsPasswordMismatchAlertDisplayedAsync()
    {
        return await PasswordMismatchAlertMessage.IsVisibleAsync();
    }

    public async Task<bool> IsDuplicatedEmailAlertDisplayedAsync()
    {
        return await DuplicatedEmailAlertMessage.IsVisibleAsync();
    }
}
