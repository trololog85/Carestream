using System.Collections.Generic;
using System.Linq;
using MigraPle.DataAccess.Converter;
using MigraPle.DataAccess.Sql.Interfaces;
using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Repository.Sql
{
    public class SqlOperacionRepository : IOperacionRepository
    {
        private readonly IOperacionConverter _operacionConverter;
        private readonly IDAOperacion _daOperacion;

        public SqlOperacionRepository(IOperacionConverter operacionConverter, IDAOperacion daOperacion)
        {
            _operacionConverter = operacionConverter;
            _daOperacion = daOperacion;
        }

        public IEnumerable<Operacion> GetOperaciones(TipoOperacion tipoOperacion)
        {
            var operaciones = _daOperacion.GetOperacionesByTipo((int)tipoOperacion);

            return operaciones.Select(_operacionConverter.Convert);
        }

        public Operacion GetOperacionById(int id)
        {
            var operacion = _daOperacion.GetOperacionById(id);

            return _operacionConverter.Convert(operacion);
        }

        public int InsertOperacion(Operacion operacion)
        {
            var dbOperacion = _operacionConverter.Convert(operacion);

            _daOperacion.AddOperacion(dbOperacion);

            return dbOperacion.id;
        }

        public IEnumerable<Operacion> Get(int idArchivo)
        {
            return _daOperacion.Get(idArchivo).
                Select(_operacionConverter.Convert);
        }
    }
}