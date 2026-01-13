using Microsoft.Playwright;
using Reqnroll;
using test_automation_czechitas.E2E.Shared.Configuration;

namespace test_automation_czechitas.E2E.Shared.Hooks;

[Binding]
public class PlaywrightHooks
{
    private static IPlaywright? _playwright;
    private static IBrowser? _browser;
    private IPage? _page;

    [BeforeTestRun]
    public static async Task BeforeTestRun()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright[TestConfiguration.Browser].LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = TestConfiguration.Headless
        });
    }

    [BeforeScenario]
    public async Task BeforeScenario(ScenarioContext scenarioContext)
    {
        _page = await _browser!.NewPageAsync(new BrowserNewPageOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = TestConfiguration.ViewportWidth,
                Height = TestConfiguration.ViewportHeight
            }
        });
        
        scenarioContext["Page"] = _page;
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        if (_page != null)
        {
            await _page.CloseAsync();
        }
    }

    [AfterTestRun]
    public static async Task AfterTestRun()
    {
        if (_browser != null)
        {
            await _browser.CloseAsync();
        }
        
        _playwright?.Dispose();
    }
}
