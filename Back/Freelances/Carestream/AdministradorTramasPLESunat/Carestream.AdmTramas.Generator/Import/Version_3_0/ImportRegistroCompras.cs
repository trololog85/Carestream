using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Import.Version_3_0
{
    public class ImportRegistroCompras : IImportLibroRegistroCompras
    {
        public List<RegistroCompra> LeeRegistro(Model.Entities.Import import)
        {
            const string query = "SELECT NOOPERAC,FEMISION,FVCTO,TIPOCOMP,NUMSERIECOMP,ANIOEMISCOMP,NUMCOMP,TIPODOC,NUMDOC,APELLNOMBRAZ,"
                + "BASEIMPGRAV,IGVGRAV,BASEIMPMIX,IGVMIX,BASEIMPNOGRAV,IGVNOGRAV,ADQNOGRAV,ISC,OTTRIB,TOTAL,COMPNODOMC,NUMCONST,FECHEMICONST,"
                + "TIPOCAMB,FECHAORIG,TIPODOCORIG,SERIEDOCORIG,NUMDOCORIG,PAGO,FECHPAGO,DETRACCION,TASADETRACCION,IMPORTEDETRACCION,"
                + "MOTIVORETENCION,RETENCION,IMPORTERETEN,REVISIONTASA,REVISIONTIPOCAMBIO,REVISIONVERIF,BASEREVI,IGVREVI,TIPOGASTO,"
                + "RECEPCION,COMENTARIO1,COMENTARIO2,VB,COMPAGRAVPAIS,COMPNOAGRAVEXT,COMPNOGRAV,IGVPAIS,EXTERIOR,OTROSCARGOS,TOTAL1 FROM [sheet1$]";

            var lst = new List<RegistroCompra>();

            using (var oleDbCn = new OleDbConnection(Connection.ExcelConnection(import.Ruta)))
            {
                oleDbCn.Open();

                using (var oleDbCmd = new OleDbCommand(query, oleDbCn))
                {
                    using (var oleDbdr = oleDbCmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (oleDbdr != null)
                        {
                            if (oleDbdr.HasRows)
                            {
                                var i1 = oleDbdr.GetOrdinal("NOOPERAC");
                                var i2 = oleDbdr.GetOrdinal("FEMISION");
                                var i3 = oleDbdr.GetOrdinal("FVCTO");
                                var i4 = oleDbdr.GetOrdinal("TIPOCOMP");
                                var i5 = oleDbdr.GetOrdinal("NUMSERIECOMP");
                                var i6 = oleDbdr.GetOrdinal("ANIOEMISCOMP");
                                var i7 = oleDbdr.GetOrdinal("NUMCOMP");
                                var i8 = oleDbdr.GetOrdinal("TIPODOC");
                                var i9 = oleDbdr.GetOrdinal("NUMDOC");
                                var i10 = oleDbdr.GetOrdinal("APELLNOMBRAZ");
                                var i11 = oleDbdr.GetOrdinal("BASEIMPGRAV");
                                var i12 = oleDbdr.GetOrdinal("IGVGRAV");
                                var i13 = oleDbdr.GetOrdinal("BASEIMPMIX");
                                var i14 = oleDbdr.GetOrdinal("IGVMIX");
                                var i15 = oleDbdr.GetOrdinal("BASEIMPNOGRAV");
                                var i16 = oleDbdr.GetOrdinal("IGVNOGRAV");
                                var i17 = oleDbdr.GetOrdinal("ADQNOGRAV");
                                var i18 = oleDbdr.GetOrdinal("ISC");
                                var i19 = oleDbdr.GetOrdinal("OTTRIB");
                                var i20 = oleDbdr.GetOrdinal("TOTAL");
                                var i21 = oleDbdr.GetOrdinal("COMPNODOMC");
                                var i22 = oleDbdr.GetOrdinal("NUMCONST");
                                var i23 = oleDbdr.GetOrdinal("FECHEMICONST");
                                var i24 = oleDbdr.GetOrdinal("TIPOCAMB");
                                var i25 = oleDbdr.GetOrdinal("FECHAORIG");
                                var i26 = oleDbdr.GetOrdinal("TIPODOCORIG");
                                var i27 = oleDbdr.GetOrdinal("SERIEDOCORIG");
                                var i28 = oleDbdr.GetOrdinal("NUMDOCORIG");
                                var i29 = oleDbdr.GetOrdinal("PAGO");
                                var i30 = oleDbdr.GetOrdinal("FECHPAGO");
                                var i31 = oleDbdr.GetOrdinal("DETRACCION");
                                var i32 = oleDbdr.GetOrdinal("TASADETRACCION");
                                var i33 = oleDbdr.GetOrdinal("IMPORTEDETRACCION");
                                var i34 = oleDbdr.GetOrdinal("RETENCION");
                                var i35 = oleDbdr.GetOrdinal("IMPORTERETEN");
                                var i36 = oleDbdr.GetOrdinal("MOTIVORETENCION");
                                var i37 = oleDbdr.GetOrdinal("REVISIONTASA");
                                var i38 = oleDbdr.GetOrdinal("REVISIONTIPOCAMBIO");
                                var i39 = oleDbdr.GetOrdinal("REVISIONVERIF");
                                var i40 = oleDbdr.GetOrdinal("BASEREVI");
                                var i41 = oleDbdr.GetOrdinal("IGVREVI");
                                var i42 = oleDbdr.GetOrdinal("TIPOGASTO");
                                var i43 = oleDbdr.GetOrdinal("RECEPCION");
                                var i44 = oleDbdr.GetOrdinal("COMENTARIO1");
                                var i45 = oleDbdr.GetOrdinal("COMENTARIO2");
                                var i46 = oleDbdr.GetOrdinal("VB");
                                var i47 = oleDbdr.GetOrdinal("COMPAGRAVPAIS");
                                var i48 = oleDbdr.GetOrdinal("COMPNOAGRAVEXT");
                                var i49 = oleDbdr.GetOrdinal("COMPNOGRAV");
                                var i50 = oleDbdr.GetOrdinal("IGVPAIS");
                                var i51 = oleDbdr.GetOrdinal("EXTERIOR");
                                var i52 = oleDbdr.GetOrdinal("OTROSCARGOS");
                                var i53 = oleDbdr.GetOrdinal("TOTAL1");

                                var objReg = new RegistroCompra();

                                var numLinea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (oleDbdr.IsDBNull(i1)) continue;
                                    objReg = new RegistroCompra();

                                    objReg.Linea = numLinea;
                                    objReg.NumeroOperacion = oleDbdr.GetString(i1);
                                    objReg.FechaEmision = Formato.ObtieneFecha(oleDbdr.GetString(i2), "DD.MM.AAAA");

                                    objReg.FechaVencimiento = oleDbdr.IsDBNull(i3) ? DateTime.Parse("1900-01-01") : Formato.ObtieneFecha(oleDbdr.GetString(i3), "DD.MM.AAAA");

                                    objReg.TipoComprobante = oleDbdr.IsDBNull(i4) ? String.Empty : oleDbdr.GetString(i4);

                                    objReg.NumeroSerieComprobante = oleDbdr.IsDBNull(i5) ? String.Empty : oleDbdr.GetString(i5);

                                    //objReg.AnioEmisionComprobante = oleDbdr.IsDBNull(i6) ? 0 : Int32.Parse(oleDbdr.GetString(i6));

                                    objReg.NumeroComprobante = oleDbdr.GetString(i7);

                                    objReg.TipoDocumento = oleDbdr.IsDBNull(i8) ? String.Empty : oleDbdr.GetString(i8);

                                    objReg.NumeroDocumento = oleDbdr.IsDBNull(i9) ? String.Empty : Convert.ToInt64(oleDbdr.GetDouble(i9)).ToString();

                                    objReg.NombreRazonSocial = oleDbdr.GetString(i10);

                                    objReg.BaseImponibleGravada = oleDbdr.IsDBNull(i11) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i11));

                                    objReg.IGVGravado = Convert.ToDecimal(oleDbdr.GetDouble(i12));

                                    objReg.BaseImponibleMixta = oleDbdr.IsDBNull(i13) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i13));

                                    objReg.IGVMixto = oleDbdr.IsDBNull(i14) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i14));

                                    objReg.BaseImponibleNoGravada = oleDbdr.IsDBNull(i15) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i15));

                                    objReg.IGVNoGravado = oleDbdr.IsDBNull(i16) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i16));

                                    objReg.AdquisicionNoGravada = oleDbdr.IsDBNull(i17) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i17));

                                    objReg.ISC = oleDbdr.IsDBNull(i18) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i18));

                                    objReg.OtrosTributos = oleDbdr.IsDBNull(i19) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i19));

                                    objReg.Total = Convert.ToDecimal(oleDbdr.GetDouble(i20));

                                    objReg.ComprobanteNoDomiciliado = oleDbdr.IsDBNull(i21) ? String.Empty : oleDbdr.GetString(i21);

                                    if (oleDbdr.IsDBNull(i22))
                                    {
                                        objReg.NumeroConstancia = String.Empty;
                                    }
                                    else
                                    {
                                        objReg.NumeroConstancia = oleDbdr.GetFieldType(i22).ToString() == "System.Double" ? Convert.ToInt64(oleDbdr.GetDouble(i22)).ToString() : oleDbdr.GetString(i22);
                                    }

                                    objReg.FechaEmisionConstancia = oleDbdr.IsDBNull(i23) ? DateTime.Parse("1900-01-01") : Formato.ObtieneFecha(oleDbdr.GetString(i23), "DD.MM.AAAA");

                                    objReg.TipoCambio = oleDbdr.IsDBNull(i24) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i24));

                                    objReg.FechaOriginal = oleDbdr.IsDBNull(i25) ? DateTime.Parse("1900-01-01") : Formato.ObtieneFecha(oleDbdr.GetString(i25), "DD.MM.AAAA");

                                    objReg.TipoDocumentoOriginal = oleDbdr.IsDBNull(i26) ? String.Empty : oleDbdr.GetString(i26);

                                    objReg.NumeroSerieOriginal = oleDbdr.IsDBNull(i27) ? String.Empty : oleDbdr.GetString(i27);

                                    objReg.NumeroDocumentoOriginal = oleDbdr.IsDBNull(i28) ? String.Empty : oleDbdr.GetString(i28);

                                    objReg.Pago = oleDbdr.IsDBNull(i29) ? String.Empty : oleDbdr.GetString(i29);

                                    objReg.FechaPago = oleDbdr.IsDBNull(i30) ? DateTime.Parse("1900-01-01") : Formato.ObtieneFecha(oleDbdr.GetString(i30), "DD.MM.AAAA");

                                    objReg.Detraccion = oleDbdr.IsDBNull(i31) ? String.Empty : oleDbdr.GetString(i31);

                                    objReg.TasaDetraccion = oleDbdr.IsDBNull(i32) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i32));

                                    objReg.ImporteDetraccion = oleDbdr.IsDBNull(i33) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i33));

                                    objReg.Retencion = oleDbdr.IsDBNull(i34) ? String.Empty : oleDbdr.GetString(i34);

                                    objReg.ImporteRetencion = oleDbdr.IsDBNull(i35) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i35));

                                    objReg.MotivoRetencion = oleDbdr.IsDBNull(i36) ? String.Empty : oleDbdr.GetString(i36);

                                    objReg.RevisionTasa = oleDbdr.IsDBNull(i37) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i37));

                                    objReg.RevisionTipoCambio = oleDbdr.IsDBNull(i38) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i38));

                                    objReg.RevisionVerificacion = oleDbdr.IsDBNull(i39) ? String.Empty : oleDbdr.GetString(i39);

                                    objReg.BaseRevision = oleDbdr.IsDBNull(i40) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i40));

                                    objReg.IGVRevision = oleDbdr.IsDBNull(i41) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i41));

                                    objReg.TipoGasto = oleDbdr.IsDBNull(i42) ? String.Empty : oleDbdr.GetString(i42);

                                    objReg.Recepcion = oleDbdr.IsDBNull(i43) ? String.Empty : oleDbdr.GetString(i43);

                                    objReg.Comentario1 = oleDbdr.IsDBNull(i44) ? String.Empty : oleDbdr.GetString(i44);

                                    objReg.Comentario2 = oleDbdr.IsDBNull(i45) ? String.Empty : oleDbdr.GetString(i45);

                                    objReg.VB = oleDbdr.IsDBNull(i46) ? String.Empty : oleDbdr.GetString(i46);

                                    objReg.CompraGravadaPais = oleDbdr.IsDBNull(i47) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i47));

                                    objReg.CompraGravadaExterior = oleDbdr.IsDBNull(i48) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i48));

                                    objReg.CompraNoGravada = oleDbdr.IsDBNull(i49) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i49));

                                    objReg.IGVPais = oleDbdr.IsDBNull(i50) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i50));

                                    objReg.Exterior = oleDbdr.IsDBNull(i51) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i51));

                                    objReg.OtrosCargos = oleDbdr.IsDBNull(i52) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i52));

                                    objReg.Total1 = oleDbdr.IsDBNull(i53) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i53));

                                    numLinea++;

                                    lst.Add(objReg);
                                }
                            }
                        }
                    }
                }
            }

            return lst;
        }
    }
}
