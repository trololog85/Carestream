using System.Collections.Generic;
using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Repository
{
    public interface IArchivoRepository
    {
        IEnumerable<Archivo> GetArchivos();
    }
}
