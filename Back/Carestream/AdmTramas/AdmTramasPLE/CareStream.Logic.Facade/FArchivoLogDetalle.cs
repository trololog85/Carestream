using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;

namespace CareStream.Logic.Facade
{
    public class FArchivoLogDetalle
    {
        public List<ArchivoLogDetalle> ListarxArchivoLog(Int32 id_archivo_log)
        {
            DAArchivoLogDetalle objDA = new DAArchivoLogDetalle();

            List<ArchivoLogDetalle> lst = new List<ArchivoLogDetalle>();

            try
            {
                lst = objDA.ListarxArchivoLog(id_archivo_log);
            }
            catch (Exception ex)
            {
                String s = ex.Message;
            }

            return lst;
        }

        public String Guardar(ArchivoLogDetalle obj)
        {
            String rpta = String.Empty;

            DAArchivoLogDetalle objDA = new DAArchivoLogDetalle();

            try
            {
                objDA.Guardar(obj);
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }
}
