namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class EstadoCambioPatrimonio
    {
        public long Periodo { get; set; }
        public short CodigoCatalogo { get; set; }
        public string CodigoCuentaContable { get; set; }
        public double Capital { get; set; }
        public double AccionesInversion { get; set; }
        public double CapitalAdicional { get; set; }
        public double ResultadoNoRealizado { get; set; }
        public double ReservaLegal { get; set; }
        public double OtraReserva { get; set; }
        public double ResultadoAcumulado { get; set; }
        public double DiferenciaConversion { get; set; }
        public double AjustePatrimonio { get; set; }
        public double ResultadoNeto { get; set; }
        public double ExcedenteRevaluacion { get; set; }
        public double ResultadoEjercicio { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
