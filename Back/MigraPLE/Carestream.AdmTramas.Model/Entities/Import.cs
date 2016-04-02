using System;
using System.Windows.Controls;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Model.Entities
{
    public class Import
    {
        public string Ruta { get; set; }
        public string Ruc { get; set; }
        public string Operacion { get; set; }
        public string Moneda { get; set; }
        public string Registro { get; set; }
        public short IdLibro { get; set; }
        public TipoLibro Tipo { get; set; }
        public DateTime Periodo { get; set; }
        public ProgressBar ProgressBar { get; set; }
        public Label LblMessage { get; set; }
    }
}
