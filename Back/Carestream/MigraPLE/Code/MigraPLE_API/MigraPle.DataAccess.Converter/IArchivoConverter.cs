using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Converter
{
    public interface IArchivoConverter
    {
        Archivo Convert(Sql.Model.Archivo operacion);
    }
}
