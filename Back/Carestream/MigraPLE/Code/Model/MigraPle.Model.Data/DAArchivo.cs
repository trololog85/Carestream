using System.Collections.Generic;
using System.Linq;
using MigraPle.DataAccess.Sql.Interfaces;
using MigraPle.DataAccess.Sql.Model;

namespace MigraPle.DataAccess.Sql
{
    public class DAArchivo:IDAArchivo
    {
        public IEnumerable<Archivo> GetArchivos()
        {
            using (var context = new MigraPLE_Entities())
            {
                return context.Archivo.ToList();
            }
        }
    }
}
