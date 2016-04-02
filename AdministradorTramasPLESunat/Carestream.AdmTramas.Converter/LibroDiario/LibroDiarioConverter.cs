using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Converter.LibroDiario
{
    public class LibroDiarioConverter
    {
        private static string cuentasUSD = ConfigurationManager.AppSettings["CuentasUSD"];
        private static string[] ArrCuentasUSD = cuentasUSD.Split(',');
        private static List<string> CuosUSD = new List<string>();

        public static List<Model.Entities.LibroDiario> ConvertList(IEnumerable<DataAccess.Model.LibroDiario> libroDiario,
            IEnumerable<RegistroVenta> ventas, IEnumerable<RegistroCompra> compras)
        {
            var diario = libroDiario.Select(ConvertOut).ToList();
            var diarioExcluyente = diario.Where(d => (!ExisteVenta(d, ventas) && !ExisteCompra(d, compras)));

            //var diarioyVentas = diario.Where(d => ExisteVenta(d,ventas));
            //var diarioyCompras = diario.Where(d => ExisteCompra(d, compras));

            var diarioyVentas = diario.Where(d=> ExisteVenta(d, ventas)).Select(d => ConvertFromVentas(d, ventas));
            var diarioyCompras = diario.Where(d => ExisteCompra(d, compras)).Select(d => ConvertFromCompras(d, compras));

            var diarioConvert = new List<Model.Entities.LibroDiario>();

            diarioConvert.AddRange(diarioExcluyente);
            diarioConvert.AddRange(diarioyVentas);
            diarioConvert.AddRange(diarioyCompras);

            foreach (var cuo in CuosUSD)
            {
                foreach (var reg in diarioConvert)
                {
                    if(reg.CodigoUnicoOperacion==cuo)
                        reg.Moneda = ConfigurationManager.AppSettings["monedaUSD"];
                }
            }

            return diarioConvert;
        }

        private static Model.Entities.LibroDiario ConvertOut(DataAccess.Model.LibroDiario libroDiario)
        {
            return new Model.Entities.LibroDiario
            {
                FechaPeriodo = Globals.PeriodoInformado,
                CodigoUnicoOperacion = libroDiario.CodigoUnico,
                NumeroCorrelativoContable = libroDiario.Correlativo,
                CodigoPlanCuentas = ConfigurationManager.AppSettings["PlanContable"],
                CodigoCuentaContable = libroDiario.Cuenta,
                FechaOperacion = libroDiario.Fecha,
                Glosa = libroDiario.DescripcionAsiento,
                Debe = libroDiario.Debe,
                Haber = libroDiario.Haber,
                CorrelativoVentas = String.Empty,
                CorrelativoCompras = String.Empty,
                CorrelativoConsignaciones = String.Empty,
                EstadoOperacion = libroDiario.estado,
                IdLibroLog = libroDiario.IdLibroLog,
                NumeroLinea = libroDiario.Linea,
                Moneda = ConvertMoneda(libroDiario.Cuenta,0, libroDiario.CodigoUnico),
                TipoDocumentoEmisor = "0",
                NumeroDocumentoEmisor = "0",
                TipoComprobante = "00",
                NumeroSerieComprobante = "-",
                NumeroComprobante = "-"
        };
        }

        private static Model.Entities.LibroDiario ConvertFromVentas(Model.Entities.LibroDiario libroDiario,IEnumerable<RegistroVenta> ventas)
        {
            var regVenta = ventas.FirstOrDefault(v => v.CodigoUnicoOperacion == libroDiario.CodigoUnicoOperacion);

            libroDiario.Moneda = ConvertMoneda(libroDiario.CodigoCuentaContable, regVenta.TipodeCambio,libroDiario.CodigoUnicoOperacion);
            libroDiario.TipoDocumentoEmisor = regVenta.TipoDocumento;
            libroDiario.NumeroDocumentoEmisor = regVenta.NumeroDocumento;
            libroDiario.TipoComprobante = regVenta.TipoComprobante;
            libroDiario.NumeroSerieComprobante = regVenta.NumeroSerieComprobante;
            libroDiario.NumeroComprobante = regVenta.NumeroComprobante;
            libroDiario.FechaContable = regVenta.FechaEmisionComprobante;
            libroDiario.FechaVencimiento = regVenta.FechaVencimiento;
            libroDiario.CodigoLibro = ConvertCodigoLibro(regVenta.FechaPeriodo, regVenta.CodigoUnicoOperacion,
                regVenta.NumeroCorrelativo);

            return libroDiario;
        }

        private static Model.Entities.LibroDiario ConvertFromCompras(Model.Entities.LibroDiario libroDiario,
            IEnumerable<RegistroCompra> compras)
        {
            var regCompra = compras.FirstOrDefault(v => v.CodigoUnicoOperacion == libroDiario.CodigoUnicoOperacion);

            libroDiario.Moneda = ConvertMoneda(libroDiario.CodigoCuentaContable, regCompra.TipoDeCambio,libroDiario.CodigoUnicoOperacion);
            libroDiario.TipoDocumentoEmisor = regCompra.TipoDocumento;
            libroDiario.NumeroDocumentoEmisor = regCompra.NumeroDocumento;
            libroDiario.TipoComprobante = regCompra.TipoComprobante;
            libroDiario.NumeroSerieComprobante = regCompra.NumeroSerieComprobante;
            libroDiario.NumeroComprobante = regCompra.NumeroComprobante;
            libroDiario.FechaContable = regCompra.FechaEmisionComprobante;
            libroDiario.FechaVencimiento = regCompra.FechaVencimiento;
            libroDiario.CodigoLibro = ConvertCodigoLibro(regCompra.FechaPeriodo, regCompra.CodigoUnicoOperacion,
                regCompra.NumeroCorrelativo);

            return libroDiario;
        }

        private static bool ExisteVenta(Model.Entities.LibroDiario regDiario,
            IEnumerable<RegistroVenta> ventas)
        {
            var cuo = regDiario.CodigoUnicoOperacion;

            var reg = ventas.FirstOrDefault(v => v.CodigoUnicoOperacion == cuo);

            return reg != null;
        }

        private static bool ExisteCompra(Model.Entities.LibroDiario regDiario,
            IEnumerable<RegistroCompra> compras)
        {
            var cuo = regDiario.CodigoUnicoOperacion;

            var reg = compras.FirstOrDefault(v => v.CodigoUnicoOperacion == cuo);

            return reg != null;
        }

        private static string ConvertMoneda(string cuenta, decimal tipoCambio,string cuo)
        {
            if (ArrCuentasUSD.Any(x => x == cuenta))
            {
                CuosUSD.Add(cuo);
                return ConfigurationManager.AppSettings["monedaUSD"];
            }
                

            if (tipoCambio > 0)
                return ConfigurationManager.AppSettings["monedaUSD"];

            return ConfigurationManager.AppSettings["monedaPEN"];
        }

        private static string ConvertCodigoLibro(DateTime campo1, string campo2, string campo3)
        {
            /*var c1 = Formato.FormateaFecha("AAAAMM00", campo1);

            if(string.IsNullOrEmpty(campo3))
                return c1 + '&' + campo2;

            return c1 + '&' + campo2 + '&' + campo3;*/

            return string.Empty;
        }
    }
}
