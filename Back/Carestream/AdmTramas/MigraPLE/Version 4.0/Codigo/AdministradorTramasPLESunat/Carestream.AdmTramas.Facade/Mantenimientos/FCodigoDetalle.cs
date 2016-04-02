using System;
using System.Collections.Generic;
using System.Linq;
using Carestream.AdmTramas.Converter;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository;
using Carestream.AdmTramas.Facade.Generator.Interface;

namespace Carestream.AdmTramas.Facade
{
    public class FCodigoDetalle:ICodigoDetalle
    {
        public IEnumerable<Model.Entities.CodigoDetalle> Listar(short tipo)
        {
            var objDA = new DACodigoDetalle(new AdmTramasContainer());

            var lstDetalle = new List<CodigoDetalle>();

            try
            {
                lstDetalle = objDA.Listar(tipo);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }

            return lstDetalle.Select(CodigoDetalleConverter.Convert).ToList();
        }
    }
}
