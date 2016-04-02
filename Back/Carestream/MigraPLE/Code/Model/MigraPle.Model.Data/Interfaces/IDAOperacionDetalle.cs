using System.Collections.Generic;
using MigraPle.DataAccess.Sql.Model;

namespace MigraPle.DataAccess.Sql.Interfaces
{
    public interface IDAOperacionDetalle
    {
        void Add(IEnumerable<OperacionDetalle> detalles);
        IEnumerable<OperacionDetalle> GetDetalles(int idOperacion);
    }
}
