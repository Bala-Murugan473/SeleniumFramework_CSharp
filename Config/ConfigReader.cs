using Microsoft.Extensions.Configuration;

namespace SeleniumFramework.Config
{
    internal static class ConfigReader
    {
        internal static void SetFrameworkConfigurations()
        {
            ConfigurationBuilder reader = new();
            reader.SetBasePath(Directory.GetCurrentDirectory());
            reader.AddJsonFile("FrameConfig.json");

            IConfigurationRoot congfig = reader.Build();
            Settings.Config_URL = congfig.GetSection("testRunSettings").Get<TestRunSettings>().URL;
            Settings.Config_UserName = congfig.GetSection("testRunSettings").Get<TestRunSettings>().UserName;
            Settings.Config_Password = congfig.GetSection("testRunSettings").Get<TestRunSettings>().Password;
            Settings.Config_BrowserType = congfig.GetSection("testRunSettings").Get<TestRunSettings>().BrowserType;
        }
    }
}
