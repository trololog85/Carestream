using System.Collections.Generic;
using System.Linq;
using MigraPle.DataAccess.Sql.Interfaces;
using MigraPle.DataAccess.Sql.Model;

namespace MigraPle.DataAccess.Sql
{
    public class DAOperacionDetalle : IDAOperacionDetalle
    {
        public void Add(IEnumerable<OperacionDetalle> detalles)
        {
            using (var context = new MigraPLE_Entities())
            {
                context.OperacionDetalle.AddRange(detalles);

                context.SaveChanges();
            }
        }

        public IEnumerable<OperacionDetalle> GetDetalles(int idOperacion)
        {
            IEnumerable<OperacionDetalle> detalles;

            using (var context = new MigraPLE_Entities())
            {
                detalles = context.OperacionDetalle.Where(o => o.idOperacion == idOperacion);
            }

            return detalles;
        }
    }
}