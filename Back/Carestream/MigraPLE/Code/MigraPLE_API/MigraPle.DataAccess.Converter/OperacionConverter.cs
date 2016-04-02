using MigraPle.DataAccess.Converter;
using MigraPle.Model.Entities;

namespace MigraPLE.DataAccess.Converter
{
    public class OperacionConverter : IOperacionConverter
    {
        public Operacion Convert(MigraPle.DataAccess.Sql.Model.Operacion operacion)
        {
            return new Operacion
            {
                FechaOperacion = operacion.fechaOperacion,
                Id = operacion.id,
                IdArchivo = (int)operacion.idArchivo,
                NombreArchivo = operacion.nombre
            };
        }

        public MigraPle.DataAccess.Sql.Model.Operacion Convert(Operacion operacion)
        {
            return new MigraPle.DataAccess.Sql.Model.Operacion
            {
                idTipoOperacion = (int)operacion.TipoOperacion,
                periodo = operacion.Periodo,
                fechaOperacion = operacion.FechaOperacion,
                idArchivo = operacion.IdArchivo,
                nombre = operacion.NombreArchivo
            };
        }
    }
}