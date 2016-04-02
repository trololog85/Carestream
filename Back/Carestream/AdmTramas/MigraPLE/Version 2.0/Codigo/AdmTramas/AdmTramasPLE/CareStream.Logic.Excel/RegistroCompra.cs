using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareStream.Logic.Excel
{
    public class RegistroCompra
    {
        public Int32 NumFila { get; set; }
        public String NoOpeRac { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public String TipoComprobante { get; set; }
        public String NoSerieComprobante { get; set; }
        public Int32 AnioEmisionComprobante { get; set; }
        public String NumeroComprobante { get; set; }
        public String TipoDocumento { get; set; }
        public String NumDocumento { get; set; }
        public String ApellNombRazSoc { get; set; }
        public Decimal BaseImpGravada { get; set; }
        public Decimal IGVGravado { get; set; }
        public Decimal BaseImpMixta { get; set; }
        public Decimal IGVMixto { get; set; }
        public Decimal BaseImpNoGravada { get; set; }
        public Decimal IGVNoGravado { get; set; }
        public Decimal AdquisicNoGravada { get; set; }
        public Decimal ISC { get; set; }
        public Decimal OtrosTributos { get; set; }
        public Decimal Total { get; set; }
        public String CompNoDomic { get; set; }
        public String NumConstancia { get; set; }
        public DateTime FechaEmisionConstancia { get; set; }
        public Decimal TipoCambio { get; set; }
        public DateTime FechaOriginal { get; set; }
        public String TipoDocumentoOriginal { get; set; }
        public String NroSerieOriginal { get; set; }
        public String NroDocumentoOriginal { get; set; }
        public String Pago { get; set; }
        public DateTime FechaPago { get; set; }
        public String Detraccion { get; set; }
        public Decimal TasaDetraccion { get; set; }
        public Decimal ImporteDetraccion { get; set; }
        public String Retencion { get; set; }
        public Decimal ImporteRetencion { get; set; }
        public String MotivoRetencion { get; set; }
        public Decimal RevisionTasa { get; set; }
        public Decimal RevisionTipoCambio { get; set; }
        public String RevisionVerificacion { get; set; }
        public Decimal BaseRevision { get; set; }
        public Decimal IGVRevision { get; set; }
        public String TipoGasto { get; set; }
        public String Recepcion { get; set; }
        public String Comentario1 { get; set; }
        public String Comentario2 { get; set; }
        public String VB { get; set; }
        public Decimal CompraGravadaPais { get; set; }
        public Decimal CompraGravadaExterior { get; set; }
        public Decimal CompraNoGravada { get; set; }
        public Decimal IGVPais { get; set; }
        public Decimal Exterior { get; set; }
        public Decimal OtrosCargos { get; set; }
        public Decimal Total1 { get; set; }
        public Char Estado { get; set; }
    }
}
