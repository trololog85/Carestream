using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Converter
{
    public interface IOperacionDetalleConverter
    {
        OperacionDetalle Convert(Sql.Model.OperacionDetalle operacion);
        Sql.Model.OperacionDetalle Convert(OperacionDetalle operacion);
        Sql.Model.OperacionDetalle Convert(string registro, int idOperacion);

    }
}
