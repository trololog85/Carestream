using System;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Model.Entities
{
    public class RegistroVenta
    {
        public DateTime FechaPeriodo { get; set; }
        public string NumeroCorrelativo { get; set; }
        public string TipoAsiento { get; set; }
        public DateTime FechaEmisionComprobante { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoComprobante { get; set; }
        public string NumeroSerieComprobante { get; set; }    
        public string NumeroComprobante { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreRazonSocial { get; set; }
        public decimal ValorFacturadoExportacion { get; set; }
        public decimal BaseImponibleOperacionGravada { get; set; }
        public decimal ImporteTotalOperacionExonerada { get; set; }
        public decimal ImporteTotalOperacionInafecta { get; set; }
        public decimal ISC { get; set; }
        public decimal IGV { get; set; }
        public decimal IVAP { get; set; }
        public decimal ImpuestoIVAP { get; set; }
        public decimal OtrosCargos { get; set; }
        public decimal ImporteTotalComprobante { get; set; }
        public decimal TipodeCambio { get; set; }
        public string FechaEmisionModificada { get; set; }
        public string TipoComprobanteModificado { get; set; }
        public string NumeroSerieModificado { get; set; }
        public string NumeroComprobanteModificado { get; set; }
        public decimal ValorEmbarcadoExportacion { get; set; }
        public int NumLinea { get; set; }
        public TipoDocumento TipoDocumentoModel { get; set; }
        public TipoContribuyente TipoContribuyenteModel { get; set; }
        public string OportunidadUnicaAnotacion { get; set; }
        public string Estado { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public long IdLibroLog { get; set; }
        public string Ticket { get; set; }
        public string Moneda { get; set; }
    }
}
