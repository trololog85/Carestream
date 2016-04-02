﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Carestream.AdmTramas.Generator.Export.Tramas.Interface;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Version_4_0
{
    public class TramaLibroMayor:ITramaLibroMayor
    {
        private readonly string separador = ConfigurationManager.AppSettings["separador"];

        public void GeneraTrama(List<LibroMayor> registros, RutaArchivo ruta)
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

        private string ArmaEstructura(LibroMayor libroMayor)
        {
            var trama = new StringBuilder();

            var fechaPeriodo = libroMayor.FechaPeriodo;
            var codigoUnicoOperacion = libroMayor.CodigoUnicoOperacion;
            var numeroCorrelativoAsiento = libroMayor.NumeroCorrelativo;
            var planCuenta = libroMayor.CodigoPlanCuenta;
            var codigoCuentaContable = libroMayor.CodigoCuentaContable;
            var fechaOperacion = Formato.FormateaFecha("DD/MM/AAAA", libroMayor.FechaOperacion);
            var glosa = libroMayor.Glosa;
            var debe = libroMayor.Debe;
            var haber = libroMayor.Haber;
            var numeroCorrelativoVentas = String.Empty;
            var numeroCorrelativoCompras = String.Empty;
            var numeroCorrelativoConsignacion = String.Empty;
            var estadoOperacion = libroMayor.Estado;

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