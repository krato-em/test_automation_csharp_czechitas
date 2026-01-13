# Test Automation - Czechitas

Automated tests for web application using C#, Playwright, and Reqnroll.

## Tech Stack
- **Language:** C# (.NET 8.0)
- **Test Framework:** MSTest
- **BDD Framework:** Reqnroll
- **Automation Tool:** Playwright
- **Design Pattern:** Page Object Model (POM)

## Prerequisites
Before running the tests, ensure you have:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- Visual Studio Code or Visual Studio 2022
- PowerShell (for Playwright browser installation)

## Setup

1. Install dependencies:
```bash
cd test_automation_czechitas
dotnet restore
```

2. Install Playwright browsers:
```bash
pwsh bin/Debug/net8.0/playwright.ps1 install
```

3. Update `.env` file with your settings (browser size, timeouts, etc.)

## Running Tests

```bash
dotnet test
```

## Project Structure
```
test_automation_czechitas/
├── E2E.UI.Tests/
│   └── Features/              # Gherkin feature files
│       └── Registration.feature
├── E2E.Shared/
│   ├── Configuration/         # Test configuration translator
│   │   └── TestConfiguration.cs
│   ├── Hooks/                 # Test lifecycle hooks
│   │   └── PlaywrightHooks.cs
│   ├── Pages/                 # Page Object Model classes
│   │   ├── BasePage.cs
│   │   └── RegistrationPage.cs
│   └── StepDefinitions/       # Step implementations
│       └── RegistrationSteps.cs
├── .env                       # Environment variables (not in git)
├── .env.example               # Template for .env
└── reqnroll.json             # Reqnroll configuration
```
## What's Tested

- User registration (success and validation errors)
