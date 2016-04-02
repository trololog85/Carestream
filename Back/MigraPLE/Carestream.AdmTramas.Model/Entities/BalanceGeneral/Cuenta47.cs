using System;

namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class Cuenta47
    {
        public long FechaPeriodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroCorrelativo { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaEmision { get; set; }
        public string ApellidosNombres { get; set; }
        public double CodigoCuentaAsociada { get; set; }
        public double MontoPendientePago { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
