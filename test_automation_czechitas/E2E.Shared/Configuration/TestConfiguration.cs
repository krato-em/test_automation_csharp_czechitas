using System;
using dotenv.net;
using dotenv.net.Utilities;

namespace test_automation_czechitas.E2E.Shared.Configuration;

public static class TestConfiguration
{
    static TestConfiguration()
    {
        DotEnv.Load();
    }

        public static string BaseUrl => EnvReader.GetStringValue("BASE_URL");
        public static string AdminUsername => EnvReader.GetStringValue("ADMIN_USERNAME");
        public static string AdminPassword => EnvReader.GetStringValue("ADMIN_PASSWORD");
        public static string Browser => EnvReader.GetStringValue("BROWSER");
        public static bool Headless => EnvReader.GetBooleanValue("HEADLESS");
        public static int ViewportWidth => EnvReader.GetIntValue("VIEWPORT_WIDTH");
        public static int ViewportHeight => EnvReader.GetIntValue("VIEWPORT_HEIGHT");
        public static float DefaultTimeout => EnvReader.GetIntValue("DEFAULT_TIMEOUT");
        public static float NavigationTimeout => EnvReader.GetIntValue("NAVIGATION_TIMEOUT");
}
