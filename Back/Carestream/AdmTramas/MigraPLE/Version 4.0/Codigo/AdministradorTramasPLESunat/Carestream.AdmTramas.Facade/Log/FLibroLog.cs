using System;
using System.Collections.Generic;
using System.Linq;
using Carestream.AdmTramas.Converter;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Versiones.Version_4_0;
using Carestream.AdmTramas.Facade.Generator.Interface;
using LibroLog = Carestream.AdmTramas.Model.Entities.LibroLog;

namespace Carestream.AdmTramas.Facade.Log
{
    public class FLibroLog:IFLibroLog
    {
        public Tuple<string, int> RegistrarLog(LibroLog libroLog)
        {
            var daLibro = LibroLogConverter.ConvertIn(libroLog);

            int id;

            var message = "";

            var da = new DALibroLog(new AdmTramasContainer());

            try
            {
                id = da.Guardar(daLibro);
            }
            catch (Exception ex)
            {
                message = String.Format("Exception: {0} {1} Source: {2}.", ex.Message,
                    Environment.NewLine, ex.InnerException);
                return new Tuple<string, int>(message, 0);
            }

            return new Tuple<string, int>(message, id);
        }

        public IEnumerable<LibroLog> Listar(string tipoLog)
        {
            var lstLibroLog = new List<DataAccess.Model.LibroLog>();

            try
            {
                var da = new DALibroLog(new AdmTramasContainer());

                lstLibroLog = da.Listar(tipoLog);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }

            return lstLibroLog.Select(LibroLogConverter.ConvertOut).ToList();
        }
    }
}
