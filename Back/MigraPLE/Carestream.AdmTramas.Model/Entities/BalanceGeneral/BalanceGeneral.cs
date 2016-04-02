namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class BalanceGeneral
    {
        public long Periodo { get; set; }
        public short CodigoCatalogo { get; set; }
        public string CodigoCuentaContacto { get; set; }
        public string SaldoRubroContable { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
