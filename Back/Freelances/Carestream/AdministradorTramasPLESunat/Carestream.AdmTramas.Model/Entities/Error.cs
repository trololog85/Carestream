using System.Collections.Generic;

namespace Carestream.AdmTramas.Model.Entities
{
    public class Error
    {
        public int IdLibroLog { get; set; }
        public int Linea { get; set; }
        public List<ErrorDetalle> Detalles { get; set; }
    }
}
