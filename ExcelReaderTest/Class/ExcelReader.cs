using ExcelDataReader;
using System.Data;
using System.IO;

namespace ExcelReaderTest
{
    public class ExcelReader
    {
        public string fileName { get; set; }
        public string WsName { get; set; }

        public ExcelReader(string path, string wsName)
        {
            fileName =path;
            WsName= wsName;
        }
 
        public DataTable GetData()
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader=  ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    var dataset = reader.AsDataSet();
                    var dataTable = dataset.Tables[0];
                    return dataTable;

                }
            }
        }
    }
}

