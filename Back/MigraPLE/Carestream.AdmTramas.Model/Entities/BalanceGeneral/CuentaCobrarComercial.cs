using System;

namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class CuentaCobrarComercial
    {
        public long Periodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroAsientoContable { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaEmisionComprobante { get; set; }
        public long MontoCuentaCobrar { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
