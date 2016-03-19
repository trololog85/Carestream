using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Converter.Ventas
{
    public class RegistroVentaConverter
    {
        private static readonly string constAnulado = ConfigurationManager.AppSettings["NombreAnulado"];
        private static readonly string tipoDocAnulado = ConfigurationManager.AppSettings["TipoDocAnulado"];
        private static readonly string numDocAnulado = ConfigurationManager.AppSettings["DefaultAnulado"];
        private static readonly string estadoAnulado = ConfigurationManager.AppSettings["EstadoAnulado"];
        private static readonly string cuoAnulado = ConfigurationManager.AppSettings["cuoAnulado"];

        public static List<RegistroVenta> ConvertList(
            IEnumerable<DataAccess.Model.RegistroVenta> registroVenta)
        {
            var converLst = registroVenta.Select(ConvertOut).ToList();

            return converLst;
        }


        private static RegistroVenta ConvertOut(DataAccess.Model.RegistroVenta registroVenta)
        {
            return new RegistroVenta
            {
                FechaPeriodo = Globals.PeriodoInformado,
                NumeroCorrelativo = registroVenta.NumeroCorrelativo,
                FechaEmisionComprobante = (DateTime)registroVenta.FechaComprobante,
                TipoComprobante = TipoComprobanteConverter(registroVenta.TipoComprobante),
                NumeroSerieComprobante = NumeroSerieConverter(registroVenta.SerieComprobante, registroVenta.TipoComprobante),
                NumeroComprobante = registroVenta.NumeroComprobante,
                TipoDocumentoModel = TipoDocumentoConverter.Convert(registroVenta.TipoDocumento),
                TipoDocumento = TipoDocumentoConvert(registroVenta.TipoDocumento,registroVenta.NombreRazonSocial),
                NumeroDocumento = NumeroDocumentoConverter(registroVenta.NumeroDocumento,registroVenta.NombreRazonSocial),
                NombreRazonSocial = registroVenta.NombreRazonSocial,
                ValorFacturadoExportacion = Convert.ToDecimal(registroVenta.OperacionNoGravada),
                BaseImponibleOperacionGravada = BaseImponibleConverter(registroVenta.TipoComprobante, registroVenta.VV),//registroVenta.VV,
                ImporteTotalOperacionExonerada = Decimal.Parse("0.00"),
                ImporteTotalOperacionInafecta = Decimal.Parse("0.00"),
                ImporteTotalComprobante = registroVenta.PV,
                ISC = Decimal.Parse("0.00"),
                IGV = IGVConverter(registroVenta.TipoComprobante, registroVenta.IGV),
                IVAP = Decimal.Parse("0.00"),
                TipodeCambio = TipoCambioConverter(registroVenta.TipoCambio, registroVenta.NombreRazonSocial),
                FechaEmisionModificada = FechaEmisionModificadaConverter(registroVenta.FechaModificada),
                TipoComprobanteModificado = TipoComprobanteModConverter(registroVenta.TipoComprobanteModificado),
                NumeroSerieModificado = NumeroSerieModificadoConverter(registroVenta.NumeroSerieModificado),
                NumeroComprobanteModificado = NumeroComprobanteModificadoConverter(registroVenta.NumeroComprobanteModificado),
                ValorEmbarcadoExportacion = Convert.ToDecimal(registroVenta.ValorEmbarcadoExportacion),
                OportunidadUnicaAnotacion = registroVenta.estado,
                Estado = EstadoConverter(registroVenta.NombreRazonSocial,registroVenta.estado),
                CodigoUnicoOperacion = CodigoUnicoConverter(registroVenta.NumeroUnicoOperacion,registroVenta.NombreRazonSocial),
                OtrosCargos = Decimal.Parse("0.00"),
                ImpuestoIVAP = Decimal.Parse("0.00"),
                IdLibroLog = registroVenta.IdLibroLog,
                NumLinea = registroVenta.Linea,
                Moneda = MonedaConverter(registroVenta.TipoCambio,registroVenta.NombreRazonSocial),
                Numero = registroVenta.Numero,
                DescuentoBaseImponible = DescuentoBaseImponibleConverter(registroVenta.TipoComprobante, registroVenta.VV),
                DescuentoIGV = DescuentoIgvConverter(registroVenta.TipoComprobante, registroVenta.IGV)
            };
        }

        private static decimal TipoCambioConverter(decimal tipoCambio, string nombreRazonSocial)
        {
            if (nombreRazonSocial == constAnulado)
                return Decimal.Parse("1.000");
            
            return tipoCambio;
        }

        private static decimal BaseImponibleConverter(string tipoDocumento, decimal registroVenta)
        {
            if (tipoDocumento == "7")
                return 0;

            return registroVenta;
        }

        public static decimal IGVConverter(string tipoDocumento, decimal igv)
        {
            if (tipoDocumento == "7")
                return 0;

            return igv;
        }

        private static decimal DescuentoBaseImponibleConverter(string tipoDocumento, decimal registroVenta)
        {
            if (tipoDocumento == "7")
                return registroVenta;

            return 0;
        }

        public static decimal DescuentoIgvConverter(string tipoDocumento, decimal igv)
        {
            if (tipoDocumento == "7")
                return igv;

            return 0;
        }

        private static string NumeroComprobanteModificadoConverter(string numeroCompMod)
        {
            if (numeroCompMod.Equals(string.Empty))
                return ConfigurationManager.AppSettings["NumeroSerieDefault"];

            return numeroCompMod;
        }

        private static string NumeroSerieModificadoConverter(string numeroSerieMod)
        {
            if (numeroSerieMod == string.Empty)
                return ConfigurationManager.AppSettings["NumeroSerieDefault"];

            if (numeroSerieMod == "004")
                return "0004";

            return numeroSerieMod;
        }

        private static string TipoComprobanteModConverter(string tipoComprobanteMod)
        {
            if (tipoComprobanteMod == string.Empty)
                return ConfigurationManager.AppSettings["TipoComprobanteDefault"];

            return tipoComprobanteMod;
        }

        private static string FechaEmisionModificadaConverter(DateTime? FechaModificada)
        {
            if (FechaModificada.Equals(DateTime.Parse("1900-01-01")))
                return ConfigurationManager.AppSettings["fechaDefault"];

            return Formato.FormateaFecha("DD/MM/AAAA", Convert.ToDateTime(FechaModificada));                                   
        }

        private static string TipoComprobanteConverter(string tipoComprobante)
        {
            return Formato.RellenaCodigo(tipoComprobante);
        }

        private static string NumeroSerieConverter(string numeroSerie,string tipoComprobante)
        {
            var regla = ConfigurationManager.AppSettings["numeroSerie"];

            var permitidos = regla.Split(',');

            if (permitidos.Any(x => x == Formato.RellenaCodigo(tipoComprobante)))
                return Formato.FormateaCadena(numeroSerie, '0', 4);

            return Formato.FormateaCadena(numeroSerie, '0', 20);
        }

        private static string TipoDocumentoConvert(string tipoDocumento, string nombreRazonSocial)
        {
            return nombreRazonSocial == constAnulado
                ? tipoDocAnulado
                : tipoDocumento;
        }

        private static string NumeroDocumentoConverter(string numeroDocumento, string nombreRazonSocial)
        {
            return nombreRazonSocial == constAnulado
                ? "0"
                : numeroDocumento;
        }

        private static string EstadoConverter(string nombreRazonSocial, string estado)
        {
            return nombreRazonSocial == constAnulado
                ? estadoAnulado
                : estado;
        }

        private static string CodigoUnicoConverter(string codigoUnico, string nombreRazonSocial)
        {
            return nombreRazonSocial == constAnulado
                ? cuoAnulado
                : codigoUnico;
        }

        private static string MonedaConverter(decimal tipoCambio, string nombreRazonSocial)
        {
            if (tipoCambio > 0)
                return ConfigurationManager.AppSettings["monedaUSD"];

            return ConfigurationManager.AppSettings["monedaPEN"];
        }
    }
}
