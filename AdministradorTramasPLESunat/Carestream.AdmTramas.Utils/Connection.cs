using System;
using System.Configuration;
using System.IO;

namespace Carestream.AdmTramas.Utils
{
    public class Connection
    {
        public static String DbConnection
        {
            get { return ConfigurationManager.ConnectionStrings["DBConnection"].ToString(); }
        }

        public static String ExcelConnection(String rutaArchivo)
        {
            var fi = new FileInfo(rutaArchivo);

            var connection = string.Format("{0};Data Source={1};", fi.Extension == ".xlsx" ? 
                ConfigurationManager.AppSettings["provExcel9"] : 
                ConfigurationManager.AppSettings["provExcel8"], rutaArchivo);

            return connection;
        }
    }
}
