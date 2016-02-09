using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Converter
{
    public class CodigoDetalleConverter
    {
        public static CodigoDetalle Convert(DataAccess.Model.CodigoDetalle codigoDetalle)
        {
            return new CodigoDetalle
                   {
                       Campo1 = codigoDetalle.Campo1,
                       Campo2 = codigoDetalle.Campo2,
                       Campo3 = codigoDetalle.Campo3,
                       Campo4 = codigoDetalle.Campo4,
                       Codigo = codigoDetalle.Codigo,
                       Descripcion = codigoDetalle.Descripcion,
                       Etiqueta = codigoDetalle.Etiqueta,
                       Id = codigoDetalle.Id,
                       Tipo = codigoDetalle.Tipo
                   };
        }
    }
}
