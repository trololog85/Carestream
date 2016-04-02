using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Converter
{
    public class OperacionDetalleConverter : IOperacionDetalleConverter
    {
        public OperacionDetalle Convert(Sql.Model.OperacionDetalle operacion)
        {
            return new OperacionDetalle
            {
                IdOperacion = operacion.idOperacion,
                Registro = operacion.registro
            };
        }

        public Sql.Model.OperacionDetalle Convert(OperacionDetalle operacion)
        {
            return new Sql.Model.OperacionDetalle
            {
                idOperacion = operacion.IdOperacion,
                registro = operacion.Registro
            };
        }

        public Sql.Model.OperacionDetalle Convert(string registro, int idOperacion)
        {
            return new Sql.Model.OperacionDetalle
            {
                idOperacion = idOperacion,
                registro = registro
            };
        }
    }
}