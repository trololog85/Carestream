using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Converter.Compras
{
    public class RegistroComprasConverter
    {
        private static readonly string defaultString = ConfigurationManager.AppSettings["DefaultString"];
        private static readonly string tipoCompDefault = ConfigurationManager.AppSettings["tipoCompDefault"];
        private static readonly string anioDefault = ConfigurationManager.AppSettings["anioDefault"];
        private static readonly string monedaPEN = ConfigurationManager.AppSettings["monedaPEN"];
        private static readonly string monedaUSD = ConfigurationManager.AppSettings["monedaUSD"];

        public static List<RegistroCompra> ConvertList(
            IEnumerable<DataAccess.Model.RegistroCompra> registroCompra)
        {
            var converLst = registroCompra.Select(ConvertOut).ToList();

            return converLst;
        }

        private static RegistroCompra ConvertOut(DataAccess.Model.RegistroCompra registroCompra)
        {
            return new RegistroCompra
                   {
                       FechaPeriodo = ObtieneFechaPeriodo(registroCompra.Estado, registroCompra.FechaEmision),
                       CodigoUnicoOperacion = registroCompra.codigounicooperacion,
                       NumeroCorrelativo = registroCompra.numerocorrelativo,
                       FechaEmision = registroCompra.FechaEmision,
                       FechaVencimiento = registroCompra.FechaVencimiento==DateTime.Parse("1900-01-01")?DateTime.Parse("01-01-0001"):
                                            registroCompra.FechaVencimiento,
                       TipoComprobante = registroCompra.TipoComprobante,
                       NumeroSerieComprobante = NumeroSerieConverter(registroCompra.NumeroSerieComprobante, registroCompra.TipoComprobante),
                       AnioEmisionComprobante = AnioEmisionConverter(registroCompra.AnioEmisionComprobante),
                       NumeroComprobante = registroCompra.NumeroComprobante,
                       ImporteTotal = Convert.ToDecimal(registroCompra.Total),
                       TipoDocumento = TipoDocumentoConvert(registroCompra.TipoDocumento),
                       NumeroDocumento = registroCompra.NumeroDocumento,
                       ApellidoNombreRazonSocial = registroCompra.NombreRazonSocial,
                       BaseImponible1 = Convert.ToDecimal(registroCompra.BaseImponibleGravada),
                       IGV1 = Convert.ToDecimal(registroCompra.IGVGravado),
                       BaseImponible2 = 0,
                       IGV2 = 0,
                       BaseImponible3 = 0,
                       IGV3 = 0,
                       AdquisicionNoGravada = Convert.ToDecimal(registroCompra.AdquisicionNoGravada),
                       ISC = Convert.ToDecimal(registroCompra.ISC),
                       OtrosTributos = Convert.ToDecimal(registroCompra.OtrosTributos),
                       Total = Convert.ToDecimal(registroCompra.Total),
                       TipoDeCambio = Convert.ToDecimal(registroCompra.TipoCambio),
                       FechaEmisionComprobante = FechaModConverter(registroCompra.FechaOriginal),
                       TipoComprobanteModificado = TipoComprobanteModConverter(registroCompra.TipoDocumentoOriginal),
                       NumeroSerieModificado = NumeroSerieModConverter(registroCompra.NumeroSerieOriginal),
                       CodigoDUA = CodigoDUAConverter(registroCompra.NumeroSerieComprobante,registroCompra.TipoComprobante),
                       NumeroComprobanteModificado = NumeroCompModConverter(registroCompra.NumeroDocumentoOriginal),
                       NumeroComprobanteNoDomiciliado = ComprobanteNoDomicConverter(registroCompra.ComprobanteNoDomiciliado),
                       FechaEmisionConstancia = registroCompra.FechaEmisionConstancia,
                       NumeroConstancia = NumeroConstanciaConverter(registroCompra.NumeroConstancia),
                       MarcaComprobante = "0",
                       EstadoAnotacion = EstadoConverter(registroCompra.Estado, registroCompra.FechaEmision),                       
                       NumLinea = registroCompra.Linea,
                       IdLibroLog = registroCompra.IdLibroLog,
                       FlagOperacionesDiarias = "0",
                       Moneda = MonedaConverter(registroCompra.TipoCambio),
                       ClasificacionBien = registroCompra.ClasificacionBien,

                   };
        }

        private static string MonedaConverter(decimal tipoCambio)
        {
            if (tipoCambio == 0)
                return monedaPEN;

            return monedaUSD;
        }

        private static string AnioEmisionConverter(string anioEmisionComprobante)
        {
            return anioEmisionComprobante.Equals(string.Empty)
                ? anioDefault
                : anioEmisionComprobante;
        }

        private static string CodigoDUAConverter(string dua, string tipoComprobante)
        {
            if (tipoComprobante == "50" || tipoComprobante == "52")
                return dua;

            return string.Empty;
        }

        private static string NumeroConstanciaConverter(string numeroConstancia)
        {
            return numeroConstancia.Equals(string.Empty)
                ? defaultString
                : numeroConstancia;
        }

        private static string ComprobanteNoDomicConverter(string comprobanteNoDomiciliado)
        {
            return comprobanteNoDomiciliado.Equals(string.Empty)
                ? defaultString
                : comprobanteNoDomiciliado;
        }

        private static string NumeroSerieModConverter(string numeroSerieOriginal)
        {
            return numeroSerieOriginal.Equals(string.Empty)
                ? defaultString
                : numeroSerieOriginal;
        }

        private static string TipoComprobanteModConverter(string tipoDocumentoOriginal)
        {
            return tipoDocumentoOriginal.Equals(string.Empty)
                ? tipoCompDefault
                : tipoDocumentoOriginal;
        }

        private static DateTime ObtieneFechaPeriodo(string Estado, DateTime FechaEmision)
        {
            if (Estado == "0" || Estado == "7")
            {
                return FechaEmision;
            }
            else
            {
                return Globals.PeriodoInformado;
            }
        }

        private static string TipoDocumentoConvert(string tipoDocumento)
        {
            var len = tipoDocumento.Length;

            return len > 1 ? tipoDocumento.Substring(1, 1) : tipoDocumento;
        }

        private static string NumeroCompModConverter(string numeroComprobanteModificado)
        {
            return numeroComprobanteModificado.Equals(string.Empty)
                ? defaultString
                : numeroComprobanteModificado;
        }

        private static DateTime FechaModConverter(DateTime fechaMod)
        {
            return fechaMod.Equals(DateTime.Parse("1900-01-01"))
                ? DateTime.Parse("0001-01-01")
                : fechaMod;

        }

        private static string EstadoConverter(string estado,DateTime fechaEmision)
        {
            var fechaPeriodo = Globals.PeriodoInformado;

            var dt1 = new DateTime(fechaPeriodo.Year, fechaPeriodo.Month, 1);
            var dt2 = new DateTime(fechaEmision.Year, fechaEmision.Month, 1);

            if (dt1.CompareTo(dt2) > 0)
            {
                return "6";
            }
            else
            {
                return estado;
            }
        }

        private static string NumeroSerieConverter(string numeroSerie,string tipoComprobante)
        {
            if (tipoComprobante == "50" || tipoComprobante == "52")
                return numeroSerie;

            var len = numeroSerie.Length;

            if (len > 3)
                return numeroSerie;

            var result = 0;

            return int.TryParse(numeroSerie, out result) ? Formato.RellenaNumero(result, 4, "0") : numeroSerie;
        }
    }
}
