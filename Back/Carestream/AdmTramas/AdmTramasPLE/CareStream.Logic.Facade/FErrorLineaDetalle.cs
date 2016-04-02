using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;

namespace CareStream.Logic.Facade
{
    public class FErrorLineaDetalle
    {
        public List<ErrorLineaDetalle> ListarxArchivoLog(Int32 id_archivo_log)
        {
            DAErrorLineaDetalle objDA = new DAErrorLineaDetalle();

            List<ErrorLineaDetalle> lst = new List<ErrorLineaDetalle>();

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

        public String Guardar(ErrorLineaDetalle obj)
        {
            String rpta = String.Empty;

            DAErrorLineaDetalle objDA = new DAErrorLineaDetalle();

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
