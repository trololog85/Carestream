using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Carestream.AdmTramas.Generator.Export.Tramas.Interface;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Version_4_0
{
    public class TramaLibroDiario: ITramaLibroDiario
    {
        private readonly string separador = ConfigurationManager.AppSettings["separador"];

        public void GeneraTrama(List<LibroDiario> registros,RutaArchivo ruta)
        {
            var trama = new List<string>();
            string linea = null;

            foreach (var registro in registros)
            {
                linea = ArmaEstructura(registro);
                trama.Add(linea);
            }

            Archivo.GuardarTrama(trama,ruta);
        }

        private string ArmaEstructura(LibroDiario libroDiario)
        {
            var trama = new StringBuilder();

            var fechaPeriodo = Formato.FormateaFecha("AAAAMM00", libroDiario.FechaPeriodo);
            var codigoUnicoOperacion = libroDiario.CodigoUnicoOperacion;
            var numeroCorrelativoAsiento = libroDiario.NumeroCorrelativoContable;
            var planCuenta = libroDiario.CodigoPlanCuentas;
            var codigoCuentaContable = libroDiario.CodigoCuentaContable;
            var fechaOperacion = Formato.FormateaFecha("DD/MM/AAAA", libroDiario.FechaOperacion);
            var glosa = libroDiario.Glosa;
            var debe = libroDiario.Debe;
            var haber = libroDiario.Haber;
            var numeroCorrelativoVentas = String.Empty;
            var numeroCorrelativoCompras = String.Empty;
            var numeroCorrelativoConsignacion = String.Empty;
            var estadoOperacion = libroDiario.EstadoOperacion;
            var codigoUnidadOperacion = string.Empty;
            var codigoCentrodeCosto = string.Empty;
            var moneda = libroDiario.Moneda;
            var tipoDocumentoEmisor = libroDiario.TipoDocumentoEmisor;
            var numeroDocumentoEmisor = libroDiario.NumeroDocumentoEmisor;
            var tipoComprobante = libroDiario.TipoComprobante;
            var numeroSerieComprobante = libroDiario.NumeroSerieComprobante;
            var numeroComprobante = libroDiario.NumeroComprobante;
            var fechaContable = Formato.FormateaFecha("DD/MM/AAAA", libroDiario.FechaContable);
            var fechaVencimiento = Formato.FormateaFecha("DD/MM/AAAA", libroDiario.FechaVencimiento);
            var codigoLibro = libroDiario.CodigoLibro;
            var glosaReferencial = string.Empty;


            trama.Append(fechaPeriodo);
            trama.Append(separador);
            trama.Append(codigoUnicoOperacion);
            trama.Append(separador);
            trama.Append(numeroCorrelativoAsiento);
            trama.Append(separador);
            trama.Append(codigoCuentaContable);
            trama.Append(separador);
            trama.Append(codigoUnidadOperacion);
            trama.Append(separador);
            trama.Append(codigoCentrodeCosto);
            trama.Append(separador);
            trama.Append(moneda);
            trama.Append(separador);
            trama.Append(tipoDocumentoEmisor);
            trama.Append(separador);
            trama.Append(numeroDocumentoEmisor);
            trama.Append(separador);
            trama.Append(tipoComprobante);
            trama.Append(separador);
            trama.Append(numeroSerieComprobante);
            trama.Append(separador);
            trama.Append(numeroComprobante);
            trama.Append(separador);
            trama.Append(fechaContable);
            trama.Append(separador);
            trama.Append(fechaVencimiento);
            trama.Append(separador);
            trama.Append(fechaOperacion);
            trama.Append(separador);
            trama.Append(glosa);
            trama.Append(separador);
            trama.Append(glosaReferencial);
            trama.Append(separador);
            trama.Append(debe);
            trama.Append(separador);
            trama.Append(haber);
            trama.Append(separador);
            trama.Append(codigoLibro);
            trama.Append(separador);
            trama.Append(estadoOperacion);
            trama.Append(separador);

            return trama.ToString();

            /*trama.Append(numeroCorrelativoVentas);
            trama.Append(separador);
            trama.Append(numeroCorrelativoCompras);
            trama.Append(separador);
            trama.Append(numeroCorrelativoConsignacion);
            
            trama.Append(separador);
            trama.Append(planCuenta);*/
        }
    }
}
