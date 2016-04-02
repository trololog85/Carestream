using System;

namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class CuentaIntangible
    {
        public long Periodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroAsientoContable { get; set; }
        public DateTime FechaInicioOperacion { get; set; }
        public double CodigoCuentaContable { get; set; }
        public string DescripcionIntangible { get; set; }
        public double ValorIntangible { get; set; }
        public double AmortizacionContable { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
