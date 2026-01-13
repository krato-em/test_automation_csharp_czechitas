using System;

namespace test_automation_czechitas.E2E.Shared.Configuration;

[TestClass]
public class ConfigurationTest
{
    [TestMethod]
    public void Configuration_Loads_Successfully()
    {
        Assert.IsNotNull(TestConfiguration.BaseUrl);
        Assert.IsNotNull(TestConfiguration.AdminUsername);
        Console.WriteLine($"Base URL: {TestConfiguration.BaseUrl}");
    }
}
