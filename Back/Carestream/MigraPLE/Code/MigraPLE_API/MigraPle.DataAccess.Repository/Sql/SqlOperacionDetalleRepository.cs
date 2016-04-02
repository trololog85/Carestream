using System.Collections.Generic;
using System.Linq;
using MigraPle.DataAccess.Converter;
using MigraPle.DataAccess.Sql.Interfaces;
using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Repository.Sql
{
    public class SqlOperacionDetalleRepository : IOperacionDetalleRepository
    {
        private readonly IOperacionDetalleConverter _operacionDetalleConverter;
        private readonly IDAOperacionDetalle _daOperacionDetalle;

        public SqlOperacionDetalleRepository(IOperacionDetalleConverter operacionDetalleConverter, 
            IDAOperacionDetalle daOperacionDetalle)
        {
            _operacionDetalleConverter = operacionDetalleConverter;
            _daOperacionDetalle = daOperacionDetalle;
        }

        public void Insert(IEnumerable<string> detalles,int idOperacion)
        {
            var sqlDetalles = detalles.
                Select(d => _operacionDetalleConverter.Convert(d,idOperacion));

            _daOperacionDetalle.Add(sqlDetalles);
        }

        public IEnumerable<OperacionDetalle> GetDetalles(int idOperacion)
        {
            return _daOperacionDetalle.GetDetalles(idOperacion).
                Select(_operacionDetalleConverter.Convert);
        }
    }
}