namespace SeleniumFramework.Helpers
{
    public class DataCollection
    {
        /*Class responsible for storing excel values
         * this class used to map row number, column name, column value and sheet name of the collected excel data*/
        public string RowNo { get; set; }
        public string ColumnName { get; set; }
        public string CellValue { get; set; }
        public string SheetName { get; set; }
    }
}
