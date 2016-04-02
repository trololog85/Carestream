namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class BeneficioSocialTrabajador
    {
        public long Periodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroCorrelativoAsiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string ApellidosNombres { get; set; }
        public double SaldoFinal { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
