using System;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_3_0
{
    public class RegistroCompra
    {
        public Tuple<bool, string> ValidaFechaEmision(DateTime fechaEmision, DateTime periodoInformado)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaPeriodo(DateTime fechaPeriodo)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaEmision(DateTime fechaEmision)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaVencimiento(DateTime fecha, string tipoComprobante, DateTime fechaPeriodo)
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

        public Tuple<bool, string> ValidaAnioEmisionDua(DateTime fechaEmision, string tipoComprobante, DateTime periodo)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaAnioEmisionDua(DateTime fechaEmision, string tipoComprobante, DateTime periodoInformado, DateTime periodo)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroComprobante)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string tipoDocumento, string tipoDocumentoCliente,
            string tipoComprobanteModificado)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante, string numeroDocumentoCliente, TipoDocumento tipoDocumento,
            string tipoComprobanteModificado)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNombreApellido(string tipoComprobante, string nombreApellido, string tipoComprobanteModificado)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipodeCambio(decimal tipoDeCambio)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaEmisionModificada(string tipoComprobante, DateTime fechaMod)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaEmisionModificada(string tipoComprobante, DateTime periodoInformado, DateTime fechaMod)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipoComprobanteModificada(string tipoComprobante, string tipoComprobanteModificado)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroSerieComprobanteModificado(string tipoComprobante, string numSerieComprobanteModificado)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaCodigoDUA(string tipoComprobanteModificado, string codigoDUA)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroComprobanteModificado(string tipoComprobante, string numeroComprobanteModificado)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroComprobanteNoDomiciliado(string tipoComprobante, string numeroComprobanteNoDomic)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaEmisionConstancia(int mes, DateTime periodo)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaEmisionConstancia(int mes, DateTime periodo, DateTime periodoInformado)
        {
            throw new NotImplementedException();
        }
    }
}
