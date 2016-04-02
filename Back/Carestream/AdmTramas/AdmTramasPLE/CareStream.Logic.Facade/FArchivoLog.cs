using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;

namespace CareStream.Logic.Facade
{
    public class FArchivoLog
    {
        public List<ArchivoLog> Listar(String tipo_ope)
        {
            DAArchivoLog objDA = new DAArchivoLog();

            List<ArchivoLog> lst = new List<ArchivoLog>();

            try
            {
                lst = objDA.Listar(tipo_ope);
            }
            catch (Exception ex)
            {
                String s = ex.Message;
            }


            return lst;
        }

        public List<ArchivoLog> ListarxLogxOpe(String tipo_ope, Int32 id_archivo_log)
        {
            DAArchivoLog objDA = new DAArchivoLog();

            List<ArchivoLog> lst = new List<ArchivoLog>();

            try
            {
                lst = objDA.ListarxLogxOpe(tipo_ope, id_archivo_log);
            }
            catch (Exception ex)
            {
                String s = ex.Message;
            }


            return lst;
        }
    }
}
