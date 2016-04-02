﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Interfaces;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;
using LibroDiario = Carestream.AdmTramas.DataAccess.Model.LibroDiario;
using LibroLog = Carestream.AdmTramas.DataAccess.Model.LibroLog;
using LibroMayor = Carestream.AdmTramas.DataAccess.Model.LibroMayor;
using RegistroCompra = Carestream.AdmTramas.DataAccess.Model.RegistroCompra;
using RegistroVenta = Carestream.AdmTramas.DataAccess.Model.RegistroVenta;

namespace Carestream.AdmTramas.DataAccess.Repository.Versiones.Version_3_0
{
    public class DALibroLog
    {
        private readonly AdmTramasContainer context;

        private bool disposed = false;

        public DALibroLog(AdmTramasContainer context)
        {
            this.context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<LibroLog> Listar(string tipoLog)
        {
            var lst = new List<LibroLog>();

            using (context)
            {
                return context.ListarLibroLog(tipoLog).ToList();
            }
        }

        public List<RegistroVenta> ConsultaImportVentas(int idLibroLog)
        {
            var lst = new List<RegistroVenta>();

            using (context)
            {
                return context.ConsultaImportVentas(idLibroLog).ToList();
            }
        }

        public List<LibroDiario> ConsultaLibroDiarioPorPeriodo(DateTime periodo)
        {
            throw new NotImplementedException();
        }

        public int Guardar(LibroLog libroLog)
        {
            var id = 0;

            using (context)
            {
                context.LibroLogs.Add(libroLog);

                context.SaveChanges();

                id = Convert.ToInt32(context.ObtieneMaximoLibroLog(libroLog.IdLibro));
            }

            return id;
        }

        public void GuardarDetalleImportVentas(List<RegistroVenta> lstRegistroVentas)
        {
            var dt = new DataTable();

            var dc1 = new DataColumn("idlibrolog");
            var dc28 = new DataColumn("idlibro");
            var dc2 = new DataColumn("linea");
            var dc3 = new DataColumn("numerocorrelativo");
            var dc4 = new DataColumn("fechacomprobante");
            var dc5 = new DataColumn("tipocomprobante");
            var dc7 = new DataColumn("seriecomprobante");
            var dc8 = new DataColumn("numerocomprobante");
            var dc9 = new DataColumn("tipodocumento");
            var dc10 = new DataColumn("numerodocumento");
            var dc11 = new DataColumn("codigodocumento");
            var dc12 = new DataColumn("nombrerazonsocial");
            var dc13 = new DataColumn("valorventaoriginal");
            var dc14 = new DataColumn("moneda");
            var dc15 = new DataColumn("tipocambio");
            var dc16 = new DataColumn("vv");
            var dc17 = new DataColumn("igv");
            var dc18 = new DataColumn("pv");
            var dc19 = new DataColumn("fechamodificada");
            var dc20 = new DataColumn("tipomodcomprobantemodificado");
            var dc21 = new DataColumn("numeroseriemodificado");
            var dc22 = new DataColumn("numerocomprobantemodificado");
            var dc23 = new DataColumn("vvmodificado");
            var dc24 = new DataColumn("igvmodificado");
            var dc25 = new DataColumn("pvmodificado");
            var dc26 = new DataColumn("operacionogravada");
            var dc27 = new DataColumn("numerounicooperacion");

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);
            dt.Columns.Add(dc9);
            dt.Columns.Add(dc10);
            dt.Columns.Add(dc11);
            dt.Columns.Add(dc12);
            dt.Columns.Add(dc13);
            dt.Columns.Add(dc14);
            dt.Columns.Add(dc15);
            dt.Columns.Add(dc16);
            dt.Columns.Add(dc17);
            dt.Columns.Add(dc18);
            dt.Columns.Add(dc19);
            dt.Columns.Add(dc20);
            dt.Columns.Add(dc21);
            dt.Columns.Add(dc22);
            dt.Columns.Add(dc23);
            dt.Columns.Add(dc24);
            dt.Columns.Add(dc25);
            dt.Columns.Add(dc26);
            dt.Columns.Add(dc27);
            dt.Columns.Add(dc28);

            var dr = dt.NewRow();

            foreach (var obj in lstRegistroVentas)
            {
                dr = dt.NewRow();

                dr["idlibrolog"] = obj.IdLibroLog;
                dr["linea"] = obj.Linea;
                dr["numerocorrelativo"] = obj.NumeroCorrelativo;
                dr["fechacomprobante"] = obj.FechaComprobante;
                dr["tipocomprobante"] = obj.TipoComprobante;
                dr["seriecomprobante"] = obj.SerieComprobante;
                dr["numerocomprobante"] = obj.NumeroComprobante;
                dr["tipodocumento"] = obj.TipoDocumento;
                dr["numerodocumento"] = obj.NumeroComprobante;
                dr["codigodocumento"] = obj.CodigoDocumento;
                dr["nombrerazonsocial"] = obj.NombreRazonSocial;
                dr["valorventaoriginal"] = obj.ValorVentaOriginal;
                dr["moneda"] = obj.Moneda;
                dr["tipocambio"] = obj.TipoCambio;
                dr["vv"] = obj.VV;
                dr["igv"] = obj.IGV;
                dr["pv"] = obj.PV;
                dr["fechamodificada"] = obj.FechaModificada;
                dr["tipomodcomprobantemodificado"] = obj.TipoComprobanteModificado;
                dr["numeroseriemodificado"] = obj.NumeroSerieModificado;
                dr["numerocomprobantemodificado"] = obj.NumeroComprobanteModificado;
                dr["vvmod"] = obj.VVModificado;
                dr["igvmod"] = obj.IGVModificado;
                dr["pvmod"] = obj.PVModificado;
                dr["operacionogravada"] = obj.OperacionNoGravada;
                dr["numerounicooperacion"] = obj.NumeroUnicoOperacion;

                dt.Rows.Add(dr);
            }

            using (var sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (var sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.RegistroVentas";

                    var idlibrolog = new SqlBulkCopyColumnMapping("idlibrolog",
                        "idlibrolog");
                    sqlBlk.ColumnMappings.Add(idlibrolog);

                    var linea = new SqlBulkCopyColumnMapping("linea",
                        "linea");
                    sqlBlk.ColumnMappings.Add(linea);

                    var numerocorrelativo = new SqlBulkCopyColumnMapping("numerocorrelativo",
                        "numerocorrelativo");
                    sqlBlk.ColumnMappings.Add(numerocorrelativo);

                    var fechacomprobante = new SqlBulkCopyColumnMapping("fechacomprobante",
                        "fechacomprobante");
                    sqlBlk.ColumnMappings.Add(fechacomprobante);

                    var tipocomprobante = new SqlBulkCopyColumnMapping("tipocomprobante",
                        "tipocomprobante");
                    sqlBlk.ColumnMappings.Add(tipocomprobante);

                    var seriecomprobante = new SqlBulkCopyColumnMapping("seriecomprobante",
                        "seriecomprobante");
                    sqlBlk.ColumnMappings.Add(seriecomprobante);

                    var numerocomprobante = new SqlBulkCopyColumnMapping("numerocomprobante",
                        "numerocomprobante");
                    sqlBlk.ColumnMappings.Add(numerocomprobante);

                    var tipodocumento = new SqlBulkCopyColumnMapping("tipodocumento",
                        "tipodocumento");
                    sqlBlk.ColumnMappings.Add(tipodocumento);

                    var numerodocumento = new SqlBulkCopyColumnMapping("numerodocumento",
                        "numerodocumento");
                    sqlBlk.ColumnMappings.Add(numerodocumento);

                    var codigodocumento = new SqlBulkCopyColumnMapping("codigodocumento",
                        "codigodocumento");
                    sqlBlk.ColumnMappings.Add(codigodocumento);

                    var nombrerazonsocial = new SqlBulkCopyColumnMapping("nombrerazonsocial",
                        "nombrerazonsocial");
                    sqlBlk.ColumnMappings.Add(nombrerazonsocial);

                    var valorventaoriginal = new SqlBulkCopyColumnMapping("valorventaoriginal",
                        "valorventaoriginal");
                    sqlBlk.ColumnMappings.Add(valorventaoriginal);

                    var moneda = new SqlBulkCopyColumnMapping("moneda",
                        "moneda");
                    sqlBlk.ColumnMappings.Add(moneda);

                    var tipocambio = new SqlBulkCopyColumnMapping("tipocambio",
                        "tipocambio");
                    sqlBlk.ColumnMappings.Add(tipocambio);

                    var vv = new SqlBulkCopyColumnMapping("vv",
                        "vv");
                    sqlBlk.ColumnMappings.Add(vv);

                    var igv = new SqlBulkCopyColumnMapping("igv",
                        "igv");
                    sqlBlk.ColumnMappings.Add(igv);

                    var pv = new SqlBulkCopyColumnMapping("pv",
                        "pv");
                    sqlBlk.ColumnMappings.Add(pv);

                    var fechamod = new SqlBulkCopyColumnMapping("fechamodificada",
                        "fechamodificada");
                    sqlBlk.ColumnMappings.Add(fechamod);

                    var tipomodcomprobantemodificado = new SqlBulkCopyColumnMapping("tipomodcomprobantemodificado",
                        "tipomodcomprobantemodificado");
                    sqlBlk.ColumnMappings.Add(tipomodcomprobantemodificado);

                    var numeroSerieModificado = new SqlBulkCopyColumnMapping("NumeroSerieModificado",
                        "NumeroSerieModificado");
                    sqlBlk.ColumnMappings.Add(numeroSerieModificado);

                    var nomod = new SqlBulkCopyColumnMapping("nomod",
                        "nomod");
                    sqlBlk.ColumnMappings.Add(nomod);

                    var vvmod = new SqlBulkCopyColumnMapping("vvmod",
                        "vvmod");
                    sqlBlk.ColumnMappings.Add(vvmod);

                    var igvmod = new SqlBulkCopyColumnMapping("igvmod",
                        "igvmod");
                    sqlBlk.ColumnMappings.Add(igvmod);

                    var pvmod = new SqlBulkCopyColumnMapping("pvmod",
                        "pvmod");
                    sqlBlk.ColumnMappings.Add(pvmod);

                    var operacionogravada = new SqlBulkCopyColumnMapping("operacionogravada",
                        "operacionogravada");
                    sqlBlk.ColumnMappings.Add(operacionogravada);

                    var numerounicooperacion = new SqlBulkCopyColumnMapping("numerounicooperacion",
                        "numerounicooperacion");
                    sqlBlk.ColumnMappings.Add(numerounicooperacion);

                    sqlBlk.WriteToServer(dt);
                }
            }
        }

        public void GuardarDetalleImportCompras(List<RegistroCompra> lstRegistroCompras)
        {
            var dt = new DataTable();

            var dc1 = new DataColumn("idlibrolog");
            var dc2 = new DataColumn("linea");
            var dc3 = new DataColumn("idlibro");
            var dc4 = new DataColumn("numeroperacion");
            var dc57 = new DataColumn("FechaEmision");
            var dc5 = new DataColumn("FechaVencimiento");
            var dc6 = new DataColumn("TipoComprobante");
            var dc7 = new DataColumn("NumeroSerieComprobante");
            var dc8 = new DataColumn("AnioEmisionComprobante");
            var dc9 = new DataColumn("NumeroComprobante");
            var dc10 = new DataColumn("TipoDocumento");
            var dc11 = new DataColumn("NumeroDocumento");
            var dc12 = new DataColumn("NombreRazonSocial");
            var dc13 = new DataColumn("BaseImponibleGravada");
            var dc14 = new DataColumn("IGVGravado");
            var dc15 = new DataColumn("BaseImponibleMixta");
            var dc16 = new DataColumn("IGVMixto");
            var dc17 = new DataColumn("BaseImponibleNoGravada");
            var dc18 = new DataColumn("IGVNoGravado");
            var dc19 = new DataColumn("AdquisicionNoGravada");
            var dc20 = new DataColumn("ISC");
            var dc21 = new DataColumn("OtrosTributos");
            var dc22 = new DataColumn("Total");
            var dc23 = new DataColumn("ComprobanteNoDomiciliado");
            var dc24 = new DataColumn("NumeroConstancia");
            var dc25 = new DataColumn("FechaEmisionConstancia");
            var dc26 = new DataColumn("TipoCambio");
            var dc27 = new DataColumn("FechaOriginal");
            var dc28 = new DataColumn("TipoDocumentoOriginal");
            var dc29 = new DataColumn("NumeroSerieOriginal");
            var dc30 = new DataColumn("NumeroDocumentoOriginal");
            var dc31 = new DataColumn("Pago");
            var dc32 = new DataColumn("FechaPago");
            var dc33 = new DataColumn("Detraccion");
            var dc34 = new DataColumn("TasaDetraccion");
            var dc35 = new DataColumn("ImporteDetraccion");
            var dc36 = new DataColumn("Retencion");
            var dc37 = new DataColumn("ImporteRetencion");
            var dc38 = new DataColumn("MotivoRetencion");
            var dc39 = new DataColumn("RevisionTasa");
            var dc40 = new DataColumn("RevisionTipoCambio");
            var dc41 = new DataColumn("RevisionVerificacion");
            var dc42 = new DataColumn("BaseRevision");
            var dc43 = new DataColumn("IGVRevision");
            var dc44 = new DataColumn("TipoGasto");
            var dc45 = new DataColumn("Recepcion");
            var dc46 = new DataColumn("Comentario1");
            var dc47 = new DataColumn("Comentario2");
            var dc48 = new DataColumn("VB");
            var dc49 = new DataColumn("CompraGravadaPais");
            var dc50 = new DataColumn("CompraGravadaExterior");
            var dc51 = new DataColumn("CompraNoGravada");
            var dc52 = new DataColumn("IGVPais");
            var dc53 = new DataColumn("Exterior");
            var dc54 = new DataColumn("OtrosCargos");
            var dc55 = new DataColumn("OtrosCargos");
            var dc56 = new DataColumn("Estado");

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);
            dt.Columns.Add(dc9);
            dt.Columns.Add(dc10);
            dt.Columns.Add(dc11);
            dt.Columns.Add(dc12);
            dt.Columns.Add(dc13);
            dt.Columns.Add(dc14);
            dt.Columns.Add(dc15);
            dt.Columns.Add(dc16);
            dt.Columns.Add(dc17);
            dt.Columns.Add(dc18);
            dt.Columns.Add(dc19);
            dt.Columns.Add(dc20);
            dt.Columns.Add(dc21);
            dt.Columns.Add(dc22);
            dt.Columns.Add(dc23);
            dt.Columns.Add(dc24);
            dt.Columns.Add(dc25);
            dt.Columns.Add(dc26);
            dt.Columns.Add(dc27);
            dt.Columns.Add(dc28);
            dt.Columns.Add(dc29);
            dt.Columns.Add(dc30);
            dt.Columns.Add(dc31);
            dt.Columns.Add(dc32);
            dt.Columns.Add(dc33);
            dt.Columns.Add(dc34);
            dt.Columns.Add(dc35);
            dt.Columns.Add(dc36);
            dt.Columns.Add(dc37);
            dt.Columns.Add(dc38);
            dt.Columns.Add(dc39);
            dt.Columns.Add(dc40);
            dt.Columns.Add(dc41);
            dt.Columns.Add(dc42);
            dt.Columns.Add(dc43);
            dt.Columns.Add(dc44);
            dt.Columns.Add(dc45);
            dt.Columns.Add(dc46);
            dt.Columns.Add(dc47);
            dt.Columns.Add(dc48);
            dt.Columns.Add(dc49);
            dt.Columns.Add(dc50);
            dt.Columns.Add(dc51);
            dt.Columns.Add(dc52);
            dt.Columns.Add(dc53);
            dt.Columns.Add(dc54);
            dt.Columns.Add(dc55);
            dt.Columns.Add(dc56);
            dt.Columns.Add(dc57);

            var dr = dt.NewRow();

            foreach (var obj in lstRegistroCompras)
            {
                dr = dt.NewRow();

                dr["IdLibroLog"] = obj.IdLibroLog;
                dr["Linea"] = obj.Linea;
                dr["IdLibro"] = obj.IdLibro;
                dr["NumeroOperacion"] = obj.NumeroOperacion;
                dr["FechaEmision"] = obj.FechaEmision;
                dr["FechaVencimiento"] = obj.FechaVencimiento;
                dr["TipoComprobante"] = obj.TipoComprobante;
                dr["NumeroSerieComprobante"] = obj.NumeroSerieComprobante;
                dr["AnioEmisionComprobante"] = obj.AnioEmisionComprobante;
                dr["NumeroComprobante"] = obj.NumeroComprobante;
                dr["TipoDocumento"] = obj.TipoDocumento;
                dr["NumeroDocumento"] = obj.NumeroDocumento;
                dr["NombreRazonSocial"] = obj.NombreRazonSocial;
                dr["BaseImponibleGravada"] = obj.BaseImponibleGravada;
                dr["IGVGravado"] = obj.IGVGravado;
                dr["BaseImponibleMixta"] = obj.BaseImponibleMixta;
                dr["IGVMixto"] = obj.IGVMixto;
                dr["BaseImponibleNoGravada"] = obj.BaseImponibleNoGravada;
                dr["IGVNoGravado"] = obj.IGVNoGravado;
                dr["AdquisicionNoGravada"] = obj.AdquisicionNoGravada;
                dr["ISC"] = obj.ISC;
                dr["OtrosTributos"] = obj.OtrosTributos;
                dr["Total"] = obj.Total;
                dr["ComprobanteNoDomiciliado"] = obj.ComprobanteNoDomiciliado;
                dr["NumeroConstancia"] = obj.NumeroConstancia;
                dr["FechaEmisionConstancia"] = obj.FechaEmisionConstancia;
                dr["TipoCambio"] = obj.TipoCambio;
                dr["FechaOriginal"] = obj.FechaOriginal;
                dr["TipoDocumentoOriginal"] = obj.TipoDocumentoOriginal;
                dr["NumeroSerieOriginal"] = obj.NumeroSerieOriginal;
                dr["NumeroDocumentoOriginal"] = obj.NumeroDocumentoOriginal;
                dr["Pago"] = obj.Pago;
                dr["FechaPago"] = obj.FechaPago;
                dr["Detraccion"] = obj.Detraccion;
                dr["TasaDetraccion"] = obj.TasaDetraccion;
                dr["ImporteDetraccion"] = obj.ImporteDetraccion;
                dr["Retencion"] = obj.Retencion;
                dr["ImporteRetencion"] = obj.ImporteRetencion;
                dr["MotivoRetencion"] = obj.MotivoRetencion;
                dr["RevisionTasa"] = obj.RevisionTasa;
                dr["RevisionTipoCambio"] = obj.RevisionTipoCambio;
                dr["RevisionVerificacion"] = obj.RevisionVerificacion;
                dr["BaseRevision"] = obj.BaseRevision;
                dr["IGVRevision"] = obj.IGVRevision;
                dr["TipoGasto"] = obj.TipoGasto;
                dr["Recepcion"] = obj.Recepcion;
                dr["Comentario1"] = obj.Comentario1;
                dr["Comentario2"] = obj.Comentario2;
                dr["VB"] = obj.VB;
                dr["CompraGravadaPais"] = obj.CompraGravadaPais;
                dr["CompraGravadaExterior"] = obj.CompraGravadaExterior;
                dr["CompraNoGravada"] = obj.CompraNoGravada;
                dr["IGVPais"] = obj.IGVPais;
                dr["Exterior"] = obj.Exterior;
                dr["OtrosCargos"] = obj.OtrosCargos;
                dr["Total1"] = obj.Total1;
                dr["Estado"] = obj.Estado;

                dt.Rows.Add(dr);
            }

            using (var sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (var sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.RegistroCompras";

                    var idlibrolog = new SqlBulkCopyColumnMapping("idlibrolog",
                        "idlibrolog");
                    sqlBlk.ColumnMappings.Add(idlibrolog);

                    var linea = new SqlBulkCopyColumnMapping("linea",
                        "linea");
                    sqlBlk.ColumnMappings.Add(linea);

                    var numeroOperacion = new SqlBulkCopyColumnMapping("NumeroOperacion",
                        "NumeroOperacion");
                    sqlBlk.ColumnMappings.Add(numeroOperacion);

                    var fechaEmision = new SqlBulkCopyColumnMapping("FechaEmision",
                        "FechaEmision");
                    sqlBlk.ColumnMappings.Add(fechaEmision);

                    var fechaVencimiento = new SqlBulkCopyColumnMapping("FechaVencimiento",
                        "FechaVencimiento");
                    sqlBlk.ColumnMappings.Add(fechaVencimiento);

                    var tipoComprobante = new SqlBulkCopyColumnMapping("TipoComprobante",
                        "TipoComprobante");
                    sqlBlk.ColumnMappings.Add(tipoComprobante);

                    var numeroSerieComprobante = new SqlBulkCopyColumnMapping("NumeroSerieComprobante",
                        "NumeroSerieComprobante");
                    sqlBlk.ColumnMappings.Add(numeroSerieComprobante);

                    var anioEmisionComprobante = new SqlBulkCopyColumnMapping("AnioEmisionComprobante",
                        "AnioEmisionComprobante");
                    sqlBlk.ColumnMappings.Add(anioEmisionComprobante);

                    var numeroComprobante = new SqlBulkCopyColumnMapping("NumeroComprobante",
                        "NumeroComprobante");
                    sqlBlk.ColumnMappings.Add(numeroComprobante);

                    var tipo_documento = new SqlBulkCopyColumnMapping("tipo_documento",
                        "tipo_documento");
                    sqlBlk.ColumnMappings.Add(tipo_documento);

                    var tipoDocumento = new SqlBulkCopyColumnMapping("TipoDocumento",
                        "TipoDocumento");
                    sqlBlk.ColumnMappings.Add(tipoDocumento);

                    var numeroDocumento = new SqlBulkCopyColumnMapping("NumeroDocumento",
                        "NumeroDocumento");
                    sqlBlk.ColumnMappings.Add(numeroDocumento);

                    var nombreRazonSocial = new SqlBulkCopyColumnMapping("NombreRazonSocial",
                        "NombreRazonSocial");
                    sqlBlk.ColumnMappings.Add(nombreRazonSocial);

                    var baseImponibleGravada = new SqlBulkCopyColumnMapping("BaseImponibleGravada",
                        "BaseImponibleGravada");
                    sqlBlk.ColumnMappings.Add(baseImponibleGravada);

                    var IGVGravado = new SqlBulkCopyColumnMapping("IGVGravado",
                        "IGVGravado");
                    sqlBlk.ColumnMappings.Add(IGVGravado);

                    var baseImponibleMixta = new SqlBulkCopyColumnMapping("BaseImponibleMixta",
                        "BaseImponibleMixta");
                    sqlBlk.ColumnMappings.Add(baseImponibleMixta);

                    var IGVMixto = new SqlBulkCopyColumnMapping("IGVMixto",
                        "IGVMixto");
                    sqlBlk.ColumnMappings.Add(IGVMixto);

                    var baseImponibleNoGravada = new SqlBulkCopyColumnMapping("BaseImponibleNoGravada",
                        "BaseImponibleNoGravada");
                    sqlBlk.ColumnMappings.Add(baseImponibleNoGravada);

                    var IGVNoGravado = new SqlBulkCopyColumnMapping("IGVNoGravado",
                        "IGVNoGravado");
                    sqlBlk.ColumnMappings.Add(IGVNoGravado);

                    var adquisicionNoGravada = new SqlBulkCopyColumnMapping("AdquisicionNoGravada",
                        "AdquisicionNoGravada");
                    sqlBlk.ColumnMappings.Add(adquisicionNoGravada);

                    var ISC = new SqlBulkCopyColumnMapping("ISC",
                        "ISC");
                    sqlBlk.ColumnMappings.Add(ISC);

                    var otrosTributos = new SqlBulkCopyColumnMapping("OtrosTributos",
                        "OtrosTributos");
                    sqlBlk.ColumnMappings.Add(otrosTributos);

                    var total = new SqlBulkCopyColumnMapping("Total",
                        "Total");
                    sqlBlk.ColumnMappings.Add(total);

                    var comprobanteNoDomiciliado = new SqlBulkCopyColumnMapping("ComprobanteNoDomiciliado",
                        "ComprobanteNoDomiciliado");
                    sqlBlk.ColumnMappings.Add(comprobanteNoDomiciliado);

                    var numeroConstancia = new SqlBulkCopyColumnMapping("NumeroConstancia",
                        "NumeroConstancia");
                    sqlBlk.ColumnMappings.Add(numeroConstancia);

                    var fechaEmisionConstancia = new SqlBulkCopyColumnMapping("FechaEmisionConstancia",
                        "FechaEmisionConstancia");
                    sqlBlk.ColumnMappings.Add(fechaEmisionConstancia);

                    var tipoCambio = new SqlBulkCopyColumnMapping("TipoCambio",
                        "TipoCambio");
                    sqlBlk.ColumnMappings.Add(tipoCambio);

                    var fechaOriginal = new SqlBulkCopyColumnMapping("FechaOriginal",
                        "FechaOriginal");
                    sqlBlk.ColumnMappings.Add(fechaOriginal);

                    var tipoDocumentoOriginal = new SqlBulkCopyColumnMapping("TipoDocumentoOriginal",
                        "TipoDocumentoOriginal");
                    sqlBlk.ColumnMappings.Add(tipoDocumentoOriginal);

                    var numeroSerieOriginal = new SqlBulkCopyColumnMapping("NumeroSerieOriginal",
                        "NumeroSerieOriginal");
                    sqlBlk.ColumnMappings.Add(numeroSerieOriginal);

                    var numeroDocumentoOriginal = new SqlBulkCopyColumnMapping("NumeroDocumentoOriginal",
                        "NumeroDocumentoOriginal");
                    sqlBlk.ColumnMappings.Add(numeroDocumentoOriginal);

                    var pago = new SqlBulkCopyColumnMapping("Pago",
                        "Pago");
                    sqlBlk.ColumnMappings.Add(pago);

                    var fechaPago = new SqlBulkCopyColumnMapping("FechaPago",
                        "FechaPago");
                    sqlBlk.ColumnMappings.Add(fechaPago);

                    var detraccion = new SqlBulkCopyColumnMapping("Detraccion",
                        "Detraccion");
                    sqlBlk.ColumnMappings.Add(detraccion);

                    var tasaDetraccion = new SqlBulkCopyColumnMapping("TasaDetraccion",
                        "TasaDetraccion");
                    sqlBlk.ColumnMappings.Add(tasaDetraccion);

                    var importeDetraccion = new SqlBulkCopyColumnMapping("ImporteDetraccion",
                        "ImporteDetraccion");
                    sqlBlk.ColumnMappings.Add(importeDetraccion);

                    var retencion = new SqlBulkCopyColumnMapping("Retencion",
                        "Retencion");
                    sqlBlk.ColumnMappings.Add(retencion);

                    var importeRetencion = new SqlBulkCopyColumnMapping("ImporteRetencion",
                        "ImporteRetencion");
                    sqlBlk.ColumnMappings.Add(importeRetencion);

                    var motivoRetencion = new SqlBulkCopyColumnMapping("MotivoRetencion",
                        "MotivoRetencion");
                    sqlBlk.ColumnMappings.Add(motivoRetencion);

                    var revisionTasa = new SqlBulkCopyColumnMapping("RevisionTasa",
                        "RevisionTasa");
                    sqlBlk.ColumnMappings.Add(revisionTasa);

                    var revisionTipoCambio = new SqlBulkCopyColumnMapping("RevisionTipoCambio",
                        "RevisionTipoCambio");
                    sqlBlk.ColumnMappings.Add(revisionTipoCambio);

                    var revisionVerificacion = new SqlBulkCopyColumnMapping("RevisionVerificacion",
                        "RevisionVerificacion");
                    sqlBlk.ColumnMappings.Add(revisionVerificacion);

                    var baseRevision = new SqlBulkCopyColumnMapping("BaseRevision",
                        "BaseRevision");
                    sqlBlk.ColumnMappings.Add(baseRevision);

                    var IGVRevision = new SqlBulkCopyColumnMapping("IGVRevision",
                        "IGVRevision");
                    sqlBlk.ColumnMappings.Add(IGVRevision);

                    var tipoGasto = new SqlBulkCopyColumnMapping("TipoGasto",
                        "TipoGasto");
                    sqlBlk.ColumnMappings.Add(tipoGasto);

                    var recepcion = new SqlBulkCopyColumnMapping("Recepcion",
                        "Recepcion");
                    sqlBlk.ColumnMappings.Add(recepcion);

                    var comentario1 = new SqlBulkCopyColumnMapping("Comentario1",
                        "Comentario1");
                    sqlBlk.ColumnMappings.Add(comentario1);

                    var comentario2 = new SqlBulkCopyColumnMapping("Comentario2",
                        "Comentario2");
                    sqlBlk.ColumnMappings.Add(comentario2);

                    var VB = new SqlBulkCopyColumnMapping("VB",
                        "VB");
                    sqlBlk.ColumnMappings.Add(VB);

                    var compraGravadaPais = new SqlBulkCopyColumnMapping("CompraGravadaPais",
                        "CompraGravadaPais");
                    sqlBlk.ColumnMappings.Add(compraGravadaPais);

                    var compraGravadaExterior = new SqlBulkCopyColumnMapping("CompraGravadaExterior",
                        "CompraGravadaExterior");
                    sqlBlk.ColumnMappings.Add(compraGravadaExterior);

                    var compraNoGravada = new SqlBulkCopyColumnMapping("CompraNoGravada",
                        "CompraNoGravada");
                    sqlBlk.ColumnMappings.Add(compraNoGravada);

                    var IGVPais = new SqlBulkCopyColumnMapping("IGVPais",
                        "IGVPais");
                    sqlBlk.ColumnMappings.Add(IGVPais);

                    var exterior = new SqlBulkCopyColumnMapping("Exterior",
                        "Exterior");
                    sqlBlk.ColumnMappings.Add(exterior);

                    var otrosCargos = new SqlBulkCopyColumnMapping("OtrosCargos",
                        "OtrosCargos");
                    sqlBlk.ColumnMappings.Add(otrosCargos);

                    var total1 = new SqlBulkCopyColumnMapping("Total1",
                        "Total1");
                    sqlBlk.ColumnMappings.Add(total1);

                    var estado = new SqlBulkCopyColumnMapping("Estado",
                        "Estado");
                    sqlBlk.ColumnMappings.Add(estado);

                    sqlBlk.WriteToServer(dt);
                }
            }
        }

        public void GuardarDetalleImportDiario(List<LibroDiarioAgrupado> lstLibroDiarioAgrupado, List<LibroDiario> lstLibroDiarios)
        {
            throw new NotImplementedException();
        }

        public void GuardarDetalleImportDiario(List<LibroDiario> lstLibroDiario)
        {
            var dt = new DataTable();

            var dc1 = new DataColumn("linea");
            var dc2 = new DataColumn("idlibrolog");
            var dc3 = new DataColumn("fecha");
            var dc4 = new DataColumn("numerocorrelativo");
            var dc5 = new DataColumn("CodigoUnico");
            var dc6 = new DataColumn("referencia");
            var dc7 = new DataColumn("cuenta");
            var dc8 = new DataColumn("centro");
            var dc9 = new DataColumn("DescripcionAsiento");
            var dc10 = new DataColumn("debe");
            var dc11 = new DataColumn("haber");
            var dc12 = new DataColumn("idLibro");

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);
            dt.Columns.Add(dc9);
            dt.Columns.Add(dc10);
            dt.Columns.Add(dc11);
            dt.Columns.Add(dc12);

            DataRow dr = dt.NewRow();

            foreach (var obj in lstLibroDiario)
            {
                dr = dt.NewRow();

                dr["IdLibroLog"] = obj.IdLibroLog;
                dr["Linea"] = obj.Linea;
                dr["Fecha"] = obj.Fecha;
                dr["NumeroCorrelativo"] = obj.NumeroCorrelativo;
                dr["CodigoUnico"] = obj.CodigoUnico;
                dr["Referencia"] = obj.Referencia;
                dr["Cuenta"] = obj.Cuenta;
                dr["Centro"] = obj.Centro;
                dr["DescripcionAsiento"] = obj.DescripcionAsiento;
                dr["debe"] = obj.Debe;
                dr["haber"] = obj.Haber;
                dr["IdLibro"] = obj.IdLibro;

                dt.Rows.Add(dr);
            }

            using (var sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (var sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.Librodiarios";

                    var linea = new SqlBulkCopyColumnMapping("Linea",
                        "Linea");
                    sqlBlk.ColumnMappings.Add(linea);

                    var idLibroLog = new SqlBulkCopyColumnMapping("IdLibroLog",
                        "IdLibroLog");
                    sqlBlk.ColumnMappings.Add(idLibroLog);

                    var fecha = new SqlBulkCopyColumnMapping("Fecha",
                        "Fecha");
                    sqlBlk.ColumnMappings.Add(fecha);

                    var numeroCorrelativo = new SqlBulkCopyColumnMapping("NumeroCorrelativo",
                        "NumeroCorrelativo");
                    sqlBlk.ColumnMappings.Add(numeroCorrelativo);

                    var codigoUnico = new SqlBulkCopyColumnMapping("CodigoUnico",
                        "CodigoUnico");
                    sqlBlk.ColumnMappings.Add(codigoUnico);

                    var referencia = new SqlBulkCopyColumnMapping("referencia",
                        "referencia");
                    sqlBlk.ColumnMappings.Add(referencia);

                    var cuenta = new SqlBulkCopyColumnMapping("cuenta",
                        "cuenta");
                    sqlBlk.ColumnMappings.Add(cuenta);

                    var centro = new SqlBulkCopyColumnMapping("centro",
                        "centro");
                    sqlBlk.ColumnMappings.Add(centro);

                    var descripcionAsiento = new SqlBulkCopyColumnMapping("DescripcionAsiento",
                        "DescripcionAsiento");
                    sqlBlk.ColumnMappings.Add(descripcionAsiento);

                    var debe = new SqlBulkCopyColumnMapping("debe",
                        "debe");
                    sqlBlk.ColumnMappings.Add(debe);

                    var haber = new SqlBulkCopyColumnMapping("haber",
                        "haber");
                    sqlBlk.ColumnMappings.Add(haber);

                    var idLibro = new SqlBulkCopyColumnMapping("IdLibro",
                        "IdLibro");
                    sqlBlk.ColumnMappings.Add(idLibro);

                    sqlBlk.WriteToServer(dt);
                }

            }
        }

        public void GuardarDetalleImportMayor(List<LibroMayor> lstLibroMayor)
        {
            var dt = new DataTable();

            var dc1 = new DataColumn("IdLibroLog");
            var dc2 = new DataColumn("Linea");
            var dc3 = new DataColumn("IdLibro");
            var dc4 = new DataColumn("FechaOperacion");
            var dc5 = new DataColumn("Debe");
            var dc6 = new DataColumn("Glosa");
            var dc7 = new DataColumn("Estado");
            var dc8 = new DataColumn("CodUnicoOperacion");
            var dc9 = new DataColumn("NumeroCorrelativo");
            var dc10 = new DataColumn("Haber");
            var dc11 = new DataColumn("Periodo");
            var dc12 = new DataColumn("CodigoPlanCuenta");
            var dc13 = new DataColumn("CodigoCuentaContable");
            var dc14 = new DataColumn("CuoVentas");
            var dc15 = new DataColumn("CuoCompras");
            var dc16 = new DataColumn("CuoConsignaciones");

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);
            dt.Columns.Add(dc9);
            dt.Columns.Add(dc10);
            dt.Columns.Add(dc11);
            dt.Columns.Add(dc12);
            dt.Columns.Add(dc13);
            dt.Columns.Add(dc14);
            dt.Columns.Add(dc15);
            dt.Columns.Add(dc16);            

            var dr = dt.NewRow();

            foreach (var obj in lstLibroMayor)
            {
                dr = dt.NewRow();

                dr["IdLibroLog"] = obj.IdLibroLog;
                dr["Linea"] = obj.Linea;
                dr["IdLibro"] = obj.IdLibro;
                dr["FechaOperacion"] = obj.FechaOperacion;
                dr["Debe"] = obj.FechaOperacion;
                dr["Glosa"] = obj.Glosa;
                dr["Estado"] = obj.Estado;
                dr["CodUnicoOperacion"] = obj.codunicooperacion;
                dr["NumeroCorrelativo"] = obj.NumeroCorrelativo;
                dr["Haber"] = obj.Haber;
                dr["Periodo"] = obj.Periodo;
                dr["CodigoPlanCuenta"] = obj.CodigoPlanCuenta;
                dr["CodigoCuentaContable"] = obj.CodigoCuentaContable;
                dr["CuoVentas"] = obj.CuoVentas;
                dr["CuoCompras"] = obj.CuoCompras;
                dr["CuoConsignaciones"] = obj.Glosa;

                dt.Rows.Add(dr);
            }

            using (var sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (var sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.Libromayors";

                    var idLibroLog = new SqlBulkCopyColumnMapping("IdLibroLog",
                        "IdLibroLog");
                    sqlBlk.ColumnMappings.Add(idLibroLog);

                    var linea = new SqlBulkCopyColumnMapping("Linea",
                        "Linea");
                    sqlBlk.ColumnMappings.Add(linea);

                    var idLibro = new SqlBulkCopyColumnMapping("IdLibro",
                        "IdLibro");
                    sqlBlk.ColumnMappings.Add(idLibro);

                    var FechaOperacion = new SqlBulkCopyColumnMapping("FechaOperacion",
                        "FechaOperacion");
                    sqlBlk.ColumnMappings.Add(FechaOperacion);

                    var Debe = new SqlBulkCopyColumnMapping("Debe",
                        "Debe");
                    sqlBlk.ColumnMappings.Add(Debe);

                    var Glosa = new SqlBulkCopyColumnMapping("Glosa",
                        "Glosa");
                    sqlBlk.ColumnMappings.Add(Glosa);

                    var Estado = new SqlBulkCopyColumnMapping("Estado",
                        "Estado");
                    sqlBlk.ColumnMappings.Add(Estado);

                    var CodUnicoOperacion = new SqlBulkCopyColumnMapping("CodUnicoOperacion",
                        "CodUnicoOperacion");
                    sqlBlk.ColumnMappings.Add(CodUnicoOperacion);

                    var NumeroCorrelativo = new SqlBulkCopyColumnMapping("NumeroCorrelativo",
                        "NumeroCorrelativo");
                    sqlBlk.ColumnMappings.Add(NumeroCorrelativo);

                    var Haber = new SqlBulkCopyColumnMapping("Haber",
                        "Haber");
                    sqlBlk.ColumnMappings.Add(Haber);

                    var Periodo = new SqlBulkCopyColumnMapping("Periodo",
                        "Periodo");
                    sqlBlk.ColumnMappings.Add(Periodo);

                    var CodigoPlanCuenta = new SqlBulkCopyColumnMapping("CodigoPlanCuenta",
                        "CodigoPlanCuenta");
                    sqlBlk.ColumnMappings.Add(CodigoPlanCuenta);

                    var CodigoCuentaContable = new SqlBulkCopyColumnMapping("CodigoCuentaContable",
                        "CodigoCuentaContable");
                    sqlBlk.ColumnMappings.Add(CodigoCuentaContable);

                    var CuoVentas = new SqlBulkCopyColumnMapping("CuoVentas",
                        "CuoVentas");
                    sqlBlk.ColumnMappings.Add(CuoVentas);

                    var CuoCompras = new SqlBulkCopyColumnMapping("CuoCompras",
                        "CuoCompras");
                    sqlBlk.ColumnMappings.Add(CuoCompras);

                    var CuoConsignaciones = new SqlBulkCopyColumnMapping("CuoConsignaciones",
                        "CuoConsignaciones");
                    sqlBlk.ColumnMappings.Add(CuoConsignaciones);

                    sqlBlk.WriteToServer(dt);
                }
            }
        }
    }
}