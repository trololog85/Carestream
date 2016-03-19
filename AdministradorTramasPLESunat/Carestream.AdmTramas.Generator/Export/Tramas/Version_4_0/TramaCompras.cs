using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Carestream.AdmTramas.Generator.Export.Tramas.Interface;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Version_4_0
{
    public class TramaCompras : ITramaCompras
    {
        private static readonly string separador = ConfigurationManager.AppSettings["separador"];

        public void GeneraTrama(List<RegistroCompra> registros, RutaArchivo ruta)
        {
            var trama = new List<string>();
            string linea = null;

            foreach (var registro in registros)
            {
                linea = ArmaEstructura(registro);
                trama.Add(linea);
            }

            Archivo.GuardarTrama(trama, ruta);
        }

        private static string ArmaEstructura(RegistroCompra registoCompra)
        {
            var trama = new StringBuilder();

            var fechaPeriodo = Formato.FormateaFecha("AAAAMM00", registoCompra.FechaPeriodo);
            var codigoUnicoOperacion = registoCompra.CodigoUnicoOperacion;
            var numeroCorrelativo = registoCompra.NumeroCorrelativo;
            var fechaEmisionComprobante = Formato.FormateaFecha("DD/MM/AAAA", registoCompra.FechaEmision);
            var fechaVencimiento = Formato.FormateaFecha("DD/MM/AAAA", registoCompra.FechaVencimiento);
            var tipoComprobante = registoCompra.TipoComprobante;
            var numeroSerieComprobante = registoCompra.NumeroSerieComprobante;
            var añoEmisionDUA = registoCompra.AnioEmisionComprobante;
            var numeroComprobante = registoCompra.NumeroComprobante;
            var flagOperacionDiaria = string.Empty;//registoCompra.FlagOperacionesDiarias;
            var tipoDocumento = registoCompra.TipoDocumento;
            var numeroDocumento = registoCompra.NumeroDocumento;
            var nombreCliente = registoCompra.ApellidoNombreRazonSocial;
            var baseImponibleGravada = registoCompra.BaseImponible1;
            var igvGravado = registoCompra.IGV1;
            var baseImponibleNoGravada = registoCompra.BaseImponible2;
            var igvNoGravado = registoCompra.IGV2;
            var baseImponibleGravadaCredito = registoCompra.BaseImponible3;
            var igvGravadoCredito = registoCompra.IGV3;
            var adquisicionNoGravada = registoCompra.AdquisicionNoGravada;
            var isc = registoCompra.ISC;
            var otrosTributos = registoCompra.OtrosTributos;
            var importeTotal = registoCompra.ImporteTotal;
            var tipoCambio = registoCompra.TipoDeCambio;
            var fechaEmisionConstancia = Formato.FormateaFecha("DD/MM/AAAA", registoCompra.FechaEmisionComprobante);
            var numeroDeConstancia = registoCompra.NumeroConstancia;
            var marcaComprobante = string.Empty;//registoCompra.MarcaComprobante;
            var estadoAnotacion = registoCompra.EstadoAnotacion;
            var tipoComprobanteMod = registoCompra.TipoComprobanteModificado;
            var numeroSerieMod = registoCompra.NumeroSerieModificado;
            var codigoDUA = registoCompra.CodigoDUA;
            var comprobanteMod = registoCompra.NumeroComprobanteModificado;
            var comprobanteNoDomicialido = registoCompra.NumeroComprobanteNoDomiciliado;
            var moneda = registoCompra.Moneda;
            var clasificacionBienes = registoCompra.ClasificacionBien;
            var identificacionContrato = String.Empty;
            var tipoCambioFechaEmision = String.Empty;
            var campo37 = String.Empty;
            var campo38 = String.Empty;
            var campo39 = String.Empty;
            var indicadorComprobante = "1";

            trama.Append(fechaPeriodo);
            trama.Append(separador);
            trama.Append(codigoUnicoOperacion);
            trama.Append(separador);
            trama.Append(numeroCorrelativo);
            trama.Append(separador);
            trama.Append(fechaEmisionComprobante);
            trama.Append(separador);
            trama.Append(fechaVencimiento);
            trama.Append(separador);
            trama.Append(tipoComprobante);
            trama.Append(separador);
            trama.Append(numeroSerieComprobante);
            trama.Append(separador);
            trama.Append(añoEmisionDUA);
            trama.Append(separador);
            trama.Append(numeroComprobante);
            trama.Append(separador);
            trama.Append(flagOperacionDiaria);
            trama.Append(separador);
            trama.Append(tipoDocumento);
            trama.Append(separador);
            trama.Append(numeroDocumento);
            trama.Append(separador);
            trama.Append(nombreCliente);
            trama.Append(separador);
            trama.Append(baseImponibleGravada);
            trama.Append(separador);
            trama.Append(igvGravado);
            trama.Append(separador);
            trama.Append(baseImponibleNoGravada);
            trama.Append(separador);
            trama.Append(igvNoGravado);
            trama.Append(separador);
            trama.Append(baseImponibleGravadaCredito);
            trama.Append(separador);
            trama.Append(igvGravadoCredito);
            trama.Append(separador);
            trama.Append(adquisicionNoGravada);
            trama.Append(separador);
            trama.Append(isc);
            trama.Append(separador);
            trama.Append(otrosTributos);
            trama.Append(separador);
            trama.Append(importeTotal);
            trama.Append(separador);
            trama.Append(moneda);
            trama.Append(separador);
            trama.Append(tipoCambio);
            trama.Append(separador);
            trama.Append(fechaEmisionComprobante);
            trama.Append(separador);
            trama.Append(tipoComprobanteMod);
            trama.Append(separador);
            trama.Append(numeroSerieMod);
            trama.Append(separador);
            trama.Append(codigoDUA);
            trama.Append(separador);
            trama.Append(comprobanteMod);
            trama.Append(separador);
            trama.Append(fechaEmisionConstancia);
            trama.Append(separador);
            trama.Append(numeroDeConstancia);
            trama.Append(separador);
            trama.Append(marcaComprobante);
            trama.Append(separador);
            trama.Append(clasificacionBienes);
            trama.Append(separador);
            trama.Append(identificacionContrato);
            trama.Append(separador);
            trama.Append(tipoCambioFechaEmision);
            trama.Append(separador);
            trama.Append(campo37);
            trama.Append(separador);
            trama.Append(campo38);
            trama.Append(separador);
            trama.Append(campo39);
            trama.Append(separador);
            trama.Append(indicadorComprobante);
            trama.Append(separador);
            trama.Append(estadoAnotacion);
            trama.Append(separador);

            return trama.ToString();
        }
    }
}
