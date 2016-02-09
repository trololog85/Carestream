using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Carestream.AdmTramas.Generator.Export.Tramas.Interface;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Version_4_0
{
    public class TramaVentas : ITramaVentas
    {
        private static readonly string separador = ConfigurationManager.AppSettings["separador"];

        public void GeneraTrama(List<RegistroVenta> registros, RutaArchivo ruta)
        {
            var constanteAnulado = ConfigurationManager.AppSettings["NombreAnulado"];

            var trama = new List<string>();
            string linea = null;

            foreach (var registro in registros)
            {
                linea = ArmaEstructura(registro);
                trama.Add(linea);
            }

            Archivo.GuardarTrama(trama, ruta);
        }

        private static string ArmaEstructura(RegistroVenta registroVenta)
        {
            var trama = new StringBuilder();

            var fechaPeriodo = Formato.FormateaFecha("AAAAMM00", registroVenta.FechaPeriodo);
            var codigoUnicoOperacion = registroVenta.CodigoUnicoOperacion;
            var fechaEmision = Formato.FormateaFecha("DD/MM/AAAA", registroVenta.FechaEmisionComprobante);
            var fechaVencimiento = Formato.FormateaFecha("DD/MM/AAAA", Convert.ToDateTime(registroVenta.FechaVencimiento));
            var tipoComprobante = registroVenta.TipoComprobante;
            var numeroSerie = registroVenta.NumeroSerieComprobante;
            var numeroComprobante = registroVenta.NumeroComprobante;
            var tipoDocumentoCliente = registroVenta.TipoDocumento;
            var numeroDocumentoCliente = registroVenta.NumeroDocumento;
            var razonSocial = registroVenta.NombreRazonSocial;
            var valorFacturado = registroVenta.ValorFacturadoExportacion;
            var baseImponible = registroVenta.BaseImponibleOperacionGravada;
            var importeTotalExonerado = registroVenta.ImporteTotalOperacionExonerada;
            var importeTotalInafecto = registroVenta.ImporteTotalOperacionInafecta;
            var isc = registroVenta.ISC;
            var igv = registroVenta.IGV;
            var ivap = registroVenta.IVAP;
            var impuestoIvap = registroVenta.ImpuestoIVAP;
            var otrosCargos = registroVenta.OtrosCargos;
            var importeTotal = registroVenta.ImporteTotalComprobante;
            var tipoCambio = registroVenta.TipodeCambio;
            var fechaEmisionMod = Formato.FormateaFecha("DD/MM/AAAA",
                Formato.ObtieneFecha(registroVenta.FechaEmisionModificada, "DD/MM/AAAA"));
            var numeroSerieMod = registroVenta.NumeroSerieModificado;
            var numeroComprobanteMod = registroVenta.NumeroComprobanteModificado;
            var valorEmbarcado = registroVenta.ValorEmbarcadoExportacion;
            var estado = registroVenta.Estado;
            var tipoComprobanteMod = registroVenta.TipoComprobanteModificado;
            var numeroCorrelativo = registroVenta.NumeroCorrelativo;
            var ticket = ConfigurationManager.AppSettings["numDefault"];
            var campo15 = ConfigurationManager.AppSettings["campoDefault"];
            var campo17 = ConfigurationManager.AppSettings["campoDefault"];
            var moneda = registroVenta.Moneda;
            var campo31 = ConfigurationManager.AppSettings["campoDefault"];
            var campo32 = ConfigurationManager.AppSettings["campo32"];
            var campo33 = ConfigurationManager.AppSettings["campo33"];


            trama.Append(fechaPeriodo);
            trama.Append(separador);
            trama.Append(codigoUnicoOperacion);
            trama.Append(separador);
            trama.Append(numeroCorrelativo);
            trama.Append(separador);
            trama.Append(fechaEmision);
            trama.Append(separador);
            trama.Append(fechaVencimiento);
            trama.Append(separador);
            trama.Append(tipoComprobante);
            trama.Append(separador);
            trama.Append(numeroSerie);
            trama.Append(separador);
            trama.Append(numeroComprobante);
            trama.Append(separador);
            trama.Append(ticket);
            trama.Append(separador);
            trama.Append(tipoDocumentoCliente);
            trama.Append(separador);
            trama.Append(numeroDocumentoCliente);
            trama.Append(separador);
            trama.Append(razonSocial);
            trama.Append(separador);
            trama.Append(valorFacturado);
            trama.Append(separador);
            trama.Append(baseImponible);
            trama.Append(separador);
            trama.Append(campo15);
            trama.Append(separador);
            trama.Append(igv);
            trama.Append(separador);
            trama.Append(campo17);
            trama.Append(separador);
            trama.Append(importeTotalExonerado);
            trama.Append(separador);
            trama.Append(importeTotalInafecto);
            trama.Append(separador);
            trama.Append(isc);
            trama.Append(separador);
            trama.Append(ivap);
            trama.Append(separador);
            trama.Append(impuestoIvap);
            trama.Append(separador);
            trama.Append(otrosCargos);
            trama.Append(separador);
            trama.Append(importeTotal);
            trama.Append(separador);
            trama.Append(moneda);
            trama.Append(separador);
            trama.Append(tipoCambio);
            trama.Append(separador);
            trama.Append(fechaEmisionMod);
            trama.Append(separador);
            trama.Append(tipoComprobanteMod);
            trama.Append(separador);
            trama.Append(numeroSerieMod);
            trama.Append(separador);
            trama.Append(numeroComprobanteMod);
            trama.Append(separador);
            trama.Append(campo31);
            trama.Append(separador);
            trama.Append(campo32);
            trama.Append(separador);
            trama.Append(campo33);
            trama.Append(separador);
            trama.Append(estado);
            trama.Append(separador);

            return trama.ToString();
        }
    }
}
