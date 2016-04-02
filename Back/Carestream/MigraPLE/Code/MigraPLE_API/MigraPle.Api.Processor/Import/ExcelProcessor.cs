using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web.Script.Serialization;
using MigraPle.Api.Configurations;
using MigraPle.Api.Processor.Interface;

namespace MigraPle.Api.Processor.Import
{
    public class ExcelProcessor : IFileProcessor
    {
        private readonly IConfigurationGetter _configurationGetter;

        public ExcelProcessor(IConfigurationGetter configurationGetter)
        {
            _configurationGetter = configurationGetter;
        }

        public IEnumerable<string> ImportProcess(string ruta)
        {
            return ReadExcel(ruta);
        }

        private IEnumerable<string> ReadExcel(string ruta)
        {
            var dataTable = new DataTable();

            using (var connection = new OleDbConnection(_configurationGetter.GetExcelConnectionString(ruta)))
            {
                connection.Open();

                using (var oleDbcommand = new OleDbDataAdapter(_configurationGetter.GetConfiguration("ExcelQuery"), connection))
                {
                    oleDbcommand.TableMappings.Add("Table", "Table");
                    var dataSet = new DataSet();
                    oleDbcommand.Fill(dataSet);

                    dataTable = dataSet.Tables[0];
                }
            }

            var serializer = new JavaScriptSerializer();
            var rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            var rowCollection = new List<string>();

            foreach (DataRow dr in dataTable.Rows)
            {
                row = dataTable.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => dr[col]);
                //rows.Add(row);
                rowCollection.Add(serializer.Serialize(row));
            }

            return rowCollection;
        }
    }
}