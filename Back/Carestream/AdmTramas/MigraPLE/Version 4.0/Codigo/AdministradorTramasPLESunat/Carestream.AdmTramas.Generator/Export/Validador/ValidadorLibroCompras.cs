using System;
using System.Collections.Generic;
using Carestream.AdmTramas.Converter;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Campos;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Generator.Export.Validador
{
    public class ValidadorLibroCompras
    {
        private readonly IRegistroCompra _registroCompra;
        private long _idLibroLog;

        public ValidadorLibroCompras(IRegistroCompra registroCompra)
        {
            _registroCompra = registroCompra;
        }

        public List<Error> ValidaRegistros(List<RegistroCompra> libroDiario)
        {
            var errores = new List<Error>();

            Error error = null;

            foreach (var libro in libroDiario)
            {
                error = Validar(libro);
                if (error.Detalles.Count > 0)
                    errores.Add(error);
            }

            return errores;
        }

        public Error Validar(RegistroCompra registroCompra)
        {
            var error = new Error();

            var errorDetalle = new List<ErrorDetalle>();
            var result = new Tuple<bool, string>(false, "");

            var fechaPeriodo = registroCompra.FechaPeriodo;
            var fechaEmision = registroCompra.FechaEmision;
            var fechaVencimiento = registroCompra.FechaVencimiento;
            var tipoComprobante = registroCompra.TipoComprobante;
            var tipoDocumento = registroCompra.TipoDocumento;
            var numeroDocumento = registroCompra.NumeroDocumento;
            var numeroSerie = registroCompra.NumeroSerieComprobante;
            var tipoDocumentoModel = TipoDocumentoConverter.Convert(tipoDocumento);
            var tipoComprobanteMod = registroCompra.TipoComprobanteModificado;
            var codigoDUA = registroCompra.CodigoDUA;
            var numeroComprobante = registroCompra.NumeroComprobante;
            var numeroComprobanteNoDomiciliado = registroCompra.NumeroComprobanteNoDomiciliado;
            var fechaEmisionConstancia = registroCompra.FechaEmisionConstancia;

            _idLibroLog = registroCompra.IdLibroLog;

            //1. Valida Fecha Periodo
            result = _registroCompra.ValidaFechaPeriodo(fechaPeriodo);

            RegistraError(errorDetalle, Compras.FechaPeriodo, result, registroCompra.NumLinea);

            //2. Valida Fecha Emision
            result = _registroCompra.ValidaFechaEmision(fechaEmision);

            RegistraError(errorDetalle, Compras.FechaEmision, result, registroCompra.NumLinea);

            //3. Fecha de Vencimiento
            result = _registroCompra.ValidaFechaVencimiento(fechaVencimiento,tipoComprobante,fechaPeriodo);

            RegistraError(errorDetalle, Compras.FechaVencimiento, result, registroCompra.NumLinea);

            //4. Tipo Comprobante
            result = _registroCompra.ValidaTipoComprobante(tipoComprobante);

            RegistraError(errorDetalle, Compras.TipoComprobante, result, registroCompra.NumLinea);

            //5. Serie del Comprobante
            result = _registroCompra.ValidaNumeroSerieComprobante(tipoDocumentoModel, numeroDocumento, numeroSerie);

            RegistraError(errorDetalle, Compras.SerieComprobante, result, registroCompra.NumLinea);

            //6. Año de Emision DUA
            result = _registroCompra.ValidaCodigoDUA(tipoComprobanteMod, codigoDUA);

            RegistraError(errorDetalle, Compras.CodigoDUA, result, registroCompra.NumLinea);

            //7. Numero de Comprobante Mod
            result = _registroCompra.ValidaNumeroComprobante(tipoDocumentoModel, numeroDocumento, numeroComprobante);

            RegistraError(errorDetalle, Compras.NumeroComprobanteMod, result, registroCompra.NumLinea);

            //8. Numero Comprobante No Domiciliado
            result = _registroCompra.ValidaNumeroComprobanteNoDomiciliado(tipoComprobante,
                numeroComprobanteNoDomiciliado);

            RegistraError(errorDetalle, Compras.ComprobanteNoDomiciliado, result, registroCompra.NumLinea);

            //9. ValidaFechaEmisionConstancia
            result = _registroCompra.ValidaFechaEmisionConstancia(fechaPeriodo, fechaEmisionConstancia);

            RegistraError(errorDetalle, Compras.FechaEmision, result, registroCompra.NumLinea);

            error.Detalles = errorDetalle;

            return error;
        }

        private void RegistraError(ICollection<ErrorDetalle> lstErrorDetalle, string campo, Tuple<bool, string> result,
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
