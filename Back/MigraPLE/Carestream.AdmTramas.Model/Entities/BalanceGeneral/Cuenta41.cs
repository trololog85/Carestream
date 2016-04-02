namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class Cuenta41
    {
        public long FechaPeriodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroCorrelativoAsiento { get; set; }
        public double CodigoCuentaContable { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodigoTrabajador { get; set; }
        public string ApellidosNombres { get; set; }
        public double SaldoFinal { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
