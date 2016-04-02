namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class CuentaInversionMobilaria
    {
        public long Periodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroAsientoContable { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public short CodigoTitulo { get; set; }
        public double CantidadTitulos { get; set; }
        public double CostoTotalTitulos { get; set; }
        public double ProvisionTotalTitulos { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
