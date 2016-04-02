using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Converter
{
    public class ArchivoConverter : IArchivoConverter
    {
        public Archivo Convert(Sql.Model.Archivo archivo)
        {
            return new Archivo
            {
                Id = archivo.id,
                Codigo = archivo.codigo,
                Nombre =  archivo.nombre
            };
        }
    }
}