using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CareStream.Data.Access
{
    public class DAArchivoLogDetalle
    {
        public void Guardar(ArchivoLogDetalle obj)
        {
            BDTramaPLEEntities ent = new BDTramaPLEEntities();

            ent.AddToArchivoLogDetalles(obj);

            ent.SaveChanges();
        }

        public List<ArchivoLogDetalle> ListarxArchivoLog(Int32 id_archivo_log)
        {
            List<ArchivoLogDetalle> lst = new List<ArchivoLogDetalle>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ObtieneArchivoLogDetallexIdArchivoLog(id_archivo_log).ToList<ArchivoLogDetalle>();
            }

            return lst;
        }
    }
}
