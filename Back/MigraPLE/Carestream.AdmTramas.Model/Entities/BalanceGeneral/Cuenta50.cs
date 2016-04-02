namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class Cuenta50
    {
        public double Periodo { get; set; }
        public double ImporteCapitalSocial { get; set; }
        public double ValorNominal { get; set; }
        public double NumeroAccionesSuscritas { get; set; }
        public double NumeroAccionesPagadas { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
