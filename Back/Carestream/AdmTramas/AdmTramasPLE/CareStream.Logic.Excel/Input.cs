using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;
using CareStream.Utils;
using System.Data.SqlClient;
using CareStream.Data.Access;
using System.IO;

namespace CareStream.Logic.Excel
{
    public class Input
    {
        public void CargaLibroDiario(String rutaArchivo, String ruc, Char iOpe, String iMoneda, Char iRegistro, Int32 idArchivo)
        {
            String query = "select fecha,numcorre,codigounico,referencia,cuenta,centro,descasent,debe,haber from [sheet1$]";

            List<LibroDiario> lst = new List<LibroDiario>();

            using (OleDbConnection oleDbCn = new OleDbConnection(Connection.ExcelConnection(rutaArchivo)))
            {
                oleDbCn.Open();

                using (OleDbCommand oleDbCmd = new OleDbCommand(query, oleDbCn))
                {
                    using (OleDbDataReader oleDbdr = oleDbCmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (oleDbdr != null)
                        {
                            if (oleDbdr.HasRows)
                            {
                                Int32 i1 = oleDbdr.GetOrdinal("fecha");
                                Int32 i2 = oleDbdr.GetOrdinal("numcorre");
                                Int32 i3 = oleDbdr.GetOrdinal("codigounico");
                                Int32 i4 = oleDbdr.GetOrdinal("referencia");
                                Int32 i5 = oleDbdr.GetOrdinal("cuenta");
                                Int32 i6 = oleDbdr.GetOrdinal("centro");
                                Int32 i7 = oleDbdr.GetOrdinal("descasent");
                                Int32 i8 = oleDbdr.GetOrdinal("debe");
                                Int32 i9 = oleDbdr.GetOrdinal("haber");

                                LibroDiario obj = new LibroDiario();

                                Int32 n_linea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (!oleDbdr.IsDBNull(i1))
                                    {
                                        obj = new LibroDiario();

                                        obj.NumLinea = n_linea;

                                        if (oleDbdr.IsDBNull(i6))
                                        {
                                            obj.Centro = String.Empty;
                                        }
                                        else
                                        {
                                            obj.Centro = Convert.ToInt32(oleDbdr.GetDouble(i6)).ToString();
                                        }

                                        obj.CodigoUnico = Convert.ToInt64(oleDbdr.GetDouble(i3)).ToString();

                                        if (oleDbdr.IsDBNull(i5))
                                        {
                                            obj.Cuenta = String.Empty;
                                        }
                                        else
                                        {
                                            obj.Cuenta = Convert.ToInt64(oleDbdr.GetDouble(i5)).ToString();
                                        }

                                        if (oleDbdr.IsDBNull(i8))
                                        {
                                            obj.Debe = 0;
                                        }
                                        else
                                        {
                                            obj.Debe = Convert.ToDecimal(oleDbdr.GetDouble(i8));
                                        }

                                        if (oleDbdr.IsDBNull(i7))
                                        {
                                            obj.DescAsiento = String.Empty;
                                        }
                                        else
                                        {
                                            obj.DescAsiento = oleDbdr.GetString(i7);
                                        }

                                        obj.Fecha = oleDbdr.GetDateTime(i1);

                                        if (oleDbdr.IsDBNull(i9))
                                        {
                                            obj.Haber = 0;
                                        }
                                        else
                                        {
                                            obj.Haber = Convert.ToDecimal(oleDbdr.GetDouble(i9));
                                        }

                                        obj.NumCorrelativo = Convert.ToInt32(oleDbdr.GetDouble(i2));

                                        if (oleDbdr.IsDBNull(i4))
                                        {
                                            obj.Reference = String.Empty;
                                        }
                                        else
                                        {
                                            obj.Reference = oleDbdr.GetString(i4);
                                        }

                                        n_linea++;

                                        lst.Add(obj); 
                                    } 
                                }
                            }
                        }
                    }
                }
            }

            FileInfo fi = new FileInfo(rutaArchivo);

            //Guardamos la carga cabecera
            ArchivoLog objArchLog = new ArchivoLog();
            objArchLog.id_archivo = idArchivo;
            objArchLog.indicador_libro = iRegistro.ToString();
            objArchLog.indicador_moneda = iMoneda;
            objArchLog.indicador_ope = iOpe.ToString();
            objArchLog.nombre_carga = fi.Name;
            objArchLog.num_ruc = ruc;
            objArchLog.fecha_carga = DateTime.Now;
            objArchLog.cant_registros = lst.Count;
            objArchLog.tipo_ope = "I";

            DAArchivoLog objDA = new DAArchivoLog();

            Int32 id = objDA.Guardar(objArchLog);

            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("id_archivo_log");
            DataColumn dc2 = new DataColumn("num_linea");
            DataColumn dc3 = new DataColumn("fecha");
            DataColumn dc4 = new DataColumn("numcorre");
            DataColumn dc5 = new DataColumn("codigounico");
            DataColumn dc6 = new DataColumn("referencia");
            DataColumn dc7 = new DataColumn("cuenta");
            DataColumn dc8 = new DataColumn("centro");
            DataColumn dc9 = new DataColumn("descasent");
            DataColumn dc10 = new DataColumn("debe");
            DataColumn dc11 = new DataColumn("haber");

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

            DataRow dr = dt.NewRow();

            foreach (LibroDiario obj in lst)
            {
                dr = dt.NewRow();

                dr["id_archivo_log"] = id;
                dr["num_linea"] = obj.NumLinea;
                dr["fecha"] = obj.Fecha;
                dr["numcorre"] = obj.NumCorrelativo;
                dr["codigounico"] = obj.CodigoUnico;
                dr["referencia"] = obj.Reference;
                dr["cuenta"] = obj.Cuenta;
                dr["centro"] = obj.Centro;
                dr["descasent"] = obj.DescAsiento;
                dr["debe"] = obj.Debe;
                dr["haber"] = obj.Haber;
                
                dt.Rows.Add(dr);
            }

            using (SqlConnection sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (SqlBulkCopy sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.InputLibroDiario";

                    SqlBulkCopyColumnMapping num_linea = new SqlBulkCopyColumnMapping("num_linea",
                    "num_linea");
                    sqlBlk.ColumnMappings.Add(num_linea);

                    SqlBulkCopyColumnMapping id_archivo_log = new SqlBulkCopyColumnMapping("id_archivo_log",
                    "id_archivo_log");
                    sqlBlk.ColumnMappings.Add(id_archivo_log);

                    SqlBulkCopyColumnMapping fecha = new SqlBulkCopyColumnMapping("fecha",
                    "fecha");
                    sqlBlk.ColumnMappings.Add(fecha);

                    SqlBulkCopyColumnMapping numcorre = new SqlBulkCopyColumnMapping("numcorre",
                    "numcorre");
                    sqlBlk.ColumnMappings.Add(numcorre);

                    SqlBulkCopyColumnMapping codigounico = new SqlBulkCopyColumnMapping("codigounico",
                    "codigounico");
                    sqlBlk.ColumnMappings.Add(codigounico);

                    SqlBulkCopyColumnMapping referencia = new SqlBulkCopyColumnMapping("referencia",
                    "referencia");
                    sqlBlk.ColumnMappings.Add(referencia);

                    SqlBulkCopyColumnMapping cuenta = new SqlBulkCopyColumnMapping("cuenta",
                    "cuenta");
                    sqlBlk.ColumnMappings.Add(cuenta);

                    SqlBulkCopyColumnMapping centro = new SqlBulkCopyColumnMapping("centro",
                    "centro");
                    sqlBlk.ColumnMappings.Add(centro);

                    SqlBulkCopyColumnMapping descasent = new SqlBulkCopyColumnMapping("descasent",
                    "descasent");
                    sqlBlk.ColumnMappings.Add(descasent);

                    SqlBulkCopyColumnMapping debe = new SqlBulkCopyColumnMapping("debe",
                    "debe");
                    sqlBlk.ColumnMappings.Add(debe);

                    SqlBulkCopyColumnMapping haber = new SqlBulkCopyColumnMapping("haber",
                    "haber");
                    sqlBlk.ColumnMappings.Add(haber);

                    sqlBlk.WriteToServer(dt);
                }
            }
        }

        public void CargarRegistroVenta(String rutaArchivo, String ruc, Char iOpe, String iMoneda, Char iRegistro,Int32 idArchivo)
        {
            String query = "select Num,FECHA,TIPOCOMP,INTERNO,SERIE,NoCOMPROBANTE,TIPODOCUMENTO,RUC,CODIGO,APELLIDOSYNOMBRESORAZONSOCIAL," +
                    "ORIGINAL,MON,TIPODECAMBIO,VV,IGV,PV,FECHAMOD,TIPOMOD,SERIEMOD,NoMOD,VVMOD,IGVMOD,PVMOD,OPENOGRAV,estado FROM [sheet1$]";

            List<RegistroVenta> lst = new List<RegistroVenta>();
            
            using (OleDbConnection oleDbCn = new OleDbConnection(Connection.ExcelConnection(rutaArchivo)))
            {
                oleDbCn.Open();

                using (OleDbCommand oleDbCmd = new OleDbCommand(query, oleDbCn))
                {
                    using (OleDbDataReader oleDbdr = oleDbCmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (oleDbdr != null)
                        {
                            if (oleDbdr.HasRows)
                            {
                                Int32 i1 = oleDbdr.GetOrdinal("Num");
                                Int32 i2 = oleDbdr.GetOrdinal("FECHA");
                                Int32 i3 = oleDbdr.GetOrdinal("TIPOCOMP");
                                Int32 i4 = oleDbdr.GetOrdinal("INTERNO");
                                Int32 i5 = oleDbdr.GetOrdinal("SERIE");
                                Int32 i6 = oleDbdr.GetOrdinal("NoCOMPROBANTE");
                                Int32 i7 = oleDbdr.GetOrdinal("TIPODOCUMENTO");
                                Int32 i8 = oleDbdr.GetOrdinal("RUC");
                                Int32 i9 = oleDbdr.GetOrdinal("CODIGO");
                                Int32 i10 = oleDbdr.GetOrdinal("APELLIDOSYNOMBRESORAZONSOCIAL");
                                Int32 i11 = oleDbdr.GetOrdinal("ORIGINAL");
                                Int32 i12 = oleDbdr.GetOrdinal("MON");
                                Int32 i13 = oleDbdr.GetOrdinal("TIPODECAMBIO");
                                Int32 i14 = oleDbdr.GetOrdinal("VV");
                                Int32 i15 = oleDbdr.GetOrdinal("IGV");
                                Int32 i16 = oleDbdr.GetOrdinal("PV");
                                Int32 i17 = oleDbdr.GetOrdinal("FECHAMOD");
                                Int32 i18 = oleDbdr.GetOrdinal("TIPOMOD");
                                Int32 i19 = oleDbdr.GetOrdinal("SERIEMOD");
                                Int32 i20 = oleDbdr.GetOrdinal("NoMOD");
                                Int32 i21 = oleDbdr.GetOrdinal("VVMOD");
                                Int32 i22 = oleDbdr.GetOrdinal("IGVMOD");
                                Int32 i23 = oleDbdr.GetOrdinal("PVMOD");
                                Int32 i24 = oleDbdr.GetOrdinal("OPENOGRAV");
                                Int32 i25 = oleDbdr.GetOrdinal("estado");

                                RegistroVenta objReg = new RegistroVenta();

                                Int32 n_linea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (!oleDbdr.IsDBNull(i1))
                                    {
                                        objReg = null;

                                        objReg = new RegistroVenta();

                                        objReg.Num_Unico_Ope = oleDbdr.GetString(i1);

                                        objReg.FechaComprobante = Formato.ObtieneFecha(oleDbdr.GetString(i2), "DD.MM.AAAA");
                                        
                                        if (oleDbdr.IsDBNull(i3))
                                        {
                                            objReg.TipoComprobante = 0;
                                        }
                                        else
                                        {
                                            objReg.TipoComprobante = Convert.ToInt32(oleDbdr.GetDouble(i3));
                                        }

                                        if (oleDbdr.IsDBNull(i4))
                                        {
                                            objReg.InternoComprobante = -1;
                                        }
                                        else
                                        {
                                            objReg.InternoComprobante = Convert.ToInt64(oleDbdr.GetDouble(i4));
                                        }
                                       
                                        objReg.SerieComprobante = oleDbdr.GetString(i5);
                                        objReg.NumComprobante = Math.Truncate(oleDbdr.GetDouble(i6)).ToString();

                                        if (oleDbdr.IsDBNull(i7))
                                        {
                                            objReg.TipoDocumento = '0';
                                        }
                                        else
                                        {
                                            if (oleDbdr.GetFieldType(i7).ToString() == "System.String")
                                            {
                                                objReg.TipoDocumento = Convert.ToChar(oleDbdr.GetString(i7));
                                            }
                                            else
                                            {
                                                objReg.TipoDocumento = Convert.ToChar(oleDbdr.GetDouble(i7).ToString());
                                            }
                                            
                                        }


                                        if (oleDbdr.IsDBNull(i8))
                                        {
                                            objReg.NumDocumento = String.Empty;
                                        }
                                        else
                                        {
                                            if (oleDbdr.GetFieldType(i8).ToString() == "System.String")
                                            {
                                                objReg.NumDocumento = oleDbdr.GetString(i8);
                                            }
                                            else
                                            {
                                                objReg.NumDocumento = Math.Truncate(oleDbdr.GetDouble(i8)).ToString();
                                            }
                                        }

                                        if (oleDbdr.IsDBNull(i9))
                                        {
                                            objReg.CodigoDoc = String.Empty;
                                        }
                                        else
                                        {
                                            if (oleDbdr.GetFieldType(i9).ToString() == "System.String")
                                            {
                                                objReg.CodigoDoc = oleDbdr.GetString(i9);
                                            }
                                            else
                                            {
                                                objReg.CodigoDoc = Math.Truncate(oleDbdr.GetDouble(i9)).ToString();
                                            }
                                        }

                                        objReg.NombRazSocial = oleDbdr.GetString(i10);

                                        if (oleDbdr.IsDBNull(i11))
                                        {
                                            objReg.ValorVentaOrig = 0;
                                        }
                                        else
                                        {
                                            objReg.ValorVentaOrig = Convert.ToDecimal(oleDbdr.GetDouble(i11));
                                        }

                                        if (oleDbdr.IsDBNull(i12))
                                        {
                                            objReg.MonedaValorVenta = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.MonedaValorVenta = oleDbdr.GetString(i12);
                                        }

                                        if (oleDbdr.IsDBNull(i13))
                                        {
                                            objReg.TipoCambio = 0;
                                        }
                                        else
                                        {
                                            objReg.TipoCambio = Convert.ToDecimal(oleDbdr.GetDouble(i13));
                                        }

                                        if (oleDbdr.IsDBNull(i14))
                                        {
                                            objReg.VV = 0;
                                        }
                                        else
                                        {
                                            objReg.VV = Convert.ToDecimal(oleDbdr.GetDouble(i14));
                                        }

                                        if (oleDbdr.IsDBNull(i15))
                                        {
                                            objReg.IGV = 0;
                                        }
                                        else
                                        {
                                            objReg.IGV = Convert.ToDecimal(oleDbdr.GetDouble(i15));
                                        }

                                        if (oleDbdr.IsDBNull(i16))
                                        {
                                            objReg.PV = 0;
                                        }
                                        else
                                        {
                                            objReg.PV = Convert.ToDecimal(oleDbdr.GetDouble(i16));
                                        }

                                        if (oleDbdr.IsDBNull(i24))
                                        {
                                            objReg.Ope_No_Gravada = 0;
                                        }
                                        else
                                        {
                                            objReg.Ope_No_Gravada = Convert.ToDecimal(oleDbdr.GetDouble(i24));
                                        }
                                        
                                        if (oleDbdr.IsDBNull(i17))
                                        {
                                            objReg.FechaMod = DateTime.Parse("1900-01-01");
                                        }
                                        else
                                        {
                                            objReg.FechaMod = Formato.ObtieneFecha(oleDbdr.GetString(i17), "DD.MM.AAAA");
                                        }

                                        if (oleDbdr.IsDBNull(i18))
                                        {
                                            objReg.TipoMod = String.Empty;
                                        }
                                        else
                                        {
                                            if (oleDbdr.GetFieldType(i18).ToString() == "System.String")
                                            {
                                                objReg.TipoMod = oleDbdr.GetString(i18);
                                            }
                                            else
                                            {
                                                objReg.TipoMod = oleDbdr.GetDouble(i18).ToString();
                                            }
                                        }

                                        if (oleDbdr.IsDBNull(i19))
                                        {
                                            objReg.SerieMod = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.SerieMod = oleDbdr.GetString(i19);
                                        }

                                        if (oleDbdr.IsDBNull(i20))
                                        {
                                            objReg.NumMod = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.NumMod = oleDbdr.GetString(i20);
                                        }

                                        if (oleDbdr.IsDBNull(i21))
                                        {
                                            objReg.VVMod = 0;
                                        }
                                        else
                                        {
                                            objReg.VVMod = Convert.ToDecimal(oleDbdr.GetDouble(i21));
                                        }

                                        if (oleDbdr.IsDBNull(i22))
                                        {
                                            objReg.IGVMod = 0;
                                        }
                                        else
                                        {
                                            objReg.IGVMod = Convert.ToDecimal(oleDbdr.GetDouble(i22));
                                        }

                                        if (oleDbdr.IsDBNull(i23))
                                        {
                                            objReg.PVMod = 0;
                                        }
                                        else
                                        {
                                            objReg.PVMod = Convert.ToDecimal(oleDbdr.GetDouble(i23));
                                        }

                                        if (oleDbdr.IsDBNull(i25))
                                        {
                                            objReg.Estado = '0';
                                        }
                                        else
                                        {
                                            objReg.Estado = Convert.ToChar(oleDbdr.GetString(i25));
                                        }

                                        objReg.Num_Linea = n_linea;

                                        n_linea++;

                                        lst.Add(objReg);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            FileInfo fi = new FileInfo(rutaArchivo);

            //Guardamos la carga cabecera
            ArchivoLog objArchLog = new ArchivoLog();
            objArchLog.id_archivo = idArchivo;
            objArchLog.indicador_libro = iRegistro.ToString();
            objArchLog.indicador_moneda = iMoneda;
            objArchLog.indicador_ope = iOpe.ToString();
            objArchLog.nombre_carga = fi.Name;
            objArchLog.num_ruc = ruc;
            objArchLog.fecha_carga = DateTime.Now;
            objArchLog.cant_registros = lst.Count;
            objArchLog.tipo_ope = "I";
            

            DAArchivoLog objDA = new DAArchivoLog();

            Int32 id = objDA.Guardar(objArchLog);

            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("id_archivo_log");
            DataColumn dc2 = new DataColumn("id_linea");
            DataColumn dc3 = new DataColumn("num_correlativo");
            DataColumn dc4 = new DataColumn("fecha_comprobante");
            DataColumn dc5 = new DataColumn("tipo_comprobante");
            DataColumn dc6 = new DataColumn("interno_comprobante");
            DataColumn dc7 = new DataColumn("serie_comprobante");
            DataColumn dc8 = new DataColumn("num_comprobante");
            DataColumn dc9 = new DataColumn("tipo_documento");
            DataColumn dc10 = new DataColumn("num_documento");
            DataColumn dc11 = new DataColumn("codigo_documento");
            DataColumn dc12 = new DataColumn("nombre_razon_social");
            DataColumn dc13 = new DataColumn("valor_venta_orig");
            DataColumn dc14 = new DataColumn("moneda");
            DataColumn dc15 = new DataColumn("tipo_cambio");
            DataColumn dc16 = new DataColumn("vv");
            DataColumn dc17 = new DataColumn("igv");
            DataColumn dc18 = new DataColumn("pv");
            DataColumn dc19 = new DataColumn("fechamod");
            DataColumn dc20 = new DataColumn("tipomod");
            DataColumn dc21 = new DataColumn("seriemod");
            DataColumn dc22 = new DataColumn("nomod");
            DataColumn dc23 = new DataColumn("vvmod");
            DataColumn dc24 = new DataColumn("igvmod");
            DataColumn dc25 = new DataColumn("pvmod");
            DataColumn dc26 = new DataColumn("ope_no_gravada");
            DataColumn dc27 = new DataColumn("num_unico_ope");
            DataColumn dc28 = new DataColumn("estado");

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

            DataRow dr = dt.NewRow();

            foreach(RegistroVenta obj in lst)
            {
                dr = dt.NewRow();

                dr["id_archivo_log"] = id;
                dr["id_linea"] = obj.Num_Linea;
                dr["num_correlativo"] = obj.Num_Linea;
                dr["fecha_comprobante"] = obj.FechaComprobante;
                dr["tipo_comprobante"] = obj.TipoComprobante;
                dr["interno_comprobante"] = obj.InternoComprobante;
                dr["serie_comprobante"] = obj.SerieComprobante;
                dr["num_comprobante"] = obj.NumComprobante;
                dr["tipo_documento"] = obj.TipoDocumento;
                dr["num_documento"] = obj.NumDocumento;
                dr["codigo_documento"] = obj.CodigoDoc;
                dr["nombre_razon_social"] = obj.NombRazSocial;
                dr["valor_venta_orig"] = obj.ValorVentaOrig;
                dr["moneda"] = obj.MonedaValorVenta;
                dr["tipo_cambio"] = obj.TipoCambio;
                dr["vv"] = obj.VV;
                dr["igv"] = obj.IGV;
                dr["pv"] = obj.PV;
                dr["fechamod"] = obj.FechaMod;
                dr["tipomod"] = obj.TipoMod;
                dr["seriemod"] = obj.SerieMod;
                dr["nomod"] = obj.NumMod;
                dr["vvmod"] = obj.VVMod;
                dr["igvmod"] = obj.IGVMod;
                dr["pvmod"] = obj.PVMod;
                dr["ope_no_gravada"] = obj.Ope_No_Gravada;
                dr["num_unico_ope"] = obj.Num_Unico_Ope;
                dr["estado"] = obj.Estado;

                dt.Rows.Add(dr);
            }
                
            using (SqlConnection sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (SqlBulkCopy sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.InputRegistroVenta";

                    SqlBulkCopyColumnMapping id_archivo_log = new SqlBulkCopyColumnMapping("id_archivo_log",
                    "id_archivo_log");
                    sqlBlk.ColumnMappings.Add(id_archivo_log);

                    SqlBulkCopyColumnMapping id_linea = new SqlBulkCopyColumnMapping("id_linea",
                    "id_linea");
                    sqlBlk.ColumnMappings.Add(id_linea);

                    SqlBulkCopyColumnMapping num_correlativo = new SqlBulkCopyColumnMapping("num_correlativo",
                    "num_correlativo");
                    sqlBlk.ColumnMappings.Add(num_correlativo);

                    SqlBulkCopyColumnMapping fecha_comprobante = new SqlBulkCopyColumnMapping("fecha_comprobante",
                    "fecha_comprobante");
                    sqlBlk.ColumnMappings.Add(fecha_comprobante);

                    SqlBulkCopyColumnMapping tipo_comprobante = new SqlBulkCopyColumnMapping("tipo_comprobante",
                    "tipo_comprobante");
                    sqlBlk.ColumnMappings.Add(tipo_comprobante);

                    SqlBulkCopyColumnMapping interno_comprobante = new SqlBulkCopyColumnMapping("interno_comprobante",
                    "interno_comprobante");
                    sqlBlk.ColumnMappings.Add(interno_comprobante);

                    SqlBulkCopyColumnMapping serie_comprobante = new SqlBulkCopyColumnMapping("serie_comprobante",
                    "serie_comprobante");
                    sqlBlk.ColumnMappings.Add(serie_comprobante);

                    SqlBulkCopyColumnMapping num_comprobante = new SqlBulkCopyColumnMapping("num_comprobante",
                    "num_comprobante");
                    sqlBlk.ColumnMappings.Add(num_comprobante);

                    SqlBulkCopyColumnMapping tipo_documento = new SqlBulkCopyColumnMapping("tipo_documento",
                    "tipo_documento");
                    sqlBlk.ColumnMappings.Add(tipo_documento);

                    SqlBulkCopyColumnMapping num_documento = new SqlBulkCopyColumnMapping("num_documento",
                    "num_documento");
                    sqlBlk.ColumnMappings.Add(num_documento);

                    SqlBulkCopyColumnMapping codigo_documento = new SqlBulkCopyColumnMapping("codigo_documento",
                    "codigo_documento");
                    sqlBlk.ColumnMappings.Add(codigo_documento);

                    SqlBulkCopyColumnMapping nombre_razon_social = new SqlBulkCopyColumnMapping("nombre_razon_social",
                    "nombre_razon_social");
                    sqlBlk.ColumnMappings.Add(nombre_razon_social);

                    SqlBulkCopyColumnMapping valor_venta_orig = new SqlBulkCopyColumnMapping("valor_venta_orig",
                    "valor_venta_orig");
                    sqlBlk.ColumnMappings.Add(valor_venta_orig);

                    SqlBulkCopyColumnMapping moneda = new SqlBulkCopyColumnMapping("moneda",
                    "moneda");
                    sqlBlk.ColumnMappings.Add(moneda);

                    SqlBulkCopyColumnMapping tipo_cambio = new SqlBulkCopyColumnMapping("tipo_cambio",
                    "tipo_cambio");
                    sqlBlk.ColumnMappings.Add(tipo_cambio);

                    SqlBulkCopyColumnMapping vv = new SqlBulkCopyColumnMapping("vv",
                    "vv");
                    sqlBlk.ColumnMappings.Add(vv);

                    SqlBulkCopyColumnMapping igv = new SqlBulkCopyColumnMapping("igv",
                    "igv");
                    sqlBlk.ColumnMappings.Add(igv);

                    SqlBulkCopyColumnMapping pv = new SqlBulkCopyColumnMapping("pv",
                    "pv");
                    sqlBlk.ColumnMappings.Add(pv);

                    SqlBulkCopyColumnMapping fechamod = new SqlBulkCopyColumnMapping("fechamod",
                    "fechamod");
                    sqlBlk.ColumnMappings.Add(fechamod);

                    SqlBulkCopyColumnMapping tipomod = new SqlBulkCopyColumnMapping("tipomod",
                    "tipomod");
                    sqlBlk.ColumnMappings.Add(tipomod);

                    SqlBulkCopyColumnMapping seriemod = new SqlBulkCopyColumnMapping("seriemod",
                    "seriemod");
                    sqlBlk.ColumnMappings.Add(seriemod);

                    SqlBulkCopyColumnMapping nomod = new SqlBulkCopyColumnMapping("nomod",
                    "nomod");
                    sqlBlk.ColumnMappings.Add(nomod);

                    SqlBulkCopyColumnMapping vvmod = new SqlBulkCopyColumnMapping("vvmod",
                    "vvmod");
                    sqlBlk.ColumnMappings.Add(vvmod);

                    SqlBulkCopyColumnMapping igvmod = new SqlBulkCopyColumnMapping("igvmod",
                    "igvmod");
                    sqlBlk.ColumnMappings.Add(igvmod);

                    SqlBulkCopyColumnMapping pvmod = new SqlBulkCopyColumnMapping("pvmod",
                    "pvmod");
                    sqlBlk.ColumnMappings.Add(pvmod);

                    SqlBulkCopyColumnMapping ope_no_gravada = new SqlBulkCopyColumnMapping("ope_no_gravada",
                    "ope_no_gravada");
                    sqlBlk.ColumnMappings.Add(ope_no_gravada);

                    SqlBulkCopyColumnMapping num_unico_ope = new SqlBulkCopyColumnMapping("num_unico_ope",
                    "num_unico_ope");
                    sqlBlk.ColumnMappings.Add(num_unico_ope);

                    SqlBulkCopyColumnMapping estado = new SqlBulkCopyColumnMapping("estado",
                    "estado");
                    sqlBlk.ColumnMappings.Add(estado);

                    sqlBlk.WriteToServer(dt);
                }
            }
        }

        public void CargarRegistroCompra(String rutaArchivo, String ruc, Char iOpe, String iMoneda, Char iRegistro, Int32 idArchivo)
        {
            String query = "SELECT NOOPERAC,FEMISION,FVCTO,TIPOCOMP,NUMSERIECOMP,ANIOEMISCOMP,NUMCOMP,TIPODOC,NUMDOC,APELLNOMBRAZ,"
                + "BASEIMPGRAV,IGVGRAV,BASEIMPMIX,IGVMIX,BASEIMPNOGRAV,IGVNOGRAV,ADQNOGRAV,ISC,OTTRIB,TOTAL,COMPNODOMC,NUMCONST,FECHEMICONST,"
                + "TIPOCAMB,FECHAORIG,TIPODOCORIG,SERIEDOCORIG,NUMDOCORIG,PAGO,FECHPAGO,DETRACCION,TASADETRACCION,IMPORTEDETRACCION,"
                + "MOTIVORETENCION,RETENCION,IMPORTERETEN,REVISIONTASA,REVISIONTIPOCAMBIO,REVISIONVERIF,BASEREVI,IGVREVI,TIPOGASTO,"
                + "RECEPCION,COMENTARIO1,COMENTARIO2,VB,COMPAGRAVPAIS,COMPNOAGRAVEXT,COMPNOGRAV,IGVPAIS,EXTERIOR,OTROSCARGOS,TOTAL1, "
                + " estado FROM [sheet1$]";

            List<RegistroCompra> lst = new List<RegistroCompra>();

            using (OleDbConnection oleDbCn = new OleDbConnection(Connection.ExcelConnection(rutaArchivo)))
            {
                oleDbCn.Open();

                using (OleDbCommand oleDbCmd = new OleDbCommand(query, oleDbCn))
                {
                    using (OleDbDataReader oleDbdr = oleDbCmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (oleDbdr != null)
                        {
                            if (oleDbdr.HasRows)
                            {
                                Int32 i1 = oleDbdr.GetOrdinal("NOOPERAC");
                                Int32 i2 = oleDbdr.GetOrdinal("FEMISION");
                                Int32 i3 = oleDbdr.GetOrdinal("FVCTO");
                                Int32 i4 = oleDbdr.GetOrdinal("TIPOCOMP");
                                Int32 i5 = oleDbdr.GetOrdinal("NUMSERIECOMP");
                                Int32 i6 = oleDbdr.GetOrdinal("ANIOEMISCOMP");
                                Int32 i7 = oleDbdr.GetOrdinal("NUMCOMP");
                                Int32 i8 = oleDbdr.GetOrdinal("TIPODOC");
                                Int32 i9 = oleDbdr.GetOrdinal("NUMDOC");
                                Int32 i10 = oleDbdr.GetOrdinal("APELLNOMBRAZ");
                                Int32 i11 = oleDbdr.GetOrdinal("BASEIMPGRAV");
                                Int32 i12 = oleDbdr.GetOrdinal("IGVGRAV");
                                Int32 i13 = oleDbdr.GetOrdinal("BASEIMPMIX");
                                Int32 i14 = oleDbdr.GetOrdinal("IGVMIX");
                                Int32 i15 = oleDbdr.GetOrdinal("BASEIMPNOGRAV");
                                Int32 i16 = oleDbdr.GetOrdinal("IGVNOGRAV");
                                Int32 i17 = oleDbdr.GetOrdinal("ADQNOGRAV");
                                Int32 i18 = oleDbdr.GetOrdinal("ISC");
                                Int32 i19 = oleDbdr.GetOrdinal("OTTRIB");
                                Int32 i20 = oleDbdr.GetOrdinal("TOTAL");
                                Int32 i21 = oleDbdr.GetOrdinal("COMPNODOMC");
                                Int32 i22 = oleDbdr.GetOrdinal("NUMCONST");
                                Int32 i23 = oleDbdr.GetOrdinal("FECHEMICONST");
                                Int32 i24 = oleDbdr.GetOrdinal("TIPOCAMB");
                                Int32 i25 = oleDbdr.GetOrdinal("FECHAORIG");
                                Int32 i26 = oleDbdr.GetOrdinal("TIPODOCORIG");
                                Int32 i27 = oleDbdr.GetOrdinal("SERIEDOCORIG");
                                Int32 i28 = oleDbdr.GetOrdinal("NUMDOCORIG");
                                Int32 i29 = oleDbdr.GetOrdinal("PAGO");
                                Int32 i30 = oleDbdr.GetOrdinal("FECHPAGO");
                                Int32 i31 = oleDbdr.GetOrdinal("DETRACCION");
                                Int32 i32 = oleDbdr.GetOrdinal("TASADETRACCION");
                                Int32 i33 = oleDbdr.GetOrdinal("IMPORTEDETRACCION");
                                Int32 i34 = oleDbdr.GetOrdinal("RETENCION");
                                Int32 i35 = oleDbdr.GetOrdinal("IMPORTERETEN");  
                                Int32 i36 = oleDbdr.GetOrdinal("MOTIVORETENCION");
                                Int32 i37 = oleDbdr.GetOrdinal("REVISIONTASA");
                                Int32 i38 = oleDbdr.GetOrdinal("REVISIONTIPOCAMBIO");
                                Int32 i39 = oleDbdr.GetOrdinal("REVISIONVERIF");
                                Int32 i40 = oleDbdr.GetOrdinal("BASEREVI");
                                Int32 i41 = oleDbdr.GetOrdinal("IGVREVI");
                                Int32 i42 = oleDbdr.GetOrdinal("TIPOGASTO");
                                Int32 i43 = oleDbdr.GetOrdinal("RECEPCION");
                                Int32 i44 = oleDbdr.GetOrdinal("COMENTARIO1");
                                Int32 i45 = oleDbdr.GetOrdinal("COMENTARIO2");
                                Int32 i46 = oleDbdr.GetOrdinal("VB");
                                Int32 i47 = oleDbdr.GetOrdinal("COMPAGRAVPAIS");
                                Int32 i48 = oleDbdr.GetOrdinal("COMPNOAGRAVEXT");
                                Int32 i49 = oleDbdr.GetOrdinal("COMPNOGRAV");
                                Int32 i50 = oleDbdr.GetOrdinal("IGVPAIS");
                                Int32 i51 = oleDbdr.GetOrdinal("EXTERIOR");
                                Int32 i52 = oleDbdr.GetOrdinal("OTROSCARGOS");
                                Int32 i53 = oleDbdr.GetOrdinal("TOTAL1");
                                Int32 i54 = oleDbdr.GetOrdinal("estado");


                                RegistroCompra objReg = new RegistroCompra();

                                Int32 n_linea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (!oleDbdr.IsDBNull(i1))
                                    {
                                        objReg = new RegistroCompra();

                                        objReg.NumFila = n_linea;
                                        objReg.NoOpeRac = oleDbdr.GetString(i1);
                                        objReg.FechaEmision = Formato.ObtieneFecha(oleDbdr.GetString(i2), "DD.MM.AAAA");

                                        if (oleDbdr.IsDBNull(i3))
                                        {
                                            objReg.FechaVencimiento = DateTime.Parse("1900-01-01");
                                        }
                                        else
                                        {
                                            objReg.FechaVencimiento = Formato.ObtieneFecha(oleDbdr.GetString(i3), "DD.MM.AAAA");
                                        }

                                        if (oleDbdr.IsDBNull(i4))
                                        {
                                            objReg.TipoComprobante = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.TipoComprobante = oleDbdr.GetString(i4);
                                        }

                                        if (oleDbdr.IsDBNull(i5))
                                        {
                                            objReg.NoSerieComprobante = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.NoSerieComprobante = oleDbdr.GetString(i5);
                                        }
                                        
                                        if (oleDbdr.IsDBNull(i6))
                                        {
                                            objReg.AnioEmisionComprobante = 0;
                                        }
                                        else
                                        {
                                            objReg.AnioEmisionComprobante = Int32.Parse(oleDbdr.GetString(i6));
                                        }

                                        objReg.NumeroComprobante = oleDbdr.GetString(i7);

                                        if (oleDbdr.IsDBNull(i8))
                                        {
                                            objReg.TipoDocumento = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.TipoDocumento = oleDbdr.GetString(i8);
                                        }

                                        if (oleDbdr.IsDBNull(i9))
                                        {
                                            objReg.NumDocumento = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.NumDocumento = Convert.ToInt64(oleDbdr.GetDouble(i9)).ToString();
                                        }
                                        
                                        objReg.ApellNombRazSoc = oleDbdr.GetString(i10);

                                        if (oleDbdr.IsDBNull(i11))
                                        {
                                            objReg.BaseImpGravada = 0;
                                        }
                                        else
                                        {
                                            objReg.BaseImpGravada = Convert.ToDecimal(oleDbdr.GetDouble(i11));
                                        }

                                        objReg.IGVGravado = Convert.ToDecimal(oleDbdr.GetDouble(i12));

                                        if (oleDbdr.IsDBNull(i13))
                                        {
                                            objReg.BaseImpMixta = 0;
                                        }
                                        else
                                        {
                                            objReg.BaseImpMixta = Convert.ToDecimal(oleDbdr.GetDouble(i13));
                                        }

                                        if (oleDbdr.IsDBNull(i14))
                                        {
                                            objReg.IGVMixto = 0;
                                        }
                                        else
                                        {
                                            objReg.IGVMixto = Convert.ToDecimal(oleDbdr.GetDouble(i14));
                                        }

                                        if (oleDbdr.IsDBNull(i15))
                                        {
                                            objReg.BaseImpNoGravada = 0;
                                        }
                                        else
                                        {
                                            objReg.BaseImpNoGravada = Convert.ToDecimal(oleDbdr.GetDouble(i15));
                                        }

                                        if (oleDbdr.IsDBNull(i16))
                                        {
                                            objReg.IGVNoGravado = 0;
                                        }
                                        else
                                        {
                                            objReg.IGVNoGravado = Convert.ToDecimal(oleDbdr.GetDouble(i16));
                                        }

                                        if (oleDbdr.IsDBNull(i17))
                                        {
                                            objReg.AdquisicNoGravada = 0;
                                        }
                                        else
                                        {
                                            objReg.AdquisicNoGravada = Convert.ToDecimal(oleDbdr.GetDouble(i17));
                                        }

                                        if (oleDbdr.IsDBNull(i18))
                                        {
                                            objReg.ISC = 0;
                                        }
                                        else
                                        {
                                            objReg.ISC = Convert.ToDecimal(oleDbdr.GetDouble(i18));
                                        }

                                        if (oleDbdr.IsDBNull(i19))
                                        {
                                            objReg.OtrosTributos = 0;
                                        }
                                        else
                                        {
                                            objReg.OtrosTributos = Convert.ToDecimal(oleDbdr.GetDouble(i19));
                                        }

                                        objReg.Total = Convert.ToDecimal(oleDbdr.GetDouble(i20));

                                        if (oleDbdr.IsDBNull(i21))
                                        {
                                            objReg.CompNoDomic = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.CompNoDomic = oleDbdr.GetString(i21);
                                        }

                                        if (oleDbdr.IsDBNull(i22))
                                        {
                                            objReg.NumConstancia = String.Empty;
                                        }
                                        else
                                        {
                                            if (oleDbdr.GetFieldType(i22).ToString() == "System.Double")
                                            {
                                                objReg.NumConstancia = Convert.ToInt64(oleDbdr.GetDouble(i22)).ToString();
                                            }
                                            else
                                            {
                                                objReg.NumConstancia = oleDbdr.GetString(i22); 
                                            }
                                        }

                                        if (oleDbdr.IsDBNull(i23))
                                        {
                                            objReg.FechaEmisionConstancia = DateTime.Parse("1900-01-01");
                                        }
                                        else
                                        {
                                            objReg.FechaEmisionConstancia = Formato.ObtieneFecha(oleDbdr.GetString(i23), "DD.MM.AAAA");
                                        }

                                        if (oleDbdr.IsDBNull(i24))
                                        {
                                            objReg.TipoCambio = 0;
                                        }
                                        else
                                        {
                                            objReg.TipoCambio = Convert.ToDecimal(oleDbdr.GetDouble(i24));
                                        }

                                        if (oleDbdr.IsDBNull(i25))
                                        {
                                            objReg.FechaOriginal = DateTime.Parse("1900-01-01");
                                        }
                                        else
                                        {
                                            objReg.FechaOriginal = Formato.ObtieneFecha(oleDbdr.GetString(i25), "DD.MM.AAAA");
                                        }

                                        if (oleDbdr.IsDBNull(i26))
                                        {
                                            objReg.TipoDocumentoOriginal = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.TipoDocumentoOriginal = oleDbdr.GetString(i26);
                                        }

                                        if (oleDbdr.IsDBNull(i27))
                                        {
                                            objReg.NroSerieOriginal = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.NroSerieOriginal = oleDbdr.GetString(i27);
                                        }

                                        if (oleDbdr.IsDBNull(i28))
                                        {
                                            objReg.NroDocumentoOriginal = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.NroDocumentoOriginal = oleDbdr.GetString(i28);
                                        }

                                        if (oleDbdr.IsDBNull(i29))
                                        {
                                            objReg.Pago = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.Pago = oleDbdr.GetString(i29);
                                        }

                                        if (oleDbdr.IsDBNull(i30))
                                        {
                                            objReg.FechaPago = DateTime.Parse("1900-01-01");
                                        }
                                        else
                                        {
                                            objReg.FechaPago = Formato.ObtieneFecha(oleDbdr.GetString(i30), "DD.MM.AAAA");
                                        }

                                        if (oleDbdr.IsDBNull(i31))
                                        {
                                            objReg.Detraccion = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.Detraccion = oleDbdr.GetString(i31);
                                        }

                                        if (oleDbdr.IsDBNull(i32))
                                        {
                                            objReg.TasaDetraccion = 0;
                                        }
                                        else
                                        {
                                            objReg.TasaDetraccion = Convert.ToDecimal(oleDbdr.GetDouble(i32));
                                        }

                                        if (oleDbdr.IsDBNull(i33))
                                        {
                                            objReg.ImporteDetraccion = 0;
                                        }
                                        else
                                        {
                                            objReg.ImporteDetraccion = Convert.ToDecimal(oleDbdr.GetDouble(i33));
                                        }

                                        if (oleDbdr.IsDBNull(i34))
                                        {
                                            objReg.Retencion = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.Retencion = oleDbdr.GetString(i34);
                                        }

                                        if (oleDbdr.IsDBNull(i35))
                                        {
                                            objReg.ImporteRetencion = 0;
                                        }
                                        else
                                        {
                                            objReg.ImporteRetencion = Convert.ToDecimal(oleDbdr.GetDouble(i35));
                                        }

                                        if (oleDbdr.IsDBNull(i36))
                                        {
                                            objReg.MotivoRetencion = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.MotivoRetencion = oleDbdr.GetString(i36);
                                        }

                                        if (oleDbdr.IsDBNull(i37))
                                        {
                                            objReg.RevisionTasa = 0;
                                        }
                                        else
                                        {
                                            objReg.RevisionTasa = Convert.ToDecimal(oleDbdr.GetDouble(i37));
                                        }

                                        if (oleDbdr.IsDBNull(i38))
                                        {
                                            objReg.RevisionTipoCambio = 0;
                                        }
                                        else
                                        {
                                            objReg.RevisionTipoCambio = Convert.ToDecimal(oleDbdr.GetDouble(i38));
                                        }
                                            
                                        if (oleDbdr.IsDBNull(i39))
                                        {
                                            objReg.RevisionVerificacion = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.RevisionVerificacion = oleDbdr.GetString(i39);
                                        }

                                        if (oleDbdr.IsDBNull(i40))
                                        {
                                            objReg.BaseRevision = 0;
                                        }
                                        else
                                        {
                                            objReg.BaseRevision = Convert.ToDecimal(oleDbdr.GetDouble(i40));
                                        }

                                        if (oleDbdr.IsDBNull(i41))
                                        {
                                            objReg.IGVRevision = 0;
                                        }
                                        else
                                        {
                                            objReg.IGVRevision = Convert.ToDecimal(oleDbdr.GetDouble(i41));
                                        }

                                        if (oleDbdr.IsDBNull(i42))
                                        {
                                            objReg.TipoGasto = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.TipoGasto = oleDbdr.GetString(i42);
                                        }

                                        if (oleDbdr.IsDBNull(i43))
                                        {
                                            objReg.Recepcion = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.Recepcion = oleDbdr.GetString(i43);
                                        }

                                        if (oleDbdr.IsDBNull(i44))
                                        {
                                            objReg.Comentario1 = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.Comentario1 = oleDbdr.GetString(i44);
                                        }

                                        if (oleDbdr.IsDBNull(i45))
                                        {
                                            objReg.Comentario2 = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.Comentario2 = oleDbdr.GetString(i45);
                                        }

                                        if (oleDbdr.IsDBNull(i46))
                                        {
                                            objReg.VB = String.Empty;
                                        }
                                        else
                                        {
                                            objReg.VB = oleDbdr.GetString(i46);
                                        }

                                        if (oleDbdr.IsDBNull(i47))
                                        {
                                            objReg.CompraGravadaPais = 0;
                                        }
                                        else
                                        {
                                            objReg.CompraGravadaPais = Convert.ToDecimal(oleDbdr.GetDouble(i47));
                                        }

                                        if (oleDbdr.IsDBNull(i48))
                                        {
                                            objReg.CompraGravadaExterior = 0;
                                        }
                                        else
                                        {
                                            objReg.CompraGravadaExterior = Convert.ToDecimal(oleDbdr.GetDouble(i48));
                                        }

                                        if (oleDbdr.IsDBNull(i49))
                                        {
                                            objReg.CompraNoGravada = 0;
                                        }
                                        else
                                        {
                                            objReg.CompraNoGravada = Convert.ToDecimal(oleDbdr.GetDouble(i49));
                                        }

                                        if (oleDbdr.IsDBNull(i50))
                                        {
                                            objReg.IGVPais = 0;
                                        }
                                        else
                                        {
                                            objReg.IGVPais = Convert.ToDecimal(oleDbdr.GetDouble(i50));
                                        }

                                        if (oleDbdr.IsDBNull(i51))
                                        {
                                            objReg.Exterior = 0;
                                        }
                                        else
                                        {
                                            objReg.Exterior = Convert.ToDecimal(oleDbdr.GetDouble(i51));
                                        }

                                        if (oleDbdr.IsDBNull(i52))
                                        {
                                            objReg.OtrosCargos = 0;
                                        }
                                        else
                                        {
                                            objReg.OtrosCargos = Convert.ToDecimal(oleDbdr.GetDouble(i52));
                                        }

                                        if (oleDbdr.IsDBNull(i53))
                                        {
                                            objReg.Total1 = 0;
                                        }
                                        else
                                        {
                                            objReg.Total1 = Convert.ToDecimal(oleDbdr.GetDouble(i53));
                                        }

                                        if (oleDbdr.IsDBNull(i54))
                                        {
                                            objReg.Estado = '0';
                                        }
                                        else
                                        {
                                            objReg.Estado = Convert.ToChar(oleDbdr.GetString(i54));
                                        }

                                        n_linea++;

                                        lst.Add(objReg);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            FileInfo fi = new FileInfo(rutaArchivo);

            //Guardamos la carga cabecera
            ArchivoLog objArchLog = new ArchivoLog();
            objArchLog.id_archivo = idArchivo;
            objArchLog.indicador_libro = iRegistro.ToString();
            objArchLog.indicador_moneda = iMoneda;
            objArchLog.indicador_ope = iOpe.ToString();
            objArchLog.nombre_carga = fi.Name;
            objArchLog.num_ruc = ruc;
            objArchLog.fecha_carga = DateTime.Now;
            objArchLog.cant_registros = lst.Count;
            objArchLog.tipo_ope = "I";

            DAArchivoLog objDA = new DAArchivoLog();

            Int32 id = objDA.Guardar(objArchLog);

            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("id_archivo_log");
            DataColumn dc2 = new DataColumn("id_linea");
            DataColumn dc3 = new DataColumn("no_ope_rac");
            DataColumn dc4 = new DataColumn("fecha_emision");
            DataColumn dc5 = new DataColumn("fecha_vencimiento");
            DataColumn dc6 = new DataColumn("tipo_comprobante");
            DataColumn dc7 = new DataColumn("nro_serie_comprobante");
            DataColumn dc8 = new DataColumn("anio_emision_comprobante");
            DataColumn dc9 = new DataColumn("numero_comprobante");
            DataColumn dc10 = new DataColumn("tipo_documento");
            DataColumn dc11 = new DataColumn("numero_documento");
            DataColumn dc12 = new DataColumn("apell_nomb_raz_soc");
            DataColumn dc13 = new DataColumn("base_imponible_grav");
            DataColumn dc14 = new DataColumn("igv_gravado");
            DataColumn dc15 = new DataColumn("base_imp_mixta");
            DataColumn dc16 = new DataColumn("igv_mixto");
            DataColumn dc17 = new DataColumn("base_imp_no_grav");
            DataColumn dc18 = new DataColumn("igv_no_grav");
            DataColumn dc19 = new DataColumn("adq_no_grav");
            DataColumn dc20 = new DataColumn("isc");
            DataColumn dc21 = new DataColumn("otros_tributos");
            DataColumn dc22 = new DataColumn("total");
            DataColumn dc23 = new DataColumn("comp_no_domic");
            DataColumn dc24 = new DataColumn("num_constancia");
            DataColumn dc25 = new DataColumn("fecha_emision_const");
            DataColumn dc26 = new DataColumn("tipo_cambio");
            DataColumn dc27 = new DataColumn("fecha_original");
            DataColumn dc28 = new DataColumn("tipo_doc_orig");
            DataColumn dc29 = new DataColumn("num_serie_orig");
            DataColumn dc30 = new DataColumn("num_doc_orig");
            DataColumn dc31 = new DataColumn("pago");
            DataColumn dc32 = new DataColumn("fecha_pago");
            DataColumn dc33 = new DataColumn("detraccion");
            DataColumn dc34 = new DataColumn("tasa_detraccion");
            DataColumn dc35 = new DataColumn("importe_detraccion");
            DataColumn dc36 = new DataColumn("retencion");
            DataColumn dc37 = new DataColumn("importe_retencion");
            DataColumn dc38 = new DataColumn("motivo_retencion");
            DataColumn dc39 = new DataColumn("revision_tasa");
            DataColumn dc40 = new DataColumn("revision_tipo_cambio");
            DataColumn dc41 = new DataColumn("revision_verificacion");
            DataColumn dc42 = new DataColumn("base_revision");
            DataColumn dc43 = new DataColumn("igv_revision");
            DataColumn dc44 = new DataColumn("tipo_gasto");
            DataColumn dc45 = new DataColumn("recepcion");
            DataColumn dc46 = new DataColumn("comentario1");
            DataColumn dc47 = new DataColumn("comentario2");
            DataColumn dc48 = new DataColumn("vb");
            DataColumn dc49 = new DataColumn("compra_gravada_pais");
            DataColumn dc50 = new DataColumn("compra_gravada_exterior");
            DataColumn dc51 = new DataColumn("compra_no_gravada");
            DataColumn dc52 = new DataColumn("igv_pais");
            DataColumn dc53 = new DataColumn("exterior");
            DataColumn dc54 = new DataColumn("otros_cargos");
            DataColumn dc55 = new DataColumn("total1");
            DataColumn dc56 = new DataColumn("estado");

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

            DataRow dr = dt.NewRow();

            foreach (RegistroCompra obj in lst)
            {
                dr = dt.NewRow();

                dr["id_archivo_log"] = id;
                dr["id_linea"] = obj.NumFila;
                dr["no_ope_rac"] = obj.NoOpeRac;
                dr["fecha_emision"] = obj.FechaEmision;
                dr["fecha_vencimiento"] = obj.FechaVencimiento;
                dr["tipo_comprobante"] = obj.TipoComprobante;
                dr["nro_serie_comprobante"] = obj.NoSerieComprobante;
                dr["anio_emision_comprobante"] = obj.AnioEmisionComprobante;
                dr["numero_comprobante"] = obj.NumeroComprobante;
                dr["tipo_documento"] = obj.TipoDocumento;
                dr["numero_documento"] = obj.NumDocumento;
                dr["apell_nomb_raz_soc"] = obj.ApellNombRazSoc;
                dr["base_imponible_grav"] = obj.BaseImpGravada;
                dr["igv_gravado"] = obj.IGVGravado;
                dr["base_imp_mixta"] = obj.BaseImpMixta;
                dr["igv_mixto"] = obj.IGVMixto;
                dr["base_imp_no_grav"] = obj.BaseImpNoGravada;
                dr["igv_no_grav"] = obj.IGVNoGravado;
                dr["adq_no_grav"] = obj.AdquisicNoGravada;
                dr["isc"] = obj.ISC;
                dr["otros_tributos"] = obj.OtrosTributos;
                dr["total"] = obj.Total;
                dr["comp_no_domic"] = obj.CompNoDomic;
                dr["num_constancia"] = obj.NumConstancia;
                dr["fecha_emision_const"] = obj.FechaEmisionConstancia;
                dr["tipo_cambio"] = obj.TipoCambio;
                dr["fecha_original"] = obj.FechaOriginal;
                dr["tipo_doc_orig"] = obj.TipoDocumentoOriginal;
                dr["num_serie_orig"] = obj.NroSerieOriginal;
                dr["num_doc_orig"] = obj.NroDocumentoOriginal;
                dr["pago"] = obj.Pago;
                dr["fecha_pago"] = obj.FechaPago;
                dr["detraccion"] = obj.Detraccion;
                dr["tasa_detraccion"] = obj.TasaDetraccion;
                dr["importe_detraccion"] = obj.ImporteDetraccion;
                dr["retencion"] = obj.Retencion;
                dr["importe_retencion"] = obj.ImporteRetencion;
                dr["motivo_retencion"] = obj.MotivoRetencion;
                dr["revision_tasa"] = obj.RevisionTasa;
                dr["revision_tipo_cambio"] = obj.RevisionTipoCambio;
                dr["revision_verificacion"] = obj.RevisionVerificacion;
                dr["base_revision"] = obj.BaseRevision;
                dr["igv_revision"] = obj.IGVRevision;
                dr["tipo_gasto"] = obj.TipoGasto;
                dr["recepcion"] = obj.Recepcion;
                dr["comentario1"] = obj.Comentario1;
                dr["comentario2"] = obj.Comentario2;
                dr["vb"] = obj.VB;
                dr["compra_gravada_pais"] = obj.CompraGravadaPais;
                dr["compra_gravada_exterior"] = obj.CompraGravadaExterior;
                dr["compra_no_gravada"] = obj.CompraNoGravada;
                dr["igv_pais"] = obj.IGVPais;
                dr["exterior"] = obj.Exterior;
                dr["otros_cargos"] = obj.OtrosCargos;
                dr["total1"] = obj.Total1;
                dr["estado"] = obj.Estado;

                dt.Rows.Add(dr);
            }

            using (SqlConnection sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (SqlBulkCopy sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.InputRegistroCompra";

                    SqlBulkCopyColumnMapping id_archivo_log = new SqlBulkCopyColumnMapping("id_archivo_log",
                    "id_archivo_log");
                    sqlBlk.ColumnMappings.Add(id_archivo_log);

                    SqlBulkCopyColumnMapping id_linea = new SqlBulkCopyColumnMapping("id_linea",
                    "id_linea");
                    sqlBlk.ColumnMappings.Add(id_linea);

                    SqlBulkCopyColumnMapping no_ope_rac = new SqlBulkCopyColumnMapping("no_ope_rac",
                    "no_ope_rac");
                    sqlBlk.ColumnMappings.Add(no_ope_rac);

                    SqlBulkCopyColumnMapping fecha_emision = new SqlBulkCopyColumnMapping("fecha_emision",
                    "fecha_emision");
                    sqlBlk.ColumnMappings.Add(fecha_emision);

                    SqlBulkCopyColumnMapping fecha_vencimiento = new SqlBulkCopyColumnMapping("fecha_vencimiento",
                    "fecha_vencimiento");
                    sqlBlk.ColumnMappings.Add(fecha_vencimiento);

                    SqlBulkCopyColumnMapping tipo_comprobante = new SqlBulkCopyColumnMapping("tipo_comprobante",
                    "tipo_comprobante");
                    sqlBlk.ColumnMappings.Add(tipo_comprobante);

                    SqlBulkCopyColumnMapping nro_serie_comprobante = new SqlBulkCopyColumnMapping("nro_serie_comprobante",
                    "nro_serie_comprobante");
                    sqlBlk.ColumnMappings.Add(nro_serie_comprobante);

                    SqlBulkCopyColumnMapping anio_emision_comprobante = new SqlBulkCopyColumnMapping("anio_emision_comprobante",
                    "anio_emision_comprobante");
                    sqlBlk.ColumnMappings.Add(anio_emision_comprobante);

                    SqlBulkCopyColumnMapping numero_comprobante = new SqlBulkCopyColumnMapping("numero_comprobante",
                    "numero_comprobante");
                    sqlBlk.ColumnMappings.Add(numero_comprobante);

                    SqlBulkCopyColumnMapping tipo_documento = new SqlBulkCopyColumnMapping("tipo_documento",
                    "tipo_documento");
                    sqlBlk.ColumnMappings.Add(tipo_documento);

                    SqlBulkCopyColumnMapping numero_documento = new SqlBulkCopyColumnMapping("numero_documento",
                    "numero_documento");
                    sqlBlk.ColumnMappings.Add(numero_documento);

                    SqlBulkCopyColumnMapping apell_nomb_raz_soc = new SqlBulkCopyColumnMapping("apell_nomb_raz_soc",
                    "apell_nomb_raz_soc");
                    sqlBlk.ColumnMappings.Add(apell_nomb_raz_soc);

                    SqlBulkCopyColumnMapping base_imponible_grav = new SqlBulkCopyColumnMapping("base_imponible_grav",
                    "base_imponible_grav");
                    sqlBlk.ColumnMappings.Add(base_imponible_grav);

                    SqlBulkCopyColumnMapping igv_gravado = new SqlBulkCopyColumnMapping("igv_gravado",
                    "igv_gravado");
                    sqlBlk.ColumnMappings.Add(igv_gravado);

                    SqlBulkCopyColumnMapping base_imp_mixta = new SqlBulkCopyColumnMapping("base_imp_mixta",
                    "base_imp_mixta");
                    sqlBlk.ColumnMappings.Add(base_imp_mixta);

                    SqlBulkCopyColumnMapping igv_mixto = new SqlBulkCopyColumnMapping("igv_mixto",
                    "igv_mixto");
                    sqlBlk.ColumnMappings.Add(igv_mixto);

                    SqlBulkCopyColumnMapping base_imp_no_grav = new SqlBulkCopyColumnMapping("base_imp_no_grav",
                    "base_imp_no_grav");
                    sqlBlk.ColumnMappings.Add(base_imp_no_grav);

                    SqlBulkCopyColumnMapping igv_no_grav = new SqlBulkCopyColumnMapping("igv_no_grav",
                    "igv_no_grav");
                    sqlBlk.ColumnMappings.Add(igv_no_grav);

                    SqlBulkCopyColumnMapping adq_no_grav = new SqlBulkCopyColumnMapping("adq_no_grav",
                    "adq_no_grav");
                    sqlBlk.ColumnMappings.Add(adq_no_grav);

                    SqlBulkCopyColumnMapping isc = new SqlBulkCopyColumnMapping("isc",
                    "isc");
                    sqlBlk.ColumnMappings.Add(isc);

                    SqlBulkCopyColumnMapping otros_tributos = new SqlBulkCopyColumnMapping("otros_tributos",
                    "otros_tributos");
                    sqlBlk.ColumnMappings.Add(otros_tributos);

                    SqlBulkCopyColumnMapping total = new SqlBulkCopyColumnMapping("total",
                    "total");
                    sqlBlk.ColumnMappings.Add(total);

                    SqlBulkCopyColumnMapping comp_no_domic = new SqlBulkCopyColumnMapping("comp_no_domic",
                    "comp_no_domic");
                    sqlBlk.ColumnMappings.Add(comp_no_domic);

                    SqlBulkCopyColumnMapping num_constancia = new SqlBulkCopyColumnMapping("num_constancia",
                    "num_constancia");
                    sqlBlk.ColumnMappings.Add(num_constancia);

                    SqlBulkCopyColumnMapping fecha_emision_const = new SqlBulkCopyColumnMapping("fecha_emision_const",
                    "fecha_emision_const");
                    sqlBlk.ColumnMappings.Add(fecha_emision_const);

                    SqlBulkCopyColumnMapping tipo_cambio = new SqlBulkCopyColumnMapping("tipo_cambio",
                    "tipo_cambio");
                    sqlBlk.ColumnMappings.Add(tipo_cambio);

                    SqlBulkCopyColumnMapping fecha_original = new SqlBulkCopyColumnMapping("fecha_original",
                    "fecha_original");
                    sqlBlk.ColumnMappings.Add(fecha_original);

                    SqlBulkCopyColumnMapping tipo_doc_orig = new SqlBulkCopyColumnMapping("tipo_doc_orig",
                    "tipo_doc_orig");
                    sqlBlk.ColumnMappings.Add(tipo_doc_orig);

                    SqlBulkCopyColumnMapping num_serie_orig = new SqlBulkCopyColumnMapping("num_serie_orig",
                    "num_serie_orig");
                    sqlBlk.ColumnMappings.Add(num_serie_orig);

                    SqlBulkCopyColumnMapping num_doc_orig = new SqlBulkCopyColumnMapping("num_doc_orig",
                    "num_doc_orig");
                    sqlBlk.ColumnMappings.Add(num_doc_orig);

                    SqlBulkCopyColumnMapping pago = new SqlBulkCopyColumnMapping("pago",
                    "pago");

                    SqlBulkCopyColumnMapping fecha_pago = new SqlBulkCopyColumnMapping("fecha_pago",
                    "fecha_pago");
                    sqlBlk.ColumnMappings.Add(fecha_pago);

                    SqlBulkCopyColumnMapping detraccion = new SqlBulkCopyColumnMapping("detraccion",
                    "detraccion");
                    sqlBlk.ColumnMappings.Add(detraccion);

                    SqlBulkCopyColumnMapping tasa_detraccion = new SqlBulkCopyColumnMapping("tasa_detraccion",
                    "tasa_detraccion");
                    sqlBlk.ColumnMappings.Add(tasa_detraccion);

                    SqlBulkCopyColumnMapping importe_detraccion = new SqlBulkCopyColumnMapping("importe_detraccion",
                    "importe_detraccion");
                    sqlBlk.ColumnMappings.Add(importe_detraccion);

                    SqlBulkCopyColumnMapping retencion = new SqlBulkCopyColumnMapping("retencion",
                    "retencion");
                    sqlBlk.ColumnMappings.Add(retencion);

                    SqlBulkCopyColumnMapping importe_retencion = new SqlBulkCopyColumnMapping("importe_retencion",
                    "importe_retencion");
                    sqlBlk.ColumnMappings.Add(importe_retencion);

                    SqlBulkCopyColumnMapping motivo_retencion = new SqlBulkCopyColumnMapping("motivo_retencion",
                    "motivo_retencion");
                    sqlBlk.ColumnMappings.Add(motivo_retencion);

                    SqlBulkCopyColumnMapping revision_tasa = new SqlBulkCopyColumnMapping("revision_tasa",
                    "revision_tasa");
                    sqlBlk.ColumnMappings.Add(revision_tasa);

                    SqlBulkCopyColumnMapping revision_tipo_cambio = new SqlBulkCopyColumnMapping("revision_tipo_cambio",
                    "revision_tipo_cambio");
                    sqlBlk.ColumnMappings.Add(revision_tipo_cambio);

                    SqlBulkCopyColumnMapping revision_verificacion = new SqlBulkCopyColumnMapping("revision_verificacion",
                    "revision_verificacion");
                    sqlBlk.ColumnMappings.Add(revision_verificacion);

                    SqlBulkCopyColumnMapping base_revision = new SqlBulkCopyColumnMapping("base_revision",
                    "base_revision");
                    sqlBlk.ColumnMappings.Add(base_revision);

                    SqlBulkCopyColumnMapping igv_revision = new SqlBulkCopyColumnMapping("igv_revision",
                    "igv_revision");
                    sqlBlk.ColumnMappings.Add(igv_revision);

                    SqlBulkCopyColumnMapping tipo_gasto = new SqlBulkCopyColumnMapping("tipo_gasto",
                    "tipo_gasto");
                    sqlBlk.ColumnMappings.Add(tipo_gasto);

                    SqlBulkCopyColumnMapping recepcion = new SqlBulkCopyColumnMapping("recepcion",
                    "recepcion");
                    sqlBlk.ColumnMappings.Add(recepcion);

                    SqlBulkCopyColumnMapping comentario1 = new SqlBulkCopyColumnMapping("comentario1",
                    "comentario1");
                    sqlBlk.ColumnMappings.Add(comentario1);

                    SqlBulkCopyColumnMapping comentario2 = new SqlBulkCopyColumnMapping("comentario2",
                    "comentario2");
                    sqlBlk.ColumnMappings.Add(comentario2);

                    SqlBulkCopyColumnMapping vb = new SqlBulkCopyColumnMapping("vb",
                    "vb");
                    sqlBlk.ColumnMappings.Add(vb);

                    SqlBulkCopyColumnMapping compra_gravada_pais = new SqlBulkCopyColumnMapping("compra_gravada_pais",
                    "compra_gravada_pais");
                    sqlBlk.ColumnMappings.Add(compra_gravada_pais);

                    SqlBulkCopyColumnMapping compra_gravada_exterior = new SqlBulkCopyColumnMapping("compra_gravada_exterior",
                    "compra_gravada_exterior");
                    sqlBlk.ColumnMappings.Add(compra_gravada_exterior);

                    SqlBulkCopyColumnMapping compra_no_gravada = new SqlBulkCopyColumnMapping("compra_no_gravada",
                    "compra_no_gravada");
                    sqlBlk.ColumnMappings.Add(compra_no_gravada);

                    SqlBulkCopyColumnMapping igv_pais = new SqlBulkCopyColumnMapping("igv_pais",
                    "igv_pais");
                    sqlBlk.ColumnMappings.Add(igv_pais);

                    SqlBulkCopyColumnMapping exterior = new SqlBulkCopyColumnMapping("exterior",
                    "exterior");
                    sqlBlk.ColumnMappings.Add(exterior);

                    SqlBulkCopyColumnMapping otros_cargos = new SqlBulkCopyColumnMapping("otros_cargos",
                    "otros_cargos");
                    sqlBlk.ColumnMappings.Add(otros_cargos);

                    SqlBulkCopyColumnMapping total1 = new SqlBulkCopyColumnMapping("total1",
                    "total1");
                    sqlBlk.ColumnMappings.Add(total1);

                    SqlBulkCopyColumnMapping estado = new SqlBulkCopyColumnMapping("estado",
                    "estado");
                    sqlBlk.ColumnMappings.Add(estado);

                    sqlBlk.WriteToServer(dt);
                }
            }   
        }

        public void CargaLibroMayor(String rutaArchivo, String ruc, Char iOpe, String iMoneda, Char iRegistro, Int32 idArchivo)
        {
            String query = "select NUMDOC,TIPO,FECHAOPE,IMPORTE,SUBTOTAL,CUENTA,GL,DEBITO,CREDITO,SALDO,REFERENCIA,ITEM,DESCRIPCION,GLOSA from [sheet1$]";

            List<LibroMayor> lst = new List<LibroMayor>();

            using (OleDbConnection oleDbCn = new OleDbConnection(Connection.ExcelConnection(rutaArchivo)))
            {
                oleDbCn.Open();

                using (OleDbCommand oleDbCmd = new OleDbCommand(query, oleDbCn))
                {
                    using (OleDbDataReader oleDbdr = oleDbCmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (oleDbdr != null)
                        {
                            if (oleDbdr.HasRows)
                            {
                                Int32 i1 = oleDbdr.GetOrdinal("NUMDOC");
                                Int32 i2 = oleDbdr.GetOrdinal("TIPO");
                                Int32 i3 = oleDbdr.GetOrdinal("FECHAOPE");
                                Int32 i4 = oleDbdr.GetOrdinal("IMPORTE");
                                Int32 i5 = oleDbdr.GetOrdinal("SUBTOTAL");
                                Int32 i6 = oleDbdr.GetOrdinal("CUENTA");
                                Int32 i7 = oleDbdr.GetOrdinal("GL");
                                Int32 i8 = oleDbdr.GetOrdinal("DEBITO");
                                Int32 i9 = oleDbdr.GetOrdinal("CREDITO");
                                Int32 i10 = oleDbdr.GetOrdinal("SALDO");
                                Int32 i11 = oleDbdr.GetOrdinal("REFERENCIA");
                                Int32 i12 = oleDbdr.GetOrdinal("ITEM");
                                Int32 i13 = oleDbdr.GetOrdinal("DESCRIPCION");
                                Int32 i14 = oleDbdr.GetOrdinal("GLOSA");

                                LibroMayor obj = new LibroMayor();

                                Int32 n_linea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (!oleDbdr.IsDBNull(i1))
                                    {
                                        obj = new LibroMayor();

                                        obj.Num_Linea = n_linea;

                                        obj.NumDoc = Convert.ToInt64(oleDbdr.GetDouble(i1)).ToString();

                                        if (oleDbdr.IsDBNull(i2))
                                        {
                                            obj.Tipos = String.Empty;
                                        }
                                        else
                                        {
                                            obj.Tipos = oleDbdr.GetString(i2);
                                        }

                                        if (oleDbdr.IsDBNull(i3))
                                        {
                                            obj.FechaOpe = DateTime.Parse("1900-01-01");
                                        }
                                        else
                                        {
                                            obj.FechaOpe = Formato.ObtieneFecha(oleDbdr.GetString(i3), "DD.MM.AAAA");
                                        }

                                        if (oleDbdr.IsDBNull(i4))
                                        {
                                            obj.Importe = -1;
                                        }
                                        else
                                        {
                                            obj.Importe = Convert.ToDecimal(oleDbdr.GetDouble(i4));
                                        }

                                        if (oleDbdr.IsDBNull(i5))
                                        {
                                            obj.SubTotal = String.Empty;
                                        }
                                        else
                                        {
                                            obj.SubTotal = Convert.ToInt32(oleDbdr.GetDouble(i5)).ToString();
                                        }

                                        if (oleDbdr.IsDBNull(i6))
                                        {
                                            obj.Cuenta = String.Empty;
                                        }
                                        else
                                        {
                                            obj.Cuenta = Convert.ToInt64(oleDbdr.GetDouble(i6)).ToString();
                                        }

                                        if (oleDbdr.IsDBNull(i7))
                                        {
                                            obj.GL = String.Empty;
                                        }
                                        else
                                        {
                                            obj.GL = Convert.ToInt64(oleDbdr.GetDouble(i7)).ToString();
                                        }

                                        if (oleDbdr.IsDBNull(i8))
                                        {
                                            obj.Debito = 0;
                                        }
                                        else
                                        {
                                            obj.Debito = Convert.ToDecimal(oleDbdr.GetDouble(i8));
                                        }

                                        if (oleDbdr.IsDBNull(i9))
                                        {
                                            obj.Credito = 0;
                                        }
                                        else
                                        {
                                            obj.Credito = Convert.ToDecimal(oleDbdr.GetDouble(i9));
                                        }

                                        if (oleDbdr.IsDBNull(i10))
                                        {
                                            obj.Saldo = 0;
                                        }
                                        else
                                        {
                                            obj.Saldo = Convert.ToDecimal(oleDbdr.GetDouble(i10));
                                        }

                                        if (oleDbdr.IsDBNull(i11))
                                        {
                                            obj.Referencia = String.Empty;
                                        }
                                        else
                                        {
                                            obj.Referencia = oleDbdr.GetString(i11);
                                        }

                                        if (oleDbdr.IsDBNull(i12))
                                        {
                                            obj.Item = 0;
                                        }
                                        else
                                        {
                                            obj.Item = Convert.ToInt64(oleDbdr.GetDouble(i12));
                                        }

                                        if (oleDbdr.IsDBNull(i13))
                                        {
                                            obj.Descripcion = String.Empty;
                                        }
                                        else
                                        {
                                            obj.Descripcion = oleDbdr.GetString(i13);
                                        }

                                        if (oleDbdr.IsDBNull(i14))
                                        {
                                            obj.Glosa = String.Empty;
                                        }
                                        else
                                        {
                                            obj.Glosa = Convert.ToInt64(oleDbdr.GetDouble(i14)).ToString();
                                        }

                                        n_linea++;

                                        lst.Add(obj);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            FileInfo fi = new FileInfo(rutaArchivo);

            //Guardamos la carga cabecera
            ArchivoLog objArchLog = new ArchivoLog();
            objArchLog.id_archivo = idArchivo;
            objArchLog.indicador_libro = iRegistro.ToString();
            objArchLog.indicador_moneda = iMoneda;
            objArchLog.indicador_ope = iOpe.ToString();
            objArchLog.nombre_carga = fi.Name;
            objArchLog.num_ruc = ruc;
            objArchLog.fecha_carga = DateTime.Now;
            objArchLog.cant_registros = lst.Count;
            objArchLog.tipo_ope = "I";

            DAArchivoLog objDA = new DAArchivoLog();

            Int32 id = objDA.Guardar(objArchLog);

            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("id_archivo_log");
            DataColumn dc2 = new DataColumn("num_linea");
            DataColumn dc3 = new DataColumn("numdoc");
            DataColumn dc4 = new DataColumn("tipo");
            DataColumn dc5 = new DataColumn("fecha_ope");
            DataColumn dc6 = new DataColumn("importe");
            DataColumn dc7 = new DataColumn("subtotal");
            DataColumn dc8 = new DataColumn("cuenta");
            DataColumn dc9 = new DataColumn("gl");
            DataColumn dc10 = new DataColumn("debito");
            DataColumn dc11 = new DataColumn("credito");
            DataColumn dc12 = new DataColumn("saldo");
            DataColumn dc13 = new DataColumn("referencia");
            DataColumn dc14 = new DataColumn("item");
            DataColumn dc15 = new DataColumn("descripcion");
            DataColumn dc16 = new DataColumn("glosa");

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

            DataRow dr = dt.NewRow();

            foreach (LibroMayor obj in lst)
            {
                dr = dt.NewRow();

                dr["id_archivo_log"] = id;
                dr["num_linea"] = obj.Num_Linea;
                dr["numdoc"] = obj.NumDoc;
                dr["tipo"] = obj.Tipos;
                dr["fecha_ope"] = obj.FechaOpe;
                dr["importe"] = obj.Importe;
                dr["subtotal"] = obj.SubTotal;
                dr["cuenta"] = obj.Cuenta;
                dr["gl"] = obj.GL;
                dr["debito"] = obj.Debito;
                dr["credito"] = obj.Credito;
                dr["saldo"] = obj.Saldo;
                dr["referencia"] = obj.Referencia;
                dr["item"] = obj.Item;
                dr["descripcion"] = obj.Descripcion;
                dr["glosa"] = obj.Glosa;

                dt.Rows.Add(dr);
            }

            using (SqlConnection sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (SqlBulkCopy sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.InputLibroMayor";

                    SqlBulkCopyColumnMapping id_archivo_log = new SqlBulkCopyColumnMapping("id_archivo_log",
                    "id_archivo_log");
                    sqlBlk.ColumnMappings.Add(id_archivo_log);

                    SqlBulkCopyColumnMapping num_linea = new SqlBulkCopyColumnMapping("num_linea",
                    "num_linea");
                    sqlBlk.ColumnMappings.Add(num_linea);

                    SqlBulkCopyColumnMapping numdoc = new SqlBulkCopyColumnMapping("numdoc",
                    "numdoc");
                    sqlBlk.ColumnMappings.Add(numdoc);

                    /*SqlBulkCopyColumnMapping tipo = new SqlBulkCopyColumnMapping("tipo",
                    "tipo");
                    sqlBlk.ColumnMappings.Add(tipo);*/

                    SqlBulkCopyColumnMapping fecha_ope = new SqlBulkCopyColumnMapping("fecha_ope",
                    "fecha_ope");
                    sqlBlk.ColumnMappings.Add(fecha_ope);

                    SqlBulkCopyColumnMapping importe = new SqlBulkCopyColumnMapping("importe",
                    "importe");
                    sqlBlk.ColumnMappings.Add(importe);

                    SqlBulkCopyColumnMapping subtotal = new SqlBulkCopyColumnMapping("subtotal",
                    "subtotal");
                    sqlBlk.ColumnMappings.Add(subtotal);

                    SqlBulkCopyColumnMapping cuenta = new SqlBulkCopyColumnMapping("cuenta",
                    "cuenta");
                    sqlBlk.ColumnMappings.Add(cuenta);

                    SqlBulkCopyColumnMapping gl = new SqlBulkCopyColumnMapping("gl",
                    "gl");
                    sqlBlk.ColumnMappings.Add(gl);

                    SqlBulkCopyColumnMapping debito = new SqlBulkCopyColumnMapping("debito",
                    "debito");
                    sqlBlk.ColumnMappings.Add(debito);

                    SqlBulkCopyColumnMapping credito = new SqlBulkCopyColumnMapping("credito",
                    "credito");
                    sqlBlk.ColumnMappings.Add(credito);

                    SqlBulkCopyColumnMapping saldo = new SqlBulkCopyColumnMapping("saldo",
                    "saldo");
                    sqlBlk.ColumnMappings.Add(saldo);

                    SqlBulkCopyColumnMapping referencia = new SqlBulkCopyColumnMapping("referencia",
                    "referencia");
                    sqlBlk.ColumnMappings.Add(referencia);

                    SqlBulkCopyColumnMapping item = new SqlBulkCopyColumnMapping("item",
                    "item");
                    sqlBlk.ColumnMappings.Add(item);

                    SqlBulkCopyColumnMapping descripcion = new SqlBulkCopyColumnMapping("descripcion",
                    "descripcion");
                    sqlBlk.ColumnMappings.Add(descripcion);

                    SqlBulkCopyColumnMapping glosa = new SqlBulkCopyColumnMapping("glosa",
                    "glosa");
                    sqlBlk.ColumnMappings.Add(glosa);

                    sqlBlk.WriteToServer(dt);
                }
            }
        }
    }
}
