namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class EstadoGananciaPerdida
    {
        public long Periodo { get; set; }
        public short CodigoCatalogo { get; set; }
        public string CodigoCuentaContable { get; set; }
        public double SaldoRubro { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
