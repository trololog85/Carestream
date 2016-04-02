using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Interfaces;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.DataAccess.Repository
{
    public class DALibroLog : ILibroLogRepository, IDisposable
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

        public List<LibroLog> Listar(string TipoLog)
        {
            using (context)
            {
                return context.ListarLibroLog(TipoLog).ToList();
            }
        }

        public List<RegistroVenta> ConsultaImportVentas(int IdLibroLog)
        {
            using (context)
            {
                return context.ConsultaImportVentas(IdLibroLog).ToList();
            }
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
            var dc6 = new DataColumn("internocomprobante");
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

            var dr = dt.NewRow();

            foreach (var obj in lstRegistroVentas)
            {
                dr = dt.NewRow();

                dr["idlibrolog"] = obj.IdLibroLog;
                dr["linea"] = obj.Linea;
                dr["numerocorrelativo"] = obj.NumeroCorrelativo;
                dr["fechacomprobante"] = obj.FechaComprobante;
                dr["tipocomprobante"] = obj.TipoComprobante;
                dr["internocomprobante"] = obj.InternoComprobante;
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

                    var internocomprobante = new SqlBulkCopyColumnMapping("internocomprobante",
                        "internocomprobante");
                    sqlBlk.ColumnMappings.Add(internocomprobante);

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

            foreach (RegistroCompra obj in lstRegistroCompras)
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
                    sqlBlk.DestinationTableName = "dbo.InputRegistroCompra";

                    var id_archivo_log = new SqlBulkCopyColumnMapping("id_archivo_log",
                        "id_archivo_log");
                    sqlBlk.ColumnMappings.Add(id_archivo_log);

                    var id_linea = new SqlBulkCopyColumnMapping("id_linea",
                        "id_linea");
                    sqlBlk.ColumnMappings.Add(id_linea);

                    var no_ope_rac = new SqlBulkCopyColumnMapping("no_ope_rac",
                        "no_ope_rac");
                    sqlBlk.ColumnMappings.Add(no_ope_rac);

                    var fecha_emision = new SqlBulkCopyColumnMapping("fecha_emision",
                        "fecha_emision");
                    sqlBlk.ColumnMappings.Add(fecha_emision);

                    var fecha_vencimiento = new SqlBulkCopyColumnMapping("fecha_vencimiento",
                        "fecha_vencimiento");
                    sqlBlk.ColumnMappings.Add(fecha_vencimiento);

                    var tipo_comprobante = new SqlBulkCopyColumnMapping("tipo_comprobante",
                        "tipo_comprobante");
                    sqlBlk.ColumnMappings.Add(tipo_comprobante);

                    var nro_serie_comprobante = new SqlBulkCopyColumnMapping("nro_serie_comprobante",
                        "nro_serie_comprobante");
                    sqlBlk.ColumnMappings.Add(nro_serie_comprobante);

                    var anio_emision_comprobante = new SqlBulkCopyColumnMapping("anio_emision_comprobante",
                        "anio_emision_comprobante");
                    sqlBlk.ColumnMappings.Add(anio_emision_comprobante);

                    var numero_comprobante = new SqlBulkCopyColumnMapping("numero_comprobante",
                        "numero_comprobante");
                    sqlBlk.ColumnMappings.Add(numero_comprobante);

                    var tipo_documento = new SqlBulkCopyColumnMapping("tipo_documento",
                        "tipo_documento");
                    sqlBlk.ColumnMappings.Add(tipo_documento);

                    var numero_documento = new SqlBulkCopyColumnMapping("numero_documento",
                        "numero_documento");
                    sqlBlk.ColumnMappings.Add(numero_documento);

                    var apell_nomb_raz_soc = new SqlBulkCopyColumnMapping("apell_nomb_raz_soc",
                        "apell_nomb_raz_soc");
                    sqlBlk.ColumnMappings.Add(apell_nomb_raz_soc);

                    var base_imponible_grav = new SqlBulkCopyColumnMapping("base_imponible_grav",
                        "base_imponible_grav");
                    sqlBlk.ColumnMappings.Add(base_imponible_grav);

                    var igv_gravado = new SqlBulkCopyColumnMapping("igv_gravado",
                        "igv_gravado");
                    sqlBlk.ColumnMappings.Add(igv_gravado);

                    var base_imp_mixta = new SqlBulkCopyColumnMapping("base_imp_mixta",
                        "base_imp_mixta");
                    sqlBlk.ColumnMappings.Add(base_imp_mixta);

                    var igv_mixto = new SqlBulkCopyColumnMapping("igv_mixto",
                        "igv_mixto");
                    sqlBlk.ColumnMappings.Add(igv_mixto);

                    var base_imp_no_grav = new SqlBulkCopyColumnMapping("base_imp_no_grav",
                        "base_imp_no_grav");
                    sqlBlk.ColumnMappings.Add(base_imp_no_grav);

                    var igv_no_grav = new SqlBulkCopyColumnMapping("igv_no_grav",
                        "igv_no_grav");
                    sqlBlk.ColumnMappings.Add(igv_no_grav);

                    var adq_no_grav = new SqlBulkCopyColumnMapping("adq_no_grav",
                        "adq_no_grav");
                    sqlBlk.ColumnMappings.Add(adq_no_grav);

                    var isc = new SqlBulkCopyColumnMapping("isc",
                        "isc");
                    sqlBlk.ColumnMappings.Add(isc);

                    var otros_tributos = new SqlBulkCopyColumnMapping("otros_tributos",
                        "otros_tributos");
                    sqlBlk.ColumnMappings.Add(otros_tributos);

                    var total = new SqlBulkCopyColumnMapping("total",
                        "total");
                    sqlBlk.ColumnMappings.Add(total);

                    var comp_no_domic = new SqlBulkCopyColumnMapping("comp_no_domic",
                        "comp_no_domic");
                    sqlBlk.ColumnMappings.Add(comp_no_domic);

                    var num_constancia = new SqlBulkCopyColumnMapping("num_constancia",
                        "num_constancia");
                    sqlBlk.ColumnMappings.Add(num_constancia);

                    var fecha_emision_const = new SqlBulkCopyColumnMapping("fecha_emision_const",
                        "fecha_emision_const");
                    sqlBlk.ColumnMappings.Add(fecha_emision_const);

                    var tipo_cambio = new SqlBulkCopyColumnMapping("tipo_cambio",
                        "tipo_cambio");
                    sqlBlk.ColumnMappings.Add(tipo_cambio);

                    var fecha_original = new SqlBulkCopyColumnMapping("fecha_original",
                        "fecha_original");
                    sqlBlk.ColumnMappings.Add(fecha_original);

                    var tipo_doc_orig = new SqlBulkCopyColumnMapping("tipo_doc_orig",
                        "tipo_doc_orig");
                    sqlBlk.ColumnMappings.Add(tipo_doc_orig);

                    var num_serie_orig = new SqlBulkCopyColumnMapping("num_serie_orig",
                        "num_serie_orig");
                    sqlBlk.ColumnMappings.Add(num_serie_orig);

                    var num_doc_orig = new SqlBulkCopyColumnMapping("num_doc_orig",
                        "num_doc_orig");
                    sqlBlk.ColumnMappings.Add(num_doc_orig);

                    var pago = new SqlBulkCopyColumnMapping("pago",
                        "pago");

                    var fecha_pago = new SqlBulkCopyColumnMapping("fecha_pago",
                        "fecha_pago");
                    sqlBlk.ColumnMappings.Add(fecha_pago);

                    var detraccion = new SqlBulkCopyColumnMapping("detraccion",
                        "detraccion");
                    sqlBlk.ColumnMappings.Add(detraccion);

                    var tasa_detraccion = new SqlBulkCopyColumnMapping("tasa_detraccion",
                        "tasa_detraccion");
                    sqlBlk.ColumnMappings.Add(tasa_detraccion);

                    var importe_detraccion = new SqlBulkCopyColumnMapping("importe_detraccion",
                        "importe_detraccion");
                    sqlBlk.ColumnMappings.Add(importe_detraccion);

                    var retencion = new SqlBulkCopyColumnMapping("retencion",
                        "retencion");
                    sqlBlk.ColumnMappings.Add(retencion);

                    var importe_retencion = new SqlBulkCopyColumnMapping("importe_retencion",
                        "importe_retencion");
                    sqlBlk.ColumnMappings.Add(importe_retencion);

                    var motivo_retencion = new SqlBulkCopyColumnMapping("motivo_retencion",
                        "motivo_retencion");
                    sqlBlk.ColumnMappings.Add(motivo_retencion);

                    var revision_tasa = new SqlBulkCopyColumnMapping("revision_tasa",
                        "revision_tasa");
                    sqlBlk.ColumnMappings.Add(revision_tasa);

                    var revision_tipo_cambio = new SqlBulkCopyColumnMapping("revision_tipo_cambio",
                        "revision_tipo_cambio");
                    sqlBlk.ColumnMappings.Add(revision_tipo_cambio);

                    var revision_verificacion = new SqlBulkCopyColumnMapping("revision_verificacion",
                        "revision_verificacion");
                    sqlBlk.ColumnMappings.Add(revision_verificacion);

                    var base_revision = new SqlBulkCopyColumnMapping("base_revision",
                        "base_revision");
                    sqlBlk.ColumnMappings.Add(base_revision);

                    var igv_revision = new SqlBulkCopyColumnMapping("igv_revision",
                        "igv_revision");
                    sqlBlk.ColumnMappings.Add(igv_revision);

                    var tipo_gasto = new SqlBulkCopyColumnMapping("tipo_gasto",
                        "tipo_gasto");
                    sqlBlk.ColumnMappings.Add(tipo_gasto);

                    var recepcion = new SqlBulkCopyColumnMapping("recepcion",
                        "recepcion");
                    sqlBlk.ColumnMappings.Add(recepcion);

                    var comentario1 = new SqlBulkCopyColumnMapping("comentario1",
                        "comentario1");
                    sqlBlk.ColumnMappings.Add(comentario1);

                    var comentario2 = new SqlBulkCopyColumnMapping("comentario2",
                        "comentario2");
                    sqlBlk.ColumnMappings.Add(comentario2);

                    var vb = new SqlBulkCopyColumnMapping("vb",
                        "vb");
                    sqlBlk.ColumnMappings.Add(vb);

                    var compra_gravada_pais = new SqlBulkCopyColumnMapping("compra_gravada_pais",
                        "compra_gravada_pais");
                    sqlBlk.ColumnMappings.Add(compra_gravada_pais);

                    var compra_gravada_exterior = new SqlBulkCopyColumnMapping("compra_gravada_exterior",
                        "compra_gravada_exterior");
                    sqlBlk.ColumnMappings.Add(compra_gravada_exterior);

                    var compra_no_gravada = new SqlBulkCopyColumnMapping("compra_no_gravada",
                        "compra_no_gravada");
                    sqlBlk.ColumnMappings.Add(compra_no_gravada);

                    var igv_pais = new SqlBulkCopyColumnMapping("igv_pais",
                        "igv_pais");
                    sqlBlk.ColumnMappings.Add(igv_pais);

                    var exterior = new SqlBulkCopyColumnMapping("exterior",
                        "exterior");
                    sqlBlk.ColumnMappings.Add(exterior);

                    var otros_cargos = new SqlBulkCopyColumnMapping("otros_cargos",
                        "otros_cargos");
                    sqlBlk.ColumnMappings.Add(otros_cargos);

                    var total1 = new SqlBulkCopyColumnMapping("total1",
                        "total1");
                    sqlBlk.ColumnMappings.Add(total1);

                    var estado = new SqlBulkCopyColumnMapping("estado",
                        "estado");
                    sqlBlk.ColumnMappings.Add(estado);

                    sqlBlk.WriteToServer(dt);
                }

            }
        }
        public void GuardarDetalleImportDiario (List < LibroDiario > detalle2)
        {
            throw new NotImplementedException();
        }

        public void GuardarDetalleImportMayor (List < LibroMayor > detalle3)
        {
            throw new NotImplementedException();
        }

        public List<LibroDiario> ConsultaLibroDiarioPorPeriodo(DateTime periodo)
        {
            var mes = periodo.Month;
            var anio = periodo.Year;

            using (context)
            {
                return context.ConsultaLibroDiarioPorPeriodo(mes, anio).ToList();
            }
        }
    }
}
