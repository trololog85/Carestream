using System;

namespace Carestream.AdmTramas.Model.Entities
{
    public class LibroDiario
    {
        public DateTime FechaPeriodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroCorrelativoContable { get; set; }
        public string CodigoPlanCuentas { get; set; }
        public string CodigoCuentaContable { get; set; }
        public DateTime FechaOperacion { get; set; }
        public string Glosa { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public string CorrelativoVentas { get; set; }
        public string CorrelativoCompras { get; set; }
        public string CorrelativoConsignaciones { get; set; }
        public string EstadoOperacion { get; set; }
        public string CamposLibres { get; set; }
        public int NumeroLinea { get; set; }
        public long IdLibroLog { get; set; }
        public short Correlativo { get; set; }
    }
}
