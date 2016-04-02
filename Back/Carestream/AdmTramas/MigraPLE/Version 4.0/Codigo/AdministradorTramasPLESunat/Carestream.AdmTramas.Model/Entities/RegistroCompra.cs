using System;

namespace Carestream.AdmTramas.Model.Entities
{
    public class RegistroCompra
    {
        public DateTime FechaPeriodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroCorrelativo { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoComprobante { get; set; }
        public string NumeroSerieComprobante { get; set; }
        public string AnioEmisionComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public string FlagOperacionesDiarias { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string ApellidoNombreRazonSocial { get; set; }
        public decimal BaseImponible1 { get; set; }
        public decimal IGV1 { get; set; }
        public decimal BaseImponible2 { get; set; }
        public decimal IGV2 { get; set; }
        public decimal BaseImponible3 { get; set; }
        public decimal IGV3 { get; set; }
        public decimal AdquisicionNoGravada { get; set; }
        public decimal ISC { get; set; }
        public decimal OtrosTributos { get; set; }
        public decimal ImporteTotal { get; set; }
        public decimal TipoDeCambio { get; set; }
        public DateTime FechaEmisionComprobante { get; set; }
        public string TipoComprobanteModificado { get; set; }
        public string NumeroSerieModificado { get; set; }
        public string CodigoDUA { get; set; }
        public string NumeroComprobanteModificado { get; set; }
        public string NumeroComprobanteNoDomiciliado { get; set; }
        public DateTime FechaEmisionConstancia { get; set; }
        public string NumeroConstancia { get; set; }
        public string MarcaComprobante { get; set; }
        public string EstadoAnotacion { get; set; }
        public int NumLinea { get; set; }
        public decimal Total { get; set; }
        public long IdLibroLog { get; set; }
    }
}
