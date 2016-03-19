using System;
using System.Dynamic;

namespace Carestream.AdmTramas.Model.Entities
{
    public class LibroLog
    {
        public int Id { get; set; }
        public short IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string sFechaCarga { get; set; }
        public string sFechaGeneracion { get; set; }
        public int Registros { get; set; }
        public string RUC { get; set; }
        public string IndicadorOperacion { get; set; }
        public string IndicadorMoneda { get; set; }
        public string IndicadorLibro { get; set; }
        public string TipoLog { get; set; }
        public int TotalErrores { get; set; }
        public DateTime FechaPeriodo { get; set; }
    }
}