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

        private string ArmaEstructura(LibroDiario registoCompra)
        {
            var trama = new StringBuilder();

            var fechaPeriodo = Formato.FormateaFecha("AAAAMM00", registoCompra.FechaPeriodo);
            var codigoUnicoOperacion = registoCompra.CodigoUnicoOperacion;
            var numeroCorrelativoAsiento = registoCompra.NumeroCorrelativoContable;
            var planCuenta = registoCompra.CodigoPlanCuentas;
            var codigoCuentaContable = registoCompra.CodigoCuentaContable;
            var fechaOperacion = Formato.FormateaFecha("DD/MM/AAAA", registoCompra.FechaOperacion);
            var glosa = registoCompra.Glosa;
            var debe = registoCompra.Debe;
            var haber = registoCompra.Haber;
            var numeroCorrelativoVentas = String.Empty;
            var numeroCorrelativoCompras = String.Empty;
            var numeroCorrelativoConsignacion = String.Empty;
            var estadoOperacion = registoCompra.EstadoOperacion;

            trama.Append(fechaPeriodo);
            trama.Append(separador);
            trama.Append(codigoUnicoOperacion);
            trama.Append(separador);
            trama.Append(numeroCorrelativoAsiento);
            trama.Append(separador);
            trama.Append(planCuenta);
            trama.Append(separador);
            trama.Append(codigoCuentaContable);
            trama.Append(separador);
            trama.Append(fechaOperacion);
            trama.Append(separador);
            trama.Append(glosa);
            trama.Append(separador);
            trama.Append(debe);
            trama.Append(separador);
            trama.Append(haber);
            trama.Append(separador);
            trama.Append(numeroCorrelativoVentas);
            trama.Append(separador);
            trama.Append(numeroCorrelativoCompras);
            trama.Append(separador);
            trama.Append(numeroCorrelativoConsignacion);
            trama.Append(separador);
            trama.Append(estadoOperacion);
            trama.Append(separador);

            return trama.ToString();
        }
    }
}
