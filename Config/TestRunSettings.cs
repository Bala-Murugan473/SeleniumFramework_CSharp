using Newtonsoft.Json;
using SeleniumFramework.Enums;

namespace SeleniumFramework.Config
{
    [JsonObject("testRunSettings")]
    internal class TestRunSettings
    {
        [JsonProperty(nameof(URL))]
        public string URL { get; set; }
        [JsonProperty(nameof(UserName))]
        public string UserName { get; set; }
        [JsonProperty(nameof(Password))]
        public string Password { get; set; }
        [JsonProperty(nameof(BrowserType))]
        public BrowserType BrowserType { get; set; }

    }
}
