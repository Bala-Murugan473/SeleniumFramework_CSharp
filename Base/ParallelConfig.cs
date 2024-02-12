using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace SeleniumFramework.Base
{
    /// <summary>Class for handling driver context </summary>
    public class ParallelConfig
    {
        /// Driver instance willl be set at before scenario method and uesed via context injection </summary>
        public IWebDriver Driver { get; set; }
        /// <summary>Used to capture screenshot
        /// <br>If selenium disconnect with brower or browser close by any mean, it returns null</br></summary>
        public AventStack.ExtentReports.Model.Media CaptureAndReturnScreenshotModel(string name)
        {
            string screenshot = "";
            try
            {
                screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            }
            catch (Exception)
            {
                //Assert.Fail("Exception when taking AfterStep screenshot\n" + ex.Message);
            }
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }
    }
}
