namespace Carestream.AdmTramas.Model.Entities
{
    public class ErrorDetalle
    {
        public long IdLibroLog { get; set; }
        public string Mensaje { get; set; }

        public string Campo { get; set; }
        public int Linea { get; set; }
    }
}
