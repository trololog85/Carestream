using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Import.Version_3_0
{
    public class ImportRegistroVenta : IImportLibroRegistroVentas
    {
        public List<RegistroVenta> LeeRegistro(Model.Entities.Import import)
        {
            const string query = "select Num,FECHA,TIPOCOMP,INTERNO,SERIE,NoCOMPROBANTE,TIPODOCUMENTO,RUC,CODIGO,APELLIDOSYNOMBRESORAZONSOCIAL," +
                                 "ORIGINAL,MON,TIPODECAMBIO,VV,IGV,PV,FECHAMOD,TIPOMOD,SERIEMOD,NoMOD,VVMOD,IGVMOD,PVMOD,OPENOGRAV FROM [sheet1$]";

            var lst = new List<RegistroVenta>();

            using (var oleDbCn = new OleDbConnection(Connection.ExcelConnection(import.Ruta)))
            {
                oleDbCn.Open();

                using (var oleDbCmd = new OleDbCommand(query, oleDbCn))
                {
                    using (var oleDbdr = oleDbCmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (oleDbdr == null) return lst;

                        if (!oleDbdr.HasRows) return lst;

                        var i1 = oleDbdr.GetOrdinal("Num");
                        var i2 = oleDbdr.GetOrdinal("FECHA");
                        var i3 = oleDbdr.GetOrdinal("TIPOCOMP");
                        var i4 = oleDbdr.GetOrdinal("INTERNO");
                        var i5 = oleDbdr.GetOrdinal("SERIE");
                        var i6 = oleDbdr.GetOrdinal("NoCOMPROBANTE");
                        var i7 = oleDbdr.GetOrdinal("TIPODOCUMENTO");
                        var i8 = oleDbdr.GetOrdinal("RUC");
                        var i9 = oleDbdr.GetOrdinal("CODIGO");
                        var i10 = oleDbdr.GetOrdinal("APELLIDOSYNOMBRESORAZONSOCIAL");
                        var i11 = oleDbdr.GetOrdinal("ORIGINAL");
                        var i12 = oleDbdr.GetOrdinal("MON");
                        var i13 = oleDbdr.GetOrdinal("TIPODECAMBIO");
                        var i14 = oleDbdr.GetOrdinal("VV");
                        var i15 = oleDbdr.GetOrdinal("IGV");
                        var i16 = oleDbdr.GetOrdinal("PV");
                        var i17 = oleDbdr.GetOrdinal("FECHAMOD");
                        var i18 = oleDbdr.GetOrdinal("TIPOMOD");
                        var i19 = oleDbdr.GetOrdinal("SERIEMOD");
                        var i20 = oleDbdr.GetOrdinal("NoMOD");
                        var i21 = oleDbdr.GetOrdinal("VVMOD");
                        var i22 = oleDbdr.GetOrdinal("IGVMOD");
                        var i23 = oleDbdr.GetOrdinal("PVMOD");
                        var i24 = oleDbdr.GetOrdinal("OPENOGRAV");

                        var objReg = new RegistroVenta();

                        var nLinea = 1;

                        while (oleDbdr.Read())
                        {
                            if (oleDbdr.IsDBNull(i1)) continue;

                            objReg = new RegistroVenta();

                            objReg.NumeroCorrelativo = oleDbdr.GetString(i1);

                            objReg.FechaComprobante = Formato.ObtieneFecha(oleDbdr.GetString(i2),
                                "DD.MM.AAAA");

                            objReg.TipoComprobante = oleDbdr.IsDBNull(i3)
                                ? String.Empty
                                : oleDbdr.GetString(i3);

                            objReg.SerieComprobante = oleDbdr.GetString(i5);

                            objReg.NumeroComprobante = Math.Truncate(oleDbdr.GetDouble(i6)).ToString(CultureInfo.InvariantCulture);

                            if (oleDbdr.IsDBNull(i7))
                            {
                                objReg.TipoDocumento = String.Empty;
                            }
                            else
                            {
                                objReg.TipoDocumento =
                                    oleDbdr.GetFieldType(i7).ToString() == "System.String"
                                        ? oleDbdr.GetString(i7)
                                        : oleDbdr.GetDouble(i7).ToString();
                            }

                            if (oleDbdr.IsDBNull(i8))
                            {
                                objReg.NumeroDocumento = String.Empty;
                            }
                            else
                            {
                                objReg.NumeroDocumento = oleDbdr.GetFieldType(i8).ToString() == "System.String"
                                    ? oleDbdr.GetString(i8)
                                    : Math.Truncate(oleDbdr.GetDouble(i8)).ToString();
                            }

                            if (oleDbdr.IsDBNull(i9))
                            {
                                objReg.CodigoDocumento = String.Empty;
                            }
                            else
                            {
                                objReg.CodigoDocumento = oleDbdr.GetFieldType(i9).ToString() == "System.String"
                                    ? oleDbdr.GetString(i9)
                                    : Math.Truncate(oleDbdr.GetDouble(i9)).ToString();
                            }

                            objReg.NombreRazonSocial = oleDbdr.GetString(i10);

                            objReg.ValorVentaOriginal = oleDbdr.IsDBNull(i11)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i11));

                            objReg.Moneda = oleDbdr.IsDBNull(i12)
                                ? String.Empty
                                : oleDbdr.GetString(i12);

                            objReg.TipoCambio = oleDbdr.IsDBNull(i13)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i13));

                            objReg.VV = oleDbdr.IsDBNull(i14)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i14));

                            objReg.IGV = oleDbdr.IsDBNull(i15)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i15));

                            objReg.PV = oleDbdr.IsDBNull(i16)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i16));

                            objReg.OperacionNoGravada = oleDbdr.IsDBNull(i24)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i24));

                            objReg.FechaModificada = oleDbdr.IsDBNull(i17)
                                ? DateTime.Parse("1900-01-01")
                                : Formato.ObtieneFecha(oleDbdr.GetString(i17), "DD.MM.AAAA");

                            if (oleDbdr.IsDBNull(i18))
                            {
                                objReg.TipoComprobanteModificado = String.Empty;
                            }
                            else
                            {
                                objReg.TipoComprobanteModificado = oleDbdr.GetFieldType(i18).ToString() == "System.String"
                                    ? oleDbdr.GetString(i18)
                                    : oleDbdr.GetDouble(i18).ToString();
                            }

                            objReg.NumeroSerieModificado = oleDbdr.IsDBNull(i19) ? String.Empty : oleDbdr.GetString(i19);

                            objReg.NumeroComprobanteModificado = oleDbdr.IsDBNull(i20) ? String.Empty : oleDbdr.GetString(i20);

                            objReg.VVModificado = oleDbdr.IsDBNull(i21)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i21));

                            objReg.IGVModificado = oleDbdr.IsDBNull(i22)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i22));

                            objReg.PVModificado = oleDbdr.IsDBNull(i23)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i23));

                            objReg.Linea = nLinea;

                            nLinea++;

                            lst.Add(objReg);
                        }
                    }
                }
            }

            return lst;
        }
    }
}
