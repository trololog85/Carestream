using System;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_3_0
{
    public class RegistroVenta
    {
        public string ObtienePeriodo(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidarNumeroCorrelativo(TipoContribuyente tipoContribuyente)
        {
            throw new NotImplementedException();
        }

        public string ObtieneNumeroCorrelativoAsientoContable(TipoAsiento tipoAsiento)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaEmisionComprobante(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaVencimiento(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipoComprobante(string tipoComprobante)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroSerieComprobante(TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente, string numeroSerie)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroComprobante)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string oportunidadAnotacion, string tipoDocumento,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string tipoDocumentoCliente)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string numeroDocumentoCliente,
            TipoDocumento tipoDocumento)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNombreApellido(string tipoComprobante, string oportunidadAnotacion, decimal valorFacturadoExportacion,
            decimal importeTotalComprobante, string nombreApellido)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaIVAP(string tipoComprobante, string oportunidadAnotacion, decimal? valor)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaImpuestoIVAP(string tipoComprobante, string oportunidadAnotacion, decimal? valor)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaImporteTotal(string tipoComprobante, decimal valor)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipoCambio(decimal valor)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaEmisionComprobanteModificado(string tipoComprobante, DateTime fechaModificada,
            string oportunidadAnotacion, DateTime fechaPeriodo)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipoComprobanteModificado(string tipoComprobante, string oportunidadAnotacion)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroSerieComprobanteModificado(string tipoComprobante, string tipoComprobanteModificado,
            string numeroSerieComprobante)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidarNumeroComprobanteModificado(string tipoComprobante, string oportunidadAnotacion,
            string numeroSerieComprobante)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaValorEmbarcadoExportacion(string tipoComprobanteModificado, decimal? valor)
        {
            throw new NotImplementedException();
        }

        public string ObtieneOportunidaddeAnotation()
        {
            throw new NotImplementedException();
        }
    }
}
