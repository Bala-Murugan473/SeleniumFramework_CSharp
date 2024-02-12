using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Base;
using SeleniumFramework.Config;
using SeleniumFramework.Helpers;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;

namespace SeleniumFramework.Extensions
{
    // Incomplete
    public static class WebDriverExtension
    {
        private static readonly int s_shortWait = Settings.ShortWait;
        private static readonly int s_mediumWait = Settings.MediumWait;
        private static readonly int s_longWait = Settings.LongWait;
        private static readonly int s_retryCount = Settings.RetryCount;
        private static WebDriverWait ShortWait(IWebDriver driver) => new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(s_shortWait), TimeSpan.FromMilliseconds(25.0));
        private static WebDriverWait MediumWait(IWebDriver driver) => new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(s_mediumWait), TimeSpan.FromMilliseconds(25.0));
        private static WebDriverWait LongWait(IWebDriver driver) => new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(s_longWait), TimeSpan.FromMilliseconds(25.0));
        private static void Log(string message) => LogHelper.LogFile(LoggingStep.GetFeatureFileName(), message);
        // public delegate void Execution()

        public static void CloseTab(this IWebDriver driver)
        {
            Delegate closeTab = () => { driver.Close(); };
            RetryHandler.Execute(closeTab);
            //Executor.Execute<IWebDriver>(action, 2);
            Log("[ Window ] or [ Tab ] closed");
        }
        public static void Launch_URL(this IWebDriver driver, string url)
        {
            Delegate closeTab = () => { driver.Navigate().GoToUrl(url); };
            RetryHandler.Execute(closeTab);
            // driver.Navigate().GoToUrl(url);
            Log($"Navigated to URL [ {url} ]");
        }

        public static void Close_All_Tabs(this IWebDriver driver)
        {
            try
            {
                while (driver.WindowHandles.Count > 1)
                {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Close();
                }
                driver.SwitchTo().Window(driver.WindowHandles.First());
                Log("All additional tabs are closed");
            }
            catch (Exception ex)
            {
                Assert.Fail("Close_All_Tabs failed\n" + ex.Message);
            }
        }

        public static void Refresh(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
            Log("Page Refreshed !");
        }

        public static void Capture_Screen(this IWebDriver driver, ScenarioContext scenario)
        {
            ((ExtentTest)scenario["StepNode"]).AddScreenCaptureFromBase64String(((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString);
            Log("Screenshot Captured");
        }
        public static IList<IWebElement> List_of_Elements(this IWebDriver driver, By by, [CallerArgumentExpression("by")] string loc = "")
        {
            var impWait = driver.Manage().Timeouts().ImplicitWait;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(s_mediumWait);
            var elements = driver.FindElements(by);
            driver.Manage().Timeouts().ImplicitWait = impWait;
            Log($"Elemetns found for {loc}");
            return elements;
        }
        public static IWebElement Get_Element(this IWebDriver driver, By by)
        {
            var element = MediumWait(driver).Until(ExpectedConditions.ElementExists(by));
            Log($"Element found []");
            return element;
        }


        public static void Click(this IWebDriver driver, By locator, [CallerArgumentExpression("locator")] string eleName = "")
        {
            int retry = 0;
            //string errorMsg = "";
            bool action = false;
            while (retry < s_retryCount && !action)
            {

            }
        }
    }
}
