using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class ExcelLib
    {


        public class DataCollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        static List<DataCollection> dataCol = new List<DataCollection>();

        private static DataTable ExcelToDataTable(string fileName)
        {
            // open file
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            // create OpenXmlReader
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            // Set #1 row = column name
            excelReader.IsFirstRowAsColumnNames = true;
            // Return as Dataset
            DataSet result = excelReader.AsDataSet();
            // Get all the tables
            DataTableCollection table = result.Tables;
            // Store it in DataTable
            DataTable resultTable = table["Sheet1"];
            return resultTable;
        }

        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            // Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                // Retrieving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
