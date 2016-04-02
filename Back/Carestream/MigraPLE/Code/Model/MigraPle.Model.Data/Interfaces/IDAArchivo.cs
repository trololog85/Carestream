using System.Collections.Generic;
using MigraPle.DataAccess.Sql.Model;

namespace MigraPle.DataAccess.Sql.Interfaces
{
    public interface IDAArchivo
    {
        IEnumerable<Archivo> GetArchivos();
    }
}
