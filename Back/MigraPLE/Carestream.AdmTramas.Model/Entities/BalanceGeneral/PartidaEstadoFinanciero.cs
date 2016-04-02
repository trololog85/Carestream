namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class PartidaEstadoFinanciero
    {
        public long Periodo { get; set; }
        public short CodigoCatalogo { get; set; }
        public string CodigoCuentaContable { get; set; }
        public string DescripcionCuentaContable { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
