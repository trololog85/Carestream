namespace Carestream.AdmTramas.Model.Entities.BalanceGeneral
{
    public class ParticipacionAccionaria
    {
        public long Periodo { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public short CodigoTipoAcciones { get; set; }
        public string RazonSocial { get; set; }
        public double NumeroAcciones { get; set; }
        public double PorcentajeTotal { get; set; }
        public short EstadoOperacion { get; set; }
        public string CampoLibre { get; set; }
    }
}
