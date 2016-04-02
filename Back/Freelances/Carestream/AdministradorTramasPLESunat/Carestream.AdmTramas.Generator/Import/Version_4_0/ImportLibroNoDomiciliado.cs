using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Import.Version_4_0
{
    public class ImportLibroNoDomiciliado : IImportLibroNoDomiciliado
    {
        public List<RegistroNoDomiciliado> LeeRegistro(Model.Entities.Import import)
        {
            var query = Globals.queryNoDomiciliado;

            var lst = new List<RegistroNoDomiciliado>();

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
                                var i1 = oleDbdr.GetOrdinal("Periodo");
                                var i2 = oleDbdr.GetOrdinal("CUO");
                                var i3 = oleDbdr.GetOrdinal("NumeroCorrelativo");
                                var i4 = oleDbdr.GetOrdinal("FechaEmisionComprobante");
                                var i5 = oleDbdr.GetOrdinal("TipoComprobante");
                                var i6 = oleDbdr.GetOrdinal("SerieComprobante");
                                var i7 = oleDbdr.GetOrdinal("NumeroComprobante");
                                var i8 = oleDbdr.GetOrdinal("ValorAdquisicion");
                                var i9 = oleDbdr.GetOrdinal("OtrosConceptos");
                                var i10 = oleDbdr.GetOrdinal("ImporteTotal");
                                var i11 = oleDbdr.GetOrdinal("TipoComprobanteCreditoFiscal");
                                var i12 = oleDbdr.GetOrdinal("SerieComprobanteCreditoFiscal");
                                var i13 = oleDbdr.GetOrdinal("AnoEmisionDUA");
                                var i14 = oleDbdr.GetOrdinal("NumeroComprobanteDUA");
                                var i15 = oleDbdr.GetOrdinal("IGV");
                                var i16 = oleDbdr.GetOrdinal("Moneda");
                                var i17 = oleDbdr.GetOrdinal("TipoCambio");
                                var i18 = oleDbdr.GetOrdinal("Pais");
                                var i19 = oleDbdr.GetOrdinal("RazonSocial");
                                var i20 = oleDbdr.GetOrdinal("Domicilio");
                                var i21 = oleDbdr.GetOrdinal("NumeroIdentificacionSujeto");
                                var i22 = oleDbdr.GetOrdinal("NumeroIdentificacionFiscal");
                                var i23 = oleDbdr.GetOrdinal("RazonSocialBeneficiario");
                                var i24 = oleDbdr.GetOrdinal("PaisBeneficiario");
                                var i25 = oleDbdr.GetOrdinal("Vinculo");
                                var i26 = oleDbdr.GetOrdinal("RentaBruta");
                                var i27 = oleDbdr.GetOrdinal("Deduccion");
                                var i28 = oleDbdr.GetOrdinal("RentaNeta");
                                var i29 = oleDbdr.GetOrdinal("TasaRetencion");
                                var i30 = oleDbdr.GetOrdinal("ImpuestoRetenido");
                                var i31 = oleDbdr.GetOrdinal("Convenio");
                                var i32 = oleDbdr.GetOrdinal("ExoneracionAplicada");
                                var i33 = oleDbdr.GetOrdinal("TipoRenta");
                                var i34 = oleDbdr.GetOrdinal("ServicioPrestado");
                                var i35 = oleDbdr.GetOrdinal("CampoArt76");
                                var i36 = oleDbdr.GetOrdinal("Estado");

                                var objReg = new RegistroNoDomiciliado();

                                var numLinea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (oleDbdr.IsDBNull(i1)) continue;
                                    objReg = new RegistroNoDomiciliado();

                                    objReg.Linea = numLinea;
                                    objReg.Periodo = oleDbdr.GetString(i1);
                                    objReg.CUO = oleDbdr.GetString(i2);
                                    objReg.NumeroCorrelativo = oleDbdr.GetString(i3);
                                    objReg.FechaEmision = oleDbdr.GetDateTime(i4);
                                    objReg.TipoComprobante = oleDbdr.GetString(i5);
                                    objReg.NumeroSerieComprobante = oleDbdr.GetString(i6);
                                    objReg.NumeroComprobante = oleDbdr.GetString(i7);
                                    objReg.ValorAdquisicion = oleDbdr.GetDecimal(i8);
                                    objReg.OtrosConceptos = oleDbdr.GetDecimal(i9);
                                    objReg.ImporteTotalAdquisicion = oleDbdr.GetDecimal(i10);
                                    objReg.TipoComprobanteFiscal = oleDbdr.GetString(i11);
                                    objReg.NumeroSerieComprobanteFiscal = oleDbdr.GetString(i12);
                                    objReg.AnioEmisionDUA = oleDbdr.GetString(i13);
                                    objReg.NumeroComprobanteDUA = oleDbdr.GetString(i14);
                                    objReg.IGV = oleDbdr.GetDecimal(i15);
                                    objReg.Moneda = oleDbdr.GetString(i16);
                                    objReg.TipoCambio = oleDbdr.GetDecimal(i17);
                                    objReg.Pais = oleDbdr.GetString(i18);
                                    objReg.RazonSocial = oleDbdr.GetString(i19);
                                    objReg.Domicilio = oleDbdr.GetString(i20);
                                    objReg.NumeroIdentificacionSujeto = oleDbdr.GetString(i21);
                                    objReg.NumeroIdentificacionFiscal = oleDbdr.GetString(i22);
                                    objReg.RazonSocialBeneficiario = oleDbdr.GetString(i23);
                                    objReg.PaisBeneficiario = oleDbdr.GetString(i24);
                                    objReg.Vinculo = oleDbdr.GetString(i25);
                                    objReg.RentaBruta = oleDbdr.GetDecimal(i26);
                                    objReg.Deduccion = oleDbdr.GetDecimal(i27);
                                    objReg.RentaNeta = oleDbdr.GetDecimal(i28);
                                    objReg.TasaRetencion = oleDbdr.GetDecimal(i29);
                                    objReg.ImpuestoRetenido = oleDbdr.GetDecimal(i30);
                                    objReg.Convenio = oleDbdr.GetString(i31);
                                    objReg.ExoneracionAplicada = oleDbdr.GetString(i32);
                                    objReg.TipoRenta = oleDbdr.GetString(i33);
                                    objReg.ServicioPrestado = oleDbdr.GetString(i34);


                                    objReg.Campo35 = oleDbdr.GetString(i34);

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