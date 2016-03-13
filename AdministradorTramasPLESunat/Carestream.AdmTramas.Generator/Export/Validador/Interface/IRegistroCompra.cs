using System;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Generator.Export.Validador.Interface
{
    public interface IRegistroCompra
    {
        Tuple<bool, string> ValidaFechaPeriodo(DateTime fechaPeriodo);
        Tuple<bool, string> ValidaFechaEmision(DateTime fechaEmision);
        Tuple<bool, string> ValidaFechaVencimiento(DateTime fecha, string tipoComprobante, DateTime fechaPeriodo);
        Tuple<bool, string> ValidaTipoComprobante(string tipoComprobante);
        Tuple<bool, string> ValidaNumeroSerieComprobante(TipoDocumento tipoDocumentoCliente,string numeroDocumentoCliente, string numeroSerie);
        Tuple<bool, string> ValidaAnioEmisionDua(DateTime fechaEmision, string tipoComprobante, DateTime periodo);
        Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroComprobante);
        Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string tipoDocumento,string tipoDocumentoCliente, string tipoComprobanteModificado);
        Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante,string numeroDocumentoCliente, TipoDocumento tipoDocumento, string tipoComprobanteModificado);
        Tuple<bool, string> ValidaNombreApellido(string tipoComprobante, string nombreApellido,string tipoComprobanteModificado);
        Tuple<bool, string> ValidaTipodeCambio(decimal tipoDeCambio);
        Tuple<bool, string> ValidaFechaEmisionModificada(string tipoComprobante, DateTime fechaMod);
        Tuple<bool, string> ValidaTipoComprobanteModificada(string tipoComprobante, string tipoComprobanteModificado);
        Tuple<bool, string> ValidaNumeroSerieComprobanteModificado(string tipoComprobante, string numSerieComprobanteModificado);
        Tuple<bool, string> ValidaCodigoDUA(string tipoComprobanteModificado, string codigoDUA);
        Tuple<bool, string> ValidaNumeroComprobanteModificado(string tipoComprobante, string numeroComprobanteModificado);
        Tuple<bool, string> ValidaNumeroComprobanteNoDomiciliado(string tipoComprobante, string numeroComprobanteNoDomic);
        Tuple<bool, string> ValidaFechaEmisionConstancia(DateTime fechaPeriodo, DateTime fechaEmision);
        Tuple<bool, string> ValidaTipoDocumentoIdentidad(string tipoComprobante,
            string tipoDocumentoCliente, string tipoComprobanteModificado);
        Tuple<bool, string> ValidaIGV(decimal igv, decimal baseImponible);
        Tuple<bool, string> ValidaImporteTotal(decimal importeTotal, decimal igv, decimal baseImponible, decimal igv2, decimal baseImponible2, decimal igv3, decimal baseImponible3, decimal valorAdquisicionNoGravada, decimal otrosTributos);
        Tuple<bool, string> ValidaClasificacionBienes(string clasificacionBienes);
    }
}
