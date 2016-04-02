namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class DetalleSaldoCuenta
    {
        public long Periodo { get; set; }
        public double CodigoCuentaContable { get; set; }
        public int CodigoEntidadFinanciera { get; set; }
        public string NumeroCuentaFinanciera { get; set; }
        public string TipoMoneda { get; set; }
        public double SaldoDeudor { get; set; }
        public double SaldoAcreedor { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
