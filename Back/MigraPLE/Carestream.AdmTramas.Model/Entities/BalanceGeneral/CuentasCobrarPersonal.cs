using System;

namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class CuentasCobrarPersonal
    {
        public long FechaPeriodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroAsientoContable { get; set; }
        public string TipoDocumentoIdentidad { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaInicioOperacion { get; set; }
        public double MontoCuentaCobrar { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
