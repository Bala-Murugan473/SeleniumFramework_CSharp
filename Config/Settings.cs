using SeleniumFramework.Enums;

namespace SeleniumFramework.Config
{
    public class Settings
    {
        public static string Config_URL { get; set; }
        public static string Config_UserName { get; set; }
        public static string Config_Password { get; set; }
        public static BrowserType Config_BrowserType { get; set; }
        public static int ShortWait { get; set; }
        public static int MediumWait { get; set; }
        public static int LongWait { get; set; }
        public static int RetryCount { get; set; }

    }
}
