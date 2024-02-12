using OpenQA.Selenium.Chrome;
using SeleniumFramework.Config;
using SeleniumFramework.Enums;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace SeleniumFramework.Base
{
    public class TestInitializeHook
    {
        private readonly BrowserType _browser;
        private readonly ParallelConfig _parallelConfig;
        private readonly LoggingStep _loggingStep;
        private FeatureContext _featureContext;
        public static string Dir = Directory.GetCurrentDirectory().Split("bin")[0] + "Reports\\" + DateTime.Now.ToString("dd-MM-yyy") + @"\" + DateTime.Now.ToString("hh_mm_ss_tt") + @"\";

        public TestInitializeHook(ParallelConfig pc, LoggingStep ls, FeatureContext fc)
        {
            _browser = Settings.Config_BrowserType;
            _featureContext = fc;
            _parallelConfig = pc;
            _loggingStep = ls;
        }
        public void IntializeBrowser(PdfPreview pdfPreview = PdfPreview.True, Headless headless = Headless.False)
        {
            OpenBrowser(_browser, pdfPreview, headless);
        }
        public void OpenBrowser(BrowserType browerType, PdfPreview pdfPreview, Headless headless)
        {
            string downloadPath = Dir + _featureContext.FeatureInfo.Title + @"\";
            if (browerType == BrowserType.Chrome)
            {
                ChromeOptions option = new();
                option.AddArgument("start-maxmized");
                option.AddUserProfilePreference("download.default_directory", downloadPath);
                option.AddUserProfilePreference("download.prompt_for_download", false);
                option.AddUserProfilePreference("download.directory_upgrade", true);
                if (pdfPreview == PdfPreview.True)
                {
                    option.AddUserProfilePreference("plugins.plugins_disabled", "Chrome PDF Viewer");
                    option.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                }
                if (headless == Headless.False)
                {
                    option.AddArgument("--headless");
                    option.AddArgument("window-size=1366,667");
                }
                option.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.None;
                new DriverManager().SetUpDriver(new ChromeConfig()); ;
                _parallelConfig.Driver = new ChromeDriver(option);
            }
            else if (browerType == BrowserType.Edge) {/*edge implementations*/ }
            else if (browerType == BrowserType.Firefox) { /*firefox implementations*/}
            else {/*default launch browser*/ }
        }
    }
}
