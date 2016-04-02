using System.Collections.Generic;
using System.Linq;
using MigraPle.DataAccess.Sql.Interfaces;
using MigraPle.DataAccess.Sql.Model;

namespace MigraPle.DataAccess.Sql
{
    public class DAOperacion:IDAOperacion
    {
        public IEnumerable<Operacion> GetOperaciones()
        {
            using (var context = new MigraPLE_Entities())
            {
                return context.Operacion.ToList();
            }
        }

        public IEnumerable<Operacion> GetOperacionesByTipo(int tipoOperacion)
        {
            using (var context = new MigraPLE_Entities())
            {
                return context.Operacion.
                    Where(o => o.idTipoOperacion == tipoOperacion);
            }
        }

        public void AddOperacion(Operacion operacion)
        {
            using (var context = new MigraPLE_Entities())
            {
                context.Operacion.Add(operacion);

                context.SaveChanges();
            }
        }

        public IEnumerable<Operacion> Get(int idArchivo)
        {
            using (var context = new MigraPLE_Entities())
            {
                return context.Operacion.Where(o => o.idArchivo == idArchivo);
            }
        }

        public Operacion GetOperacionById(int id)
        {
            using (var context = new MigraPLE_Entities())
            {
                return context.Operacion.First(o => o.id == id);
            }
        }
    }
}
