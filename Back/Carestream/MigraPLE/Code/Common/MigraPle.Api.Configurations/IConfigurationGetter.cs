namespace MigraPle.Api.Configurations
{
    public interface IConfigurationGetter
    {
        string GetConfiguration(string configuration);
        string GetExcelConnectionString(string rutaArchivo);
    }
}