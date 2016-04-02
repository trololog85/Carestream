using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Converter
{
    public interface IOperacionConverter
    {
        Operacion Convert(Sql.Model.Operacion operacion);
        Sql.Model.Operacion Convert(Operacion operacion);
    }
}
