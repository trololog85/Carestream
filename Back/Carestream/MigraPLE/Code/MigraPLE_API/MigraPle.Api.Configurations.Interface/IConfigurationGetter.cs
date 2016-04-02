namespace MigraPle.Api.Configurations.Interface
{
    public interface IConfigurationGetter
    {
        string GetExcelConnectionString(string rutaArchivo);
    }
}