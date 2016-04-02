using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Carestream.AdmTramas.DataAccess.Model;
using RegistroCompra = Carestream.AdmTramas.Model.Entities.RegistroCompra;
using RegistroVenta = Carestream.AdmTramas.Model.Entities.RegistroVenta;

namespace Carestream.AdmTramas.Converter.LibroMayor
{
    public class LibroMayorConverter
    {
        private static string cuentasUSD = ConfigurationManager.AppSettings["CuentasUSD"];
        private static string[] ArrCuentasUSD = cuentasUSD.Split(',');

        public static List<Model.Entities.LibroMayor> ConvertList(IEnumerable<DataAccess.Model.LibroMayor> libroMayor, 
            IEnumerable<RegistroVenta> ventas, IEnumerable<RegistroCompra> compras)
        {
            var mayor = libroMayor.Select(ConvertOut).ToList();
            var mayorExcluyente = mayor.Where(d => (!ExisteVenta(d, ventas) && !ExisteCompra(d, compras)));

            var diarioyVentas = mayor.Where(d => ExisteVenta(d, ventas)).Select(d => ConvertFromVentas(d, ventas));
            var diarioyCompras = mayor.Where(d => ExisteCompra(d, compras)).Select(d => ConvertFromCompras(d, compras));

            var mayorConvert = new List<Model.Entities.LibroMayor>();

            mayorConvert.AddRange(mayorExcluyente);
            mayorConvert.AddRange(diarioyVentas);
            mayorConvert.AddRange(diarioyCompras);

            return mayorConvert;
        }

        private static Model.Entities.LibroMayor ConvertOut(DataAccess.Model.LibroMayor libroMayor)
        {
            return new Model.Entities.LibroMayor
            {
                CodigoCuentaContable = libroMayor.CodigoCuentaContable,
                CodigoUnicoOperacion = libroMayor.codunicooperacion,
                CorrelativoCompras = string.Empty,
                CorrelativoConsignaciones = string.Empty,
                CorrelativoVentas = string.Empty,
                Debe = libroMayor.Debe,
                Estado = libroMayor.Estado,
                FechaOperacion = libroMayor.FechaOperacion,
                FechaPeriodo = libroMayor.Periodo,
                Glosa = libroMayor.Glosa,
                Haber = libroMayor.Haber,
                NumLinea = libroMayor.Linea,
                NumeroCorrelativo = libroMayor.NumeroCorrelativo,
                CodigoPlanCuenta = libroMayor.CodigoPlanCuenta,
                Moneda = ConvertMoneda(libroMayor.CodigoCuentaContable, 0),
                TipoDocumentoEmisor = "0",
                NumeroDocumentoEmisor = "0",
                TipoComprobante = "00",
                NumeroSerieComprobante = "-",
                NumeroComprobante = "-"
            };
        }

        private static Model.Entities.LibroMayor ConvertFromVentas(Model.Entities.LibroMayor libroMayor, IEnumerable<RegistroVenta> ventas)
        {
            var regVenta = ventas.FirstOrDefault(v => v.CodigoUnicoOperacion == libroMayor.CodigoUnicoOperacion);

            libroMayor.Moneda = ConvertMoneda(libroMayor.CodigoCuentaContable, regVenta.TipodeCambio);
            libroMayor.TipoDocumentoEmisor = regVenta.TipoDocumento;
            libroMayor.NumeroDocumentoEmisor = regVenta.NumeroDocumento;
            libroMayor.TipoComprobante = regVenta.TipoComprobante;
            libroMayor.NumeroSerieComprobante = regVenta.NumeroSerieComprobante;
            libroMayor.NumeroComprobante = regVenta.NumeroComprobante;
            libroMayor.FechaContable = regVenta.FechaEmisionComprobante;
            libroMayor.FechaVencimiento = regVenta.FechaVencimiento;
            libroMayor.CodigoLibro = ConvertCodigoLibro(regVenta.FechaPeriodo, regVenta.CodigoUnicoOperacion,
                regVenta.NumeroCorrelativo);

            return libroMayor;
        }

        private static Model.Entities.LibroMayor ConvertFromCompras(Model.Entities.LibroMayor libroMayor,
            IEnumerable<RegistroCompra> compras)
        {
            var regCompra = compras.FirstOrDefault(v => v.CodigoUnicoOperacion == libroMayor.CodigoUnicoOperacion);

            libroMayor.Moneda = ConvertMoneda(libroMayor.CodigoCuentaContable, regCompra.TipoDeCambio);
            libroMayor.TipoDocumentoEmisor = regCompra.TipoDocumento;
            libroMayor.NumeroDocumentoEmisor = regCompra.NumeroDocumento;
            libroMayor.TipoComprobante = regCompra.TipoComprobante;
            libroMayor.NumeroSerieComprobante = regCompra.NumeroSerieComprobante;
            libroMayor.NumeroComprobante = regCompra.NumeroComprobante;
            libroMayor.FechaContable = regCompra.FechaEmisionComprobante;
            libroMayor.FechaVencimiento = regCompra.FechaVencimiento;
            libroMayor.CodigoLibro = ConvertCodigoLibro(regCompra.FechaPeriodo, regCompra.CodigoUnicoOperacion,
                regCompra.NumeroCorrelativo);

            return libroMayor;
        }


        private static bool ExisteVenta(Model.Entities.LibroMayor regDiario,
            IEnumerable<RegistroVenta> ventas)
        {
            var cuo = regDiario.CodigoUnicoOperacion;

            var reg = ventas.FirstOrDefault(v => v.CodigoUnicoOperacion == cuo);

            return reg != null;
        }

        private static bool ExisteCompra(Model.Entities.LibroMayor regDiario,
            IEnumerable<RegistroCompra> compras)
        {
            var cuo = regDiario.CodigoUnicoOperacion;

            var reg = compras.FirstOrDefault(v => v.CodigoUnicoOperacion == cuo);

            return reg != null;
        }

        private static string ConvertMoneda(string cuenta, decimal tipoCambio)
        {
            if (ArrCuentasUSD.Any(x => x == cuenta))
                return ConfigurationManager.AppSettings["monedaUSD"];

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
