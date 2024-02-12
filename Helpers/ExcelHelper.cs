using ExcelDataReader;

//using NUnit.Framework;
using SeleniumFramework.Base;
using System.Data;


namespace SeleniumFramework.Helpers
{
    public class ExcelHelper
    {
        private static readonly object S_myLock = new();
        //public List<She

        public string FromExcel(string columnName, List<DataCollection> dataCol, string rowNo)
        {
            string data = null;
            try
            {
                data = (from coldata in dataCol
                        where coldata.ColumnName == columnName && coldata.RowNo == rowNo
                        select coldata.CellValue).FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception($"Excel value not retrived for column : [ {columnName} ], sheet : [ {dataCol} ], row : [ {rowNo} ]");
            }
            return data;
        }

        /// <summary>
        /// Returns the List of DataCollection for the given sheet from the passing data table collection
        /// <br>The DataCollection is a custom property class containing each cell deatils such as SheetName, RowNumber, ColumnName and CellValue </br>
        /// If the given sheet not present in data table collection it throws error</summary>
        public static List<DataCollection> StoreExcelValuesToCollection(string fileName, string sheetName)
        {
            DataTableCollection dataTableCollection = LoadExcelToDataTable(fileName);
            List<DataCollection> cellsData = new();
            try
            {
                // Extracting the required sheet for datatablecollection
                DataTable resultTable = dataTableCollection[sheetName];
                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    /*Looping through each rows & column 
                     * The reason for initialize row = 1, is for each understanding when calling from feature
                     * For Example, In ScenarioExample: it is more readable that 'DataSet1' means first row instead of DataSet0*/
                    for (int row = 1; row <= resultTable.Rows.Count; row++)
                    {
                        for (int col = 1; col <= resultTable.Columns.Count; col++)
                        {
                            // DataCollection will have one cell details
                            DataCollection cell = new()
                            {
                                RowNo = "DataSet" + row,
                                ColumnName = resultTable.Columns[col].ColumnName,
                                CellValue = resultTable.Rows[row - 1][col].ToString(),
                                SheetName = resultTable.TableName
                            };
                            cellsData.Add(cell);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogFile(LoggingStep.GetFeatureFileName(), $"Error Occured when fetching excel data from sheet [ {sheetName}\n ]" + ex.Message);
                throw new Exception($"Error Occured when fetching excel data from sheet [ {sheetName}\n ]" + ex.Message);
            }
            return cellsData;
        }

        public static DataTableCollection LoadExcelToDataTable(string fileName)
        {
            lock (S_myLock)
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                using IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                ExcelDataTableConfiguration tableConfiguration = new() { UseHeaderRow = true };
                ExcelDataSetConfiguration ConfigureDataTable = new()
                {
                    ConfigureDataTable = (data) => tableConfiguration
                };
                DataSet result = reader.AsDataSet(ConfigureDataTable);
                DataTableCollection tableCollection = result.Tables;
                SheetDetails sheetDetails = new SheetDetails();
                for (int i = 1; i < tableCollection.Count; i++)
                {
                    sheetDetails.SheetName = tableCollection[i].TableName;
                    sheetDetails.RowNo = i;
                }
                stream.Dispose();
                return tableCollection;
            }

        }
    }
}
