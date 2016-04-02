using System.Configuration;
using System.IO;

namespace MigraPle.Api.Configurations
{
    public class ConfigurationGetter : IConfigurationGetter
    {
        public string GetConfiguration(string configuration)
        {
            return ConfigurationManager.AppSettings[configuration];
        }

        public string GetExcelConnectionString(string rutaArchivo)
        {
            var fi = new FileInfo(rutaArchivo);

            return string.Format("{0};Data Source={1};", fi.Extension == ".xlsx" ?
                ConfigurationManager.AppSettings["provExcel9"] :
                ConfigurationManager.AppSettings["provExcel8"], rutaArchivo);
        }
    }
}