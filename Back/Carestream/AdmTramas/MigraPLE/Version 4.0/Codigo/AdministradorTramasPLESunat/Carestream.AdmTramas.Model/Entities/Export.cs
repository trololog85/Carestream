using System.Windows.Controls;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Model.Entities
{
    public class Export
    {
        public string RutaArchivoImport { get; set; }
        public string RutaArchivoExport { get; set; }
        public short IdLibro { get; set; }
        public string NumeroRuc { get; set; }
        public string IdOperacion { get; set; }
        public int ContenidoLibro { get; set; }
        public string IdMoneda { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int IdLibroLog { get; set; }
        public TipoLibro TipoLibro { get; set; }
        public string IndicadorLibro { get; set; }
        public string CodigoLibro { get; set; }
        public ProgressBar ProgressBar { get; set; }
        public Label LblMessage { get; set; }
    }
}
