using System;
using Microsoft.Playwright;
using test_automation_czechitas.E2E.Shared.Configuration;

namespace test_automation_czechitas.E2E.Shared.Pages;

public abstract class BasePage
{
    protected IPage Page { get; }
    protected abstract string PagePath { get;}
    public string FullUrl => $"{TestConfiguration.BaseUrl}{PagePath}";

    protected BasePage(IPage page)
    {
        Page = page;
    }
    public async Task NavigateAsync()
    {
        await Page.GotoAsync(FullUrl, new PageGotoOptions
        {
            Timeout = TestConfiguration.NavigationTimeout
        });
    }
    public async Task<bool> IsOnPageAsync()
    {
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        return Page.Url.Contains(PagePath);
    }
}
