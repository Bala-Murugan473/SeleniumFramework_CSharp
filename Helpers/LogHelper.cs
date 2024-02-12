using SeleniumFramework.Base;

namespace SeleniumFramework.Helpers
{
    public class LogHelper
    {
        /// <summary>
        /// Report directory will create here
        /// </summary>
        private static void _LogFile(string testName, string LogMessage)
        {
            string directoryPath = TestInitializeHook.Dir + testName;
            string filePath = directoryPath + @"\" + testName + ".log";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.AppendAllText(filePath, DateTime.Now.ToString() + " " + LogMessage + "\n");
        }
        /// <summary>
        /// Create & write logs of the executing feature file, each feature will have separate log file. 
        /// For multiple scenarios in a feature, log file will be the same (i.e) 1 feature file =1 log file
        /// </summary>
        public static void LogFile(string testName, string logMessage)
        {
            try
            {
                _LogFile(testName, logMessage);
            }
            catch (Exception)
            {
                /* Handling Process error, which will occur if the system has low memory*/
                Thread.Sleep(200);
                _LogFile(testName, logMessage);
            }
        }
    }
}
