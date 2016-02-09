using System;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Generator.Export.Validador.Interface
{
    public interface IRegistroVenta
    {
        Tuple<bool,string> ValidarNumeroCorrelativo(TipoContribuyente tipoContribuyente);
        Tuple<bool, string> ValidaFechaEmisionComprobante(string estado, DateTime fecha, DateTime periodo);
        Tuple<bool, string> ValidaFechaVencimiento(string tipoComprobante, string estado, DateTime fecha,
            DateTime periodo);
        Tuple<bool, string> ValidaTipoComprobante(string tipoComprobante);
        Tuple<bool, string> ValidaNumeroSerieComprobante(TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente, string numeroSerie);
        Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroComprobante);

        Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string oportunidadAnotacion,
            string tipoDocumento,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string tipoDocumentoCliente);

        Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante,string oportunidadAnotacion, 
            decimal valorFacturadoExportacion,decimal importeTotalComprobante,string numeroDocumentoCliente,TipoDocumento tipoDocumento);

        Tuple<bool, string> ValidaNombreApellido(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string nombreApellido);
        Tuple<bool, string> ValidaIVAP(string tipoComprobante, string oportunidadAnotacion, decimal? valor);
        Tuple<bool, string> ValidaImpuestoIVAP(string tipoComprobante, string oportunidadAnotacion, decimal? valor);
        Tuple<bool, string> ValidaImporteTotal(string tipoComprobante, decimal valor);
        Tuple<bool, string> ValidaTipoCambio(decimal valor);
        Tuple<bool, string> ValidaFechaEmisionComprobanteModificado(string tipoComprobante, DateTime fechaModificada,
            string oportunidadAnotacion,DateTime fechaPeriodo);
        Tuple<bool, string> ValidaTipoComprobanteModificado(string tipoComprobante, string oportunidadAnotacion);
        Tuple<bool, string> ValidaNumeroSerieComprobanteModificado(string tipoComprobante, string tipoComprobanteModificado, string numeroSerieComprobante);
        Tuple<bool, string> ValidarNumeroComprobanteModificado(string tipoComprobante,
            string oportunidadAnotacion,string numeroSerieComprobante);
        Tuple<bool, string> ValidaValorEmbarcadoExportacion(string tipoComprobanteModificado,decimal? valor);
        Tuple<bool, string> ValidaTicket(string ticket, string tipoDocumento,decimal monto);
        Tuple<bool,string> ValidaTipoDocumento(string tipoComprobante, string oportunidadAnotacion,
            string tipoDocumento,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string tipoDocumentoCliente);
        Tuple<bool, string> ValidaNumeroDocumento(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, 
            string numeroDocumentoCliente, TipoDocumento tipoDocumento);
    }
}
