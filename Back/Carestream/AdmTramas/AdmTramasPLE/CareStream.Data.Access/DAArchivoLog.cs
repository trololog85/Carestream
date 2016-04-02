using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CareStream.Data.Access
{
    public class DAArchivoLog
    {
        public Int32 Guardar(ArchivoLog obj)
        {
            BDTramaPLEEntities ent = new BDTramaPLEEntities();

            ent.AddToArchivoLogs(obj);

            ent.SaveChanges();

            Int32 id = Convert.ToInt32(ent.ObtieneMaxArchivoLogxArchivo(obj.id_archivo).ElementAt(0).id);

            return id;
        }

        public List<ArchivoLog> Listar(String tipo_ope)
        {
            List<ArchivoLog> lst = new List<ArchivoLog>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ArchivoLog_Listar(tipo_ope).ToList<ArchivoLog>();
            }

            return lst;
        }

        public List<ArchivoLog> ListarxLogxOpe(String tipo_ope,Int32 id_archivo_log)
        {
            List<ArchivoLog> lst = new List<ArchivoLog>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ObtieneArchivoLogxIdxOPe(tipo_ope,id_archivo_log).ToList<ArchivoLog>();
            }

            return lst;
        }

        public Int32 ObtieneMaximoID(Int32 id_archivo)
        {
            Int32 id = 0;

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                id = Convert.ToInt32(ent.ObtieneMaxArchivoLogxArchivo(id_archivo).ElementAt(0).id);
            }

            return id;
        }
    }
}
