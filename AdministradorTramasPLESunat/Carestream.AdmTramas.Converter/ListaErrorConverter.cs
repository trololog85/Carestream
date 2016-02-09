using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.Converter
{
    public class ListaErrorConverter
    {
        public static Model.Entities.ErrorLinea ConvertOut(ErrorLinea log)
        {
            return new Model.Entities.ErrorLinea
            {
                Campo = log.Campo,
                Descripcion = log.Descripcion,
                Id = log.Id,
                IdLibroLog = log.IdLibroLog,
                Linea = log.Linea
            };
        }
    }
}
