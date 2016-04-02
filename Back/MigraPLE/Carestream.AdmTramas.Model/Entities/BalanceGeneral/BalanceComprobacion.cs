namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class BalanceComprobacion
    {
        public long Periodo { get; set; }
        public double CodigoCuentaContable { get; set; }
        public double SaldoDeudor { get; set; }
        public double SaldoAcreedor { get; set; }
        public double MovimientoDebe { get; set; }
        public double MovimientoHaber { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
