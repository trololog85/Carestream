using System.Collections.Generic;
using MigraPle.DataAccess.Sql.Model;

namespace MigraPle.DataAccess.Sql.Interfaces
{
    public interface IDAOperacion
    {
        IEnumerable<Operacion> GetOperaciones();
        IEnumerable<Operacion> GetOperacionesByTipo(int tipoOperacion);
        void AddOperacion(Operacion operacion);
        Operacion GetOperacionById(int id);
        IEnumerable<Operacion> Get(int idArchivo);
    }
}
