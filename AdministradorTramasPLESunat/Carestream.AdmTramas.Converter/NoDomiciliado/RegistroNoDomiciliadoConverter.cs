using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Converter.NoDomiciliado
{
    public class RegistroNoDomiciliadoConverter
    {
        private static readonly string usd = ConfigurationManager.AppSettings["monedaUSD"];
        private static readonly string pen = ConfigurationManager.AppSettings["monedaPEN"];

        public static List<Model.Entities.RegistroNoDomiciliado> ConvertList(
            IEnumerable<DataAccess.Model.RegistroNoDomiciliado> registroCompra)
        {
            var converLst = registroCompra.Select(ConvertOut).ToList();

            return converLst;
        }

        private static Model.Entities.RegistroNoDomiciliado ConvertOut(DataAccess.Model.RegistroNoDomiciliado registro)
        {
            return new Model.Entities.RegistroNoDomiciliado
            {
                IdLibroLog = registro.IdLibroLog,
                Periodo = registro.Periodo,
                Linea = registro.Linea,
                IdLibro = registro.IdLibro,
                TipoComprobante = registro.TipoComprobante,
                FechaEmision = registro.FechaEmision,
                NumeroCorrelativo = registro.NumeroCorrelativo,
                ImpuestoRetenido = registro.ImpuestoRetenido,
                ServicioPrestado = registro.ServicioPrestado,
                RentaBruta = registro.RentaBruta,
                PaisBeneficiario = registro.PaisBeneficiario,
                ImporteTotalAdquisicion = registro.ImporteTotalAdquisicion,
                Deduccion = registro.Deduccion,
                NumeroSerieComprobante = registro.NumeroSerieComprobante,
                Moneda = registro.Moneda,
                TipoComprobanteFiscal = registro.TipoComprobanteFiscal,
                Pais = registro.Pais,
                Domicilio = registro.Domicilio,
                Vinculo = registro.Vinculo,
                Campo35 = registro.Campo35,
                RentaNeta = registro.RentaNeta,
                IGV = registro.IGV,
                Estado = registro.Estado,
                NumeroIdentificacionFiscal = registro.NumeroIdentificacionFiscal,
                NumeroComprobanteDUA = registro.NumeroComprobanteDUA,
                AnioEmisionDUA = registro.AnioEmisionDUA,
                RazonSocialBeneficiario = registro.RazonSocialBeneficiario,
                NumeroIdentificacionSujeto = registro.NumeroIdentificacionSujeto,
                TasaRetencion = registro.TasaRetencion,
                OtrosConceptos = registro.OtrosConceptos,
                NumeroSerieComprobanteFiscal = registro.NumeroSerieComprobanteFiscal,
                Convenio = registro.Convenio,
                ValorAdquisicion = registro.ValorAdquisicion,
                TipoRenta = registro.TipoRenta,
                ExoneracionAplicada = registro.ExoneracionAplicada,
                NumeroComprobante = registro.NumeroComprobante,
                CUO = registro.CUO,
                TipoCambio = TipoCambioConverter(registro.TipoCambio,registro.Moneda),
                RazonSocial = registro.RazonSocial
            };
        }

        private static decimal? TipoCambioConverter(decimal? tipoCambio, string moneda)
        {
            if (moneda == pen)
                return Decimal.Parse("0.000");

            return tipoCambio;
        }
    }
}
