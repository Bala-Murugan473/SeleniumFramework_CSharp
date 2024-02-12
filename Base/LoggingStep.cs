using SeleniumFramework.Helpers;

namespace SeleniumFramework.Base
{
    /// <summary>Class responsible to set feature file names, excel file names, scenario row number 
    /// and to set the excelhelper obj of current thread </summary>
    public class LoggingStep
    {
        public string FeatureFileName { get; set; }
        public string ExcelFileName { get; set; }
        public string RowNumber { get; set; }
        public ExcelHelper ExcelHelper { get; set; }
        //To set and get feature file name using threadlocal
        private static readonly ThreadLocal<string> FileName = new();
        /// <summary>Returns the current execution feature file name</summary>
        public static string GetFeatureFileName() => FileName.Value;
        /// <summary>Sets the current execution feature file name</summary>
        public static void SetFeatureFileName(string fileName) => FileName.Value = fileName;
    }
}
