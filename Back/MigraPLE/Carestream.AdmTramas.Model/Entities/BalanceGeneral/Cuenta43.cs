using System;

namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class Cuenta43
    {
        public long FechaPeriodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroCorrelativoAsiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaEmision { get; set; }
        public string RazonSocial { get; set; }
        public double MontoCuentaPagar { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
