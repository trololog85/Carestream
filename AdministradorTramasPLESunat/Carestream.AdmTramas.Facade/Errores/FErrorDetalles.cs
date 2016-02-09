using System;
using System.Collections.Generic;
using System.Linq;
using Carestream.AdmTramas.Converter;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Versiones.Version_4_0;

namespace Carestream.AdmTramas.Facade.Errores
{
    public class FErrorDetalles
    {
        public IEnumerable<Model.Entities.ErrorLinea> Listar(int idLogImport)
        {
            var lstErrores = new List<ErrorLinea>();

            try
            {
                var da = new DAErrorDetalle(new AdmTramasContainer());

                lstErrores = da.Listar(idLogImport);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }

            return lstErrores.Select(ListaErrorConverter.ConvertOut).ToList();
        }
    }
}
