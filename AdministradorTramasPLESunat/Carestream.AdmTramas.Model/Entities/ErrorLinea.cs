namespace Carestream.AdmTramas.Model.Entities
{
    public class ErrorLinea
    {
        public int Id { get; set; }
        public int IdLibroLog { get; set; }
        public int Linea { get; set; }
        public string Campo { get; set; }
        public string Descripcion { get; set; }
    }
}
