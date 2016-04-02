using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace CareStream.Utils
{
    public class Connection
    {
        public static String DbConnection
        {
            get { return ConfigurationManager.ConnectionStrings["DBConnection"].ToString(); }
        }

        public static String ExcelConnection(String rutaArchivo)
        {
            FileInfo fi = new FileInfo(rutaArchivo);

            String connection;

            if (fi.Extension == ".xlsx")
            {
                connection = ConfigurationManager.AppSettings["provExcel9"].ToString() +
                    ";Data Source=" + rutaArchivo + ";";
            }
            else
            {
                connection = ConfigurationManager.AppSettings["provExcel8"].ToString() +
                    ";Data Source=" + rutaArchivo + ";";
            }

            return connection;
        }
    }
}
