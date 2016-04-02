using System;
using System.Collections.Generic;
using System.Configuration;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Campos;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Validador
{
    public class ValidadorLibroVentas
    {
        private readonly IRegistroVenta _iValidadorRegistroVenta;
        private long _idLibroLog;

        public ValidadorLibroVentas(IRegistroVenta iValidadorRegistroVenta)
        {
            _iValidadorRegistroVenta = iValidadorRegistroVenta;
        }

        public List<Error> ValidaRegistros(List<RegistroVenta> registroVentas)
        {
            var constanteAnulado = ConfigurationManager.AppSettings["NombreAnulado"];

            var errores = new List<Error>();

            Error error = null;

            foreach (var libro in registroVentas)
            {
                if (!libro.NombreRazonSocial.Equals(constanteAnulado))
                {
                    error = Validar(libro);
                    if (error.Detalles.Count > 0)
                        errores.Add(error);
                }
            }

            return errores;
        }

        private Error Validar(RegistroVenta registroVenta)
        {
            var error = new Error();

            var errorDetalle = new List<ErrorDetalle>();
            var result = new Tuple<bool, string>(false,"");

            var FechaComprobante = registroVenta.FechaEmisionComprobante;
            var FechaVencimiento = registroVenta.FechaVencimiento;
            var TipoComprobante = registroVenta.TipoComprobante;
            var NumeroLinea = registroVenta.NumLinea;
            var TipoDocumentoModel = registroVenta.TipoDocumentoModel;
            var NumeroDocumento = registroVenta.NumeroDocumento;
            var NumeroSerieComprobante = registroVenta.NumeroSerieComprobante;
            var NumeroComprobante = registroVenta.NumeroComprobante;
            var OportunidadUnicaAnotacion = registroVenta.OportunidadUnicaAnotacion;
            var ImporteTotalComprobante = registroVenta.ImporteTotalComprobante;
            var TipoDocumento = registroVenta.TipoDocumento;
            var ValorFacturadoExportacion = registroVenta.ValorFacturadoExportacion;
            var TipoDocumentoCliente = registroVenta.TipoDocumento;
            var NumeroDocumentoCliente = registroVenta.NumeroDocumento;
            var NombreyApellido = registroVenta.NombreRazonSocial;
            var IVAP = registroVenta.IVAP;
            var ImpuestoIVAP = registroVenta.ImpuestoIVAP;
            var FechaEmisionModificada = Formato.ObtieneFecha(registroVenta.FechaEmisionModificada, "DD/MM/AAAA");
            var FechaPeriodo = registroVenta.FechaEmisionComprobante;
            var TipoComprobanteModificado = registroVenta.TipoComprobanteModificado;
            var ValorEmbarcadoExportacion = registroVenta.ValorEmbarcadoExportacion;
            var Estado = registroVenta.Estado;

            _idLibroLog = registroVenta.IdLibroLog;

            //1.Fecha de emision del comprobante de pago
            result = _iValidadorRegistroVenta.ValidaFechaEmisionComprobante(Estado,FechaComprobante, FechaPeriodo);

            RegistraError(errorDetalle, Ventas.FechaEmision, result, registroVenta.NumLinea);
            
            //2.Fecha de vencimiento de comprobante
            result = _iValidadorRegistroVenta.ValidaFechaVencimiento(TipoComprobante,Estado,FechaVencimiento,
                FechaPeriodo);

            RegistraError(errorDetalle,Ventas.FechaVencimiento, result, registroVenta.NumLinea);

            //3.Tipo de Comprobante de Pago o Documento
            result = _iValidadorRegistroVenta.ValidaTipoComprobante(TipoComprobante);

            RegistraError(errorDetalle,Ventas.TipoComprobante, result, NumeroLinea);

            //4.Numero de serie del comprobante
            result = _iValidadorRegistroVenta.ValidaNumeroSerieComprobante(
               TipoDocumentoModel, NumeroDocumento, NumeroSerieComprobante);

            RegistraError(errorDetalle,Ventas.NumeroSerie, result, registroVenta.NumLinea);

            //5.Numero del comprobante de pago o documento
            result = _iValidadorRegistroVenta.ValidaNumeroComprobante(
                TipoDocumentoModel, NumeroDocumento, NumeroComprobante);

            RegistraError(errorDetalle,Ventas.NumeroComprobante, result, NumeroLinea);

            //6.Tipo de documento del cliente
            result = _iValidadorRegistroVenta.ValidaTipoDocumentoCliente(
                TipoComprobante, OportunidadUnicaAnotacion,TipoDocumento,ValorFacturadoExportacion,
                ImporteTotalComprobante, TipoDocumentoCliente);

            RegistraError(errorDetalle,Ventas.TipoDocumento, result, NumeroLinea);

            //7.Numero de documento del cliente
            result = _iValidadorRegistroVenta.ValidaNumeroDocumentoCliente(
                TipoComprobante, OportunidadUnicaAnotacion, ValorFacturadoExportacion,
                ImporteTotalComprobante, NumeroDocumentoCliente, TipoDocumentoModel);

            RegistraError(errorDetalle,Ventas.NumeroDocumento, result, NumeroLinea);
            
            //8.Nombre del cliente
            result = _iValidadorRegistroVenta.ValidaNombreApellido(TipoComprobante, OportunidadUnicaAnotacion,
                ValorFacturadoExportacion, ImporteTotalComprobante, NombreyApellido);

            RegistraError(errorDetalle,Ventas.NombreCliente, result, NumeroLinea);
            
            //9.IVAP
            result = _iValidadorRegistroVenta.ValidaIVAP(TipoComprobante, OportunidadUnicaAnotacion,
                IVAP);

            RegistraError(errorDetalle,Ventas.IVAP, result, NumeroLinea);

            //10.Impuesto IVAP
            result = _iValidadorRegistroVenta.ValidaImpuestoIVAP(TipoComprobante, OportunidadUnicaAnotacion,
                ImpuestoIVAP);

            RegistraError(errorDetalle,Ventas.ImpuestoIVAP ,result, NumeroLinea);

            //11.Fecha Emision Comprobante Modificado
            result = _iValidadorRegistroVenta.ValidaFechaEmisionComprobanteModificado(TipoComprobante,
                FechaEmisionModificada, OportunidadUnicaAnotacion, FechaPeriodo);

            RegistraError(errorDetalle,Ventas.FechaEmisionMod ,result, NumeroLinea);

            //12.Tipo Comprobante Modificado
            result = _iValidadorRegistroVenta.ValidaTipoComprobanteModificado(TipoComprobante,
                OportunidadUnicaAnotacion);

            RegistraError(errorDetalle,Ventas.TipoComprobanteMod, result, NumeroLinea);

            //13.Numero de Serie de Comprobante Modificado
            result = _iValidadorRegistroVenta.ValidaNumeroSerieComprobanteModificado(TipoComprobante,
                TipoComprobanteModificado, NumeroSerieComprobante);

            RegistraError(errorDetalle,Ventas.NumeroSerieMod,result,NumeroLinea);

            //14.Numero de Comprobante Modificado
            result = _iValidadorRegistroVenta.ValidarNumeroComprobanteModificado(TipoComprobante,
                OportunidadUnicaAnotacion,NumeroSerieComprobante);

            RegistraError(errorDetalle,Ventas.NumeroComprobanteMod,result,NumeroLinea);

            //15.Valor Embarcado Exportacion
            result = _iValidadorRegistroVenta.ValidaValorEmbarcadoExportacion(TipoComprobanteModificado,
                ValorEmbarcadoExportacion);

            RegistraError(errorDetalle,Ventas.ValorEmbarcadoExp, result, NumeroLinea);

            error.Detalles = errorDetalle;

            return error;
        }

        private void RegistraError(ICollection<ErrorDetalle> lstErrorDetalle,string campo, Tuple<bool, string> result,
            int linea)
        {
            if (!result.Item1)
            {
                var error = new ErrorDetalle
                {
                    Linea = linea,
                    Mensaje = result.Item2,
                    Campo = campo,
                    IdLibroLog = _idLibroLog
                };

                lstErrorDetalle.Add(error);
            }
        }
    }
}
