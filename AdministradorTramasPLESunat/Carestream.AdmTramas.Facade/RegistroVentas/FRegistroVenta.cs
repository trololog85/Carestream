using System;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Versiones.Version_4_0;

namespace Carestream.AdmTramas.Facade.RegistroVentas
{
    public class FRegistroVenta
    {
        public string ActualizarCorrelativoVentas(string linea, string correlativo, int idLibroLog)
        {
            string str = string.Empty;
            DALibroLog daLibroLog = new DALibroLog(new AdmTramasContainer());
            try
            {
                daLibroLog.ActualizarCorrelativoVentas(idLibroLog, correlativo, linea);
            }
            catch (Exception ex)
            {
                str = string.Format("Exception: {0} {1} Fuente: {2}.", (object)ex.Message, (object)Environment.NewLine, (object)ex.StackTrace);
            }
            return str;
        }
    }
}
