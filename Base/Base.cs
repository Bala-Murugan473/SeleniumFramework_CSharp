using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Base
{
    /// <summary>Top level class, responsible for dependency and context injection
    /// <br>This class is mainly used to inject driver instance and other required instances </br></summary>
    public class Base
    {
        public readonly ParallelConfig ParallelConfig;
        public readonly LoggingStep LoggingStep;
        /// <summary>
        /// <br>Selenium webdriver instance</br>
        /// this driver instance will create before each scenario from the feature and
        /// delete after respective scenario execution
        /// </summary>
        public readonly IWebDriver Driver;
        //injection
        public Base(ParallelConfig pc, LoggingStep ls)
        {
            ParallelConfig = pc;
            LoggingStep = ls;
            Driver = pc.Driver;
        }
        /// <summary>To print log message for the executing feature file</summary>
        public void Log(string message) => LogHelper.LogFile(LoggingStep.FeatureFileName, message);
    }
}
