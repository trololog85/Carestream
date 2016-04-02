using System.Collections.Generic;
using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Repository
{
    public interface IOperacionRepository
    {
        IEnumerable<Operacion> GetOperaciones(TipoOperacion tipoOperacion);
        Operacion GetOperacionById(int id);
        int InsertOperacion(Operacion operacion);
        IEnumerable<Operacion> Get(int idArchivo);
    }
}
    