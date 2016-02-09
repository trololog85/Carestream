using System;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Generator.Export.Mensajes;
using Carestream.AdmTramas.Model.Tipos;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Validador.Interface
{
    public interface ICommon
    {
        string ObtienePeriodo(DateTime fecha);

        Tuple<bool, string> ValidaFechaPeriodo(DateTime periodoInformado);

        string ObtieneFechaEmisionComprobante(DateTime fecha);
        Tuple<bool, string> ValidaTipoComprobante(string tipoComprobante);

        Tuple<bool, string> ValidaNumeroSerieComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroSerie);
        Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente, string numeroComprobante);
        bool ValidaPipe(string valor);

        Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion,decimal importeTotalComprobante,string tipoDocumentoCliente);

        Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string numeroDocumentoCliente,
            TipoDocumento tipoDocumento);

        Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante,
            string numeroDocumentoCliente, TipoDocumento tipoDocumento, string tipoComprobanteModificado);

        Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string tipoDocumentoCliente,
            string tipoComprobanteModificado);
    }
}
