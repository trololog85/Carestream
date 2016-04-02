using System.Collections.Generic;
using MigraPle.Model.Entities;

namespace MigraPle.DataAccess.Repository
{
    public interface IOperacionDetalleRepository
    {
        void Insert(IEnumerable<string> detalles, int idOperacion);
        IEnumerable<OperacionDetalle> GetDetalles(int idOperacion);
    }
}
