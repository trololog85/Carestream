using System.Collections.Generic;
using System.Linq;
using MigraPle.DataAccess.Converter;
using MigraPle.DataAccess.Sql.Interfaces;
using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Repository.Sql
{
    public class SqlArchivoRepository:IArchivoRepository
    {
        private readonly IDAArchivo _daArchivo;
        private readonly IArchivoConverter _archivoConverter;

        public SqlArchivoRepository(IDAArchivo daArchivo, IArchivoConverter archivoConverter)
        {
            _daArchivo = daArchivo;
            _archivoConverter = archivoConverter;
        }

        public IEnumerable<Archivo> GetArchivos()
        {
            var archivos = _daArchivo.GetArchivos();

            return archivos.Select(_archivoConverter.Convert);
        }
    }
}
