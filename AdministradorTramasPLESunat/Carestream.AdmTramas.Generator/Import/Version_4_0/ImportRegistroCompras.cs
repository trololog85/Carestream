using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Import.Version_4_0
{
    public class ImportRegistroCompras : IImportLibroRegistroCompras
    {
        public List<RegistroCompra> LeeRegistro(Model.Entities.Import import)
        {
            var query = Globals.queryCompras;

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
                                var i1 = oleDbdr.GetOrdinal("codigounicooperacion");
                                var i2 = oleDbdr.GetOrdinal("numerocorrelativo");
                                var i3 = oleDbdr.GetOrdinal("numerooperacion");
                                var i4 = oleDbdr.GetOrdinal("fechaemision");
                                var i5 = oleDbdr.GetOrdinal("fechavencimiento");
                                var i6 = oleDbdr.GetOrdinal("tipocomprobante");
                                var i7 = oleDbdr.GetOrdinal("numeroseriecomp");
                                var i8 = oleDbdr.GetOrdinal("anioemisioncomp");
                                var i9 = oleDbdr.GetOrdinal("numerocomp");
                                var i10 = oleDbdr.GetOrdinal("tipodocumento");
                                var i11 = oleDbdr.GetOrdinal("numerodocumento");
                                var i12 = oleDbdr.GetOrdinal("razonsocialcliente");
                                var i13 = oleDbdr.GetOrdinal("baseimponiblegrav");
                                var i14 = oleDbdr.GetOrdinal("igvgravado");
                                var i15 = oleDbdr.GetOrdinal("baseimponiblemix");
                                var i16 = oleDbdr.GetOrdinal("igvmixto");
                                var i17 = oleDbdr.GetOrdinal("baseimpnograv");
                                var i18 = oleDbdr.GetOrdinal("igvnograv");
                                var i19 = oleDbdr.GetOrdinal("adquisicionnograv");
                                var i20 = oleDbdr.GetOrdinal("isc");
                                var i21 = oleDbdr.GetOrdinal("otrostributos");
                                var i22 = oleDbdr.GetOrdinal("total");
                                var i23 = oleDbdr.GetOrdinal("comprobantenodomic");
                                var i24 = oleDbdr.GetOrdinal("numeroconstancia");
                                var i25 = oleDbdr.GetOrdinal("fechaemisionconst");
                                var i26 = oleDbdr.GetOrdinal("tipocambio");
                                var i27 = oleDbdr.GetOrdinal("fechaoriginal");
                                var i28 = oleDbdr.GetOrdinal("tipodocumentoorig");
                                var i29 = oleDbdr.GetOrdinal("seriedocumentoorig");
                                var i30 = oleDbdr.GetOrdinal("numerodocumentoorig");
                                var i31 = oleDbdr.GetOrdinal("pago");
                                var i32 = oleDbdr.GetOrdinal("fechapago");
                                var i33 = oleDbdr.GetOrdinal("detraccion");
                                var i34 = oleDbdr.GetOrdinal("tasadetraccion");
                                var i35 = oleDbdr.GetOrdinal("importedetraccion");
                                var i36 = oleDbdr.GetOrdinal("motivoretencion");
                                var i37 = oleDbdr.GetOrdinal("retencion");
                                var i38 = oleDbdr.GetOrdinal("importeretencion");
                                var i39 = oleDbdr.GetOrdinal("revisiontasa");
                                var i40 = oleDbdr.GetOrdinal("revisiontipocambio");
                                var i41 = oleDbdr.GetOrdinal("revisionverificacion");
                                var i42 = oleDbdr.GetOrdinal("baserevision");
                                var i43 = oleDbdr.GetOrdinal("igvrevision");
                                var i44 = oleDbdr.GetOrdinal("tipogasto");
                                var i45 = oleDbdr.GetOrdinal("recepcion");
                                var i46 = oleDbdr.GetOrdinal("comentario1");
                                var i47 = oleDbdr.GetOrdinal("comentario2");
                                var i48 = oleDbdr.GetOrdinal("vb");
                                var i49 = oleDbdr.GetOrdinal("compragravadapais");
                                var i50 = oleDbdr.GetOrdinal("compragravadaexterior");
                                var i51 = oleDbdr.GetOrdinal("compranogravada");
                                var i52 = oleDbdr.GetOrdinal("igvpais");
                                var i53 = oleDbdr.GetOrdinal("exterior");
                                var i54 = oleDbdr.GetOrdinal("otroscargos");
                                var i55 = oleDbdr.GetOrdinal("total1");
                                var i56 = oleDbdr.GetOrdinal("estado");
                                var i57 = oleDbdr.GetOrdinal("clasificacionbien");

                                var objReg = new RegistroCompra();

                                var numLinea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (oleDbdr.IsDBNull(i3)) continue;
                                    objReg = new RegistroCompra();

                                    objReg.Linea = numLinea;

                                    objReg.codigounicooperacion = oleDbdr.GetString(i1);
                                    objReg.numerocorrelativo = oleDbdr.IsDBNull(i2)?
                                        String.Empty:oleDbdr.GetString(i2);
                                    objReg.NumeroOperacion = oleDbdr.GetString(i3);
                                    objReg.FechaEmision = Formato.ObtieneFecha(oleDbdr.GetString(i4), "DD.MM.AAAA");

                                    objReg.FechaVencimiento = oleDbdr.IsDBNull(i5) ? 
                                        DateTime.Parse("1900-01-01") : Formato.ObtieneFecha(oleDbdr.GetString(i5), "DD.MM.AAAA");

                                    objReg.TipoComprobante = oleDbdr.IsDBNull(i6) ? 
                                        String.Empty : oleDbdr.GetString(i6);

                                    objReg.NumeroSerieComprobante = oleDbdr.IsDBNull(i7) ? 
                                        String.Empty : oleDbdr.GetString(i7);

                                    objReg.AnioEmisionComprobante = oleDbdr.IsDBNull(i8) ? 
                                        String.Empty : oleDbdr.GetString(i8);

                                    objReg.NumeroComprobante = oleDbdr.GetString(i9);

                                    objReg.TipoDocumento = oleDbdr.IsDBNull(i10) ? 
                                        String.Empty : oleDbdr.GetString(i10);

                                    objReg.NumeroDocumento = oleDbdr.IsDBNull(i11) ? 
                                        String.Empty : Convert.ToInt64(oleDbdr.GetDouble(i11)).ToString(CultureInfo.InvariantCulture);

                                    objReg.NombreRazonSocial = oleDbdr.GetString(i12);

                                    objReg.BaseImponibleGravada = oleDbdr.IsDBNull(i13) ? 
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i13));

                                    objReg.IGVGravado = Convert.ToDecimal(oleDbdr.GetDouble(i14));

                                    objReg.BaseImponibleMixta = oleDbdr.IsDBNull(i15) ? 
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i15));

                                    objReg.IGVMixto = oleDbdr.IsDBNull(i16) ? 
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i16));

                                    objReg.BaseImponibleNoGravada = oleDbdr.IsDBNull(i17) ? 
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i17));

                                    objReg.IGVNoGravado = oleDbdr.IsDBNull(i18) ? 
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i18));

                                    objReg.AdquisicionNoGravada = oleDbdr.IsDBNull(i19) ? 
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i19));

                                    objReg.ISC = oleDbdr.IsDBNull(i20) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i20));

                                    objReg.OtrosTributos = oleDbdr.IsDBNull(i21) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i21));

                                    objReg.Total = Convert.ToDecimal(oleDbdr.GetDouble(i22));

                                    objReg.ComprobanteNoDomiciliado = oleDbdr.IsDBNull(i23) ?
                                        String.Empty : oleDbdr.GetString(i23);

                                    if (oleDbdr.IsDBNull(i24))
                                    {
                                        objReg.NumeroConstancia = String.Empty;
                                    }
                                    else
                                    {
                                        objReg.NumeroConstancia = oleDbdr.GetFieldType(i24).ToString() == "System.Double" ?
                                            Convert.ToInt64(oleDbdr.GetDouble(i24)).ToString() : oleDbdr.GetString(i24);
                                    }

                                    objReg.FechaEmisionConstancia = oleDbdr.IsDBNull(i25) ?
                                        DateTime.Parse("1900-01-01") : Formato.ObtieneFecha(oleDbdr.GetString(i25), "DD.MM.AAAA");

                                    objReg.TipoCambio = oleDbdr.IsDBNull(i26) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i26));

                                    objReg.FechaOriginal = oleDbdr.IsDBNull(i27) ? 
                                        DateTime.Parse("1900-01-01") : Formato.ObtieneFecha(oleDbdr.GetString(i27), "DD.MM.AAAA");

                                    objReg.TipoDocumentoOriginal = oleDbdr.IsDBNull(i28) ?
                                        String.Empty : oleDbdr.GetString(i28);

                                    objReg.NumeroSerieOriginal = oleDbdr.IsDBNull(i29) ?
                                        String.Empty : oleDbdr.GetString(i29);

                                    objReg.NumeroDocumentoOriginal = oleDbdr.IsDBNull(i30) ?
                                        String.Empty : oleDbdr.GetString(i30);

                                    objReg.Pago = oleDbdr.IsDBNull(i31) ?
                                        String.Empty : oleDbdr.GetString(i31);

                                    objReg.FechaPago = oleDbdr.IsDBNull(i32) ?
                                        DateTime.Parse("1900-01-01") : Formato.ObtieneFecha(oleDbdr.GetString(i32), "DD.MM.AAAA");

                                    objReg.Detraccion = oleDbdr.IsDBNull(i33) ?
                                        String.Empty : oleDbdr.GetString(i33);

                                    objReg.TasaDetraccion = oleDbdr.IsDBNull(i34) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i34));

                                    objReg.ImporteDetraccion = oleDbdr.IsDBNull(i35) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i35));

                                    objReg.Retencion = oleDbdr.IsDBNull(i36) ?
                                        String.Empty : oleDbdr.GetString(i36);

                                    objReg.ImporteRetencion = oleDbdr.IsDBNull(i37) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i37));

                                    objReg.MotivoRetencion = oleDbdr.IsDBNull(i38) ?
                                        String.Empty : oleDbdr.GetString(i38);

                                    objReg.RevisionTasa = oleDbdr.IsDBNull(i39) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i39));

                                    objReg.RevisionTipoCambio = oleDbdr.IsDBNull(i40) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i40));

                                    objReg.RevisionVerificacion = oleDbdr.IsDBNull(i41) ?
                                        String.Empty : oleDbdr.GetString(i41);

                                    objReg.BaseRevision = oleDbdr.IsDBNull(i42) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i42));

                                    objReg.IGVRevision = oleDbdr.IsDBNull(i43) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i43));

                                    objReg.TipoGasto = oleDbdr.IsDBNull(i44) ?
                                        String.Empty : oleDbdr.GetString(i44);

                                    objReg.Recepcion = oleDbdr.IsDBNull(i45) ?
                                        String.Empty : oleDbdr.GetString(i45);

                                    objReg.Comentario1 = oleDbdr.IsDBNull(i46) ?
                                        String.Empty : oleDbdr.GetString(i46);

                                    objReg.Comentario2 = oleDbdr.IsDBNull(i47) ?
                                        String.Empty : oleDbdr.GetString(i47);

                                    objReg.VB = oleDbdr.IsDBNull(i48) ?
                                        String.Empty : oleDbdr.GetString(i48);

                                    objReg.CompraGravadaPais = oleDbdr.IsDBNull(i49) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i49));

                                    objReg.CompraGravadaExterior = oleDbdr.IsDBNull(i50) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i50));

                                    objReg.CompraNoGravada = oleDbdr.IsDBNull(i51) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i51));

                                    objReg.IGVPais = oleDbdr.IsDBNull(i52) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i52));

                                    objReg.Exterior = oleDbdr.IsDBNull(i53) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i53));

                                    objReg.OtrosCargos = oleDbdr.IsDBNull(i54) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i54));

                                    objReg.Total1 = oleDbdr.IsDBNull(i55) ?
                                        0 : Convert.ToDecimal(oleDbdr.GetDouble(i55));

                                    objReg.Estado = oleDbdr.IsDBNull(i56) ?
                                        "1" : oleDbdr.GetString(i56);

                                    objReg.ClasificacionBien1 = oleDbdr.GetString(i57);

                                    objReg.DUA = String.Empty;

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
