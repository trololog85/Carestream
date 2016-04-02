using System;

namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class CuentaCobranzaDudosa
    {
        public long FechaPeriodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroAsientoContable { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public short TipoComprobante { get; set; }
        public string NumeroSerieComprobante { get; set; }
        public string NumeroComprobantePago { get; set; }
        public DateTime FechaEmisionComprobante { get; set; }
        public double MontoDeudor { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
