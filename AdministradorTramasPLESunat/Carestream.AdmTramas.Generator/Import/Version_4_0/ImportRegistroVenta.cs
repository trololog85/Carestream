using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Interfaces;
using Carestream.AdmTramas.DataAccess.Repository.Versiones.Version_4_0;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Import.Version_4_0
{
    public class ImportRegistroVenta : IImportLibroRegistroVentas
    {
        private readonly ILibroLogRepository _libroLogRepository;

        public ImportRegistroVenta()
        {
            _libroLogRepository = new DALibroLog(new AdmTramasContainer());
        }

        public List<RegistroVenta> LeeRegistro(Model.Entities.Import import)
        {
            var query = Globals.queryVentas;

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

                        var i1 = oleDbdr.GetOrdinal("NumeroUnicoOperacion");
                        var i2 = oleDbdr.GetOrdinal("FechaComprobante");
                        var i3 = oleDbdr.GetOrdinal("TipoComprobante");
                        var i4 = oleDbdr.GetOrdinal("CodigoUnicoOperacion");
                        var i5 = oleDbdr.GetOrdinal("SerieComprobante");
                        var i6 = oleDbdr.GetOrdinal("NumeroComprobante");
                        var i7 = oleDbdr.GetOrdinal("TipoDocumento");
                        var i8 = oleDbdr.GetOrdinal("Ruc");
                        var i9 = oleDbdr.GetOrdinal("Codigo");
                        var i10 = oleDbdr.GetOrdinal("RazonSocial");
                        var i11 = oleDbdr.GetOrdinal("ValorVentaOriginal");
                        var i12 = oleDbdr.GetOrdinal("MonedaVenta");
                        var i13 = oleDbdr.GetOrdinal("TipoCambio");
                        var i27 = oleDbdr.GetOrdinal("valorventa");
                        var i14 = oleDbdr.GetOrdinal("VVExportaciones");
                        var i15 = oleDbdr.GetOrdinal("VVOperacionGravada");
                        var i16 = oleDbdr.GetOrdinal("IGV");
                        var i17 = oleDbdr.GetOrdinal("PrecioVenta");
                        var i18 = oleDbdr.GetOrdinal("OperacionNoGravada");
                        var i19 = oleDbdr.GetOrdinal("FechaComprobanteMod");
                        var i20 = oleDbdr.GetOrdinal("TipoComprobanteMod");
                        var i21 = oleDbdr.GetOrdinal("SerieComprobanteMod");
                        var i22 = oleDbdr.GetOrdinal("NumeroComprobanteMod");
                        var i23 = oleDbdr.GetOrdinal("VVGravadoMod");
                        var i24 = oleDbdr.GetOrdinal("IGVMod");
                        var i25 = oleDbdr.GetOrdinal("PVMod");
                        var i26 = oleDbdr.GetOrdinal("estado");

                        var objReg = new RegistroVenta();

                        var nLinea = 1;

                        while (oleDbdr.Read())
                        {
                            if (oleDbdr.IsDBNull(i1)) continue;

                            objReg = new RegistroVenta();

                            objReg.Numero = oleDbdr.GetString(i1);

                            objReg.FechaComprobante = oleDbdr.IsDBNull(i2)?
                                new DateTime(1900,1,1) : 
                                Formato.ObtieneFecha(oleDbdr.GetString(i2),
                                "DD.MM.AAAA");

                            objReg.TipoComprobante = oleDbdr.IsDBNull(i3)
                                ? String.Empty
                                : Math.Truncate(oleDbdr.GetDouble(i3)).ToString(CultureInfo.InvariantCulture);

                            objReg.NumeroUnicoOperacion = oleDbdr.IsDBNull(i4)
                                ? String.Empty
                                : oleDbdr.GetString(i4);

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
                                        : oleDbdr.GetDouble(i7).ToString(CultureInfo.InvariantCulture);
                            }

                            if (oleDbdr.IsDBNull(i8))
                            {
                                objReg.NumeroDocumento = String.Empty;
                            }
                            else
                            {
                                objReg.NumeroDocumento = oleDbdr.GetFieldType(i8).ToString() == "System.String"
                                    ? oleDbdr.GetString(i8)
                                    : Math.Truncate(oleDbdr.GetDouble(i8)).ToString(CultureInfo.InvariantCulture);
                            }

                            if (oleDbdr.IsDBNull(i9))
                            {
                                objReg.CodigoDocumento = String.Empty;
                            }
                            else
                            {
                                objReg.CodigoDocumento = oleDbdr.GetFieldType(i9).ToString() == "System.String"
                                    ? oleDbdr.GetString(i9)
                                    : Math.Truncate(oleDbdr.GetDouble(i9)).ToString(CultureInfo.InvariantCulture);
                            }

                            objReg.NombreRazonSocial = oleDbdr.IsDBNull(i10)
                                ? String.Empty
                                : oleDbdr.GetString(i10);

                            objReg.ValorVentaOriginal = oleDbdr.IsDBNull(i11)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i11));

                            objReg.Moneda = oleDbdr.IsDBNull(i12)
                                ? String.Empty
                                : oleDbdr.GetString(i12);

                            objReg.TipoCambio = oleDbdr.IsDBNull(i13)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i13));

                            objReg.VV = oleDbdr.IsDBNull(i27)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i27));

                            objReg.OperacionGravada = oleDbdr.IsDBNull(i15)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i15));

                            objReg.IGV = oleDbdr.IsDBNull(i16)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i16));

                            objReg.PV = oleDbdr.IsDBNull(i17)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i17));

                            objReg.OperacionNoGravada = oleDbdr.IsDBNull(i18)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i18));

                            objReg.FechaModificada = oleDbdr.IsDBNull(i19)
                                ? DateTime.Parse("1900-01-01")
                                : Formato.ObtieneFecha(oleDbdr.GetString(i19), "DD.MM.AAAA");

                            if (oleDbdr.IsDBNull(i20))
                            {
                                objReg.TipoComprobanteModificado = String.Empty;
                            }
                            else
                            {
                                objReg.TipoComprobanteModificado = oleDbdr.GetFieldType(i20).ToString() == "System.String"
                                    ? oleDbdr.GetString(i20)
                                    : oleDbdr.GetDouble(i20).ToString(CultureInfo.InvariantCulture);
                            }

                            objReg.NumeroSerieModificado = oleDbdr.IsDBNull(i21) ? String.Empty : oleDbdr.GetString(i21);

                            objReg.NumeroComprobanteModificado = oleDbdr.IsDBNull(i22) ? String.Empty : oleDbdr.GetString(i22);

                            objReg.VVModificado = oleDbdr.IsDBNull(i23)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i23));

                            objReg.IGVModificado = oleDbdr.IsDBNull(i24)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i24));

                            objReg.PVModificado = oleDbdr.IsDBNull(i25)
                                ? 0
                                : Convert.ToDecimal(oleDbdr.GetDouble(i25));

                            objReg.ValorEmbarcadoExportacion = 0;

                            objReg.OperacionGravada = 0;

                            objReg.estado = oleDbdr.IsDBNull(i26)
                            ? "1":
                            oleDbdr.GetString(i26);

                            objReg.Linea = nLinea;

                            nLinea++;

                            lst.Add(objReg);
                        }
                    }
                }
            }

            var periodo = import.Periodo;

            var lstSinCalculo = lst.Where(x => x.NumeroCorrelativo != null).ToList();

            var lstActualizado = ActualizaNumeroCorrelativo(lst, periodo);

            var anulados = ActualizaCorrelativoAnulado(lst);

            var total = new List<RegistroVenta>();

            total.AddRange(lstSinCalculo);
            total.AddRange(lstActualizado);
            total.AddRange(anulados);

            return total;
        }

        public List<RegistroVenta> ActualizaNumeroCorrelativo(List<RegistroVenta> registroVentas,DateTime periodo)
        {
            //1.Obtener los registros del diario del periodo
            var result = _libroLogRepository.ConsultaLibroDiarioPorPeriodo(periodo);

            //2.Obtiene las cuentas del tipo 70
            var filtro = VentasCuenta70(result);
            
            //3.Obtiene el maximo valor de cada grupo
            var maximos = (from grupo in filtro
                group grupo by new
                {
                    grupo.Fecha,
                    grupo.CodigoUnico,
                    grupo.Cuenta,
                    grupo.Centro,
                    grupo.Referencia,
                    grupo.DescripcionAsiento,
                    grupo.estado
                }
                into g
                select new LibroDiario()
                {
                    CodigoUnico = g.Key.CodigoUnico,
                    Correlativo = ParseCorrelativo(g.Max(x => GetCorrelativoEntero(x.Correlativo)))
                }
                ).ToList();

            //4.Asignar correlativo a registroventa
            var final = AsignaCorrelativo(maximos, registroVentas);

            return final;
        }

        public List<RegistroVenta> ActualizaCorrelativoAnulado(List<RegistroVenta> registroVentas)
        {
            var constanteAnulado = ConfigurationManager.AppSettings["NombreAnulado"];

            var lstAnulados = registroVentas.Where(x => x.NombreRazonSocial == constanteAnulado).ToList();

            short num = 1;

            foreach (var reg in lstAnulados)
            {
                reg.NumeroCorrelativo = ParseCorrelativo(num);
                num++;
            }

            return lstAnulados;
        }
    

        private static IEnumerable<LibroDiario> VentasCuenta70(IEnumerable<LibroDiario> result)
        {
            return result.Where(x => x.Cuenta == "7011100000").ToList();
        }

        private static short GetCorrelativoEntero(string correlativo)
        {
            var c = correlativo.Replace("M", "");

            return short.Parse(c);
        }

        private static string ParseCorrelativo(short num)
        {
            return Formato.GeneraCorrelativo(num);
        }

        private static List<RegistroVenta> AsignaCorrelativo(IEnumerable<LibroDiario> lstLibroDiarios,
            IEnumerable<RegistroVenta> lstRegistroVentas)
        {
            var nombreAnulado = ConfigurationManager.AppSettings["NombreAnulado"];

            var filtroVentas = lstRegistroVentas.Where(x => x.NombreRazonSocial != nombreAnulado).ToList();

            var joinQuery = from registroVenta in filtroVentas
                join libroDiario in lstLibroDiarios
                    on registroVenta.NumeroUnicoOperacion equals libroDiario.CodigoUnico
                select new RegistroVenta
                {
                    CodigoDocumento = registroVenta.CodigoDocumento,
                    FechaComprobante = registroVenta.FechaComprobante,
                    FechaModificada = registroVenta.FechaModificada,
                    FechaVencimiento = registroVenta.FechaVencimiento,
                    IGV = registroVenta.IGV,
                    IGVModificado = registroVenta.IGVModificado,
                    IdLibro = registroVenta.IdLibro,
                    IdLibroLog = registroVenta.IdLibroLog,
                    LibroLog = registroVenta.LibroLog,
                    Linea = registroVenta.Linea,
                    Moneda = registroVenta.Moneda,
                    NombreRazonSocial = registroVenta.NombreRazonSocial,
                    NumeroComprobante = registroVenta.NumeroComprobante,
                    NumeroComprobanteModificado = registroVenta.NumeroComprobanteModificado,
                    Numero = registroVenta.Numero,
                    NumeroDocumento = registroVenta.NumeroDocumento,
                    NumeroSerieModificado = registroVenta.NumeroSerieModificado,
                    NumeroUnicoOperacion = registroVenta.NumeroUnicoOperacion,
                    OperacionGravada = registroVenta.OperacionGravada,
                    OperacionNoGravada = registroVenta.OperacionNoGravada,
                    PV = registroVenta.PV,
                    PVModificado = registroVenta.PVModificado,
                    SerieComprobante = registroVenta.SerieComprobante,
                    TipoCambio = registroVenta.TipoCambio,
                    TipoComprobante = registroVenta.TipoComprobante,
                    TipoComprobanteModificado = registroVenta.TipoComprobanteModificado,
                    TipoDocumento = registroVenta.TipoDocumento,
                    VV = registroVenta.VV,
                    VVModificado = registroVenta.VVModificado,
                    ValorEmbarcadoExportacion = registroVenta.ValorEmbarcadoExportacion,
                    ValorVentaOriginal = registroVenta.ValorVentaOriginal,
                    estado = registroVenta.estado,
                    NumeroCorrelativo = libroDiario.Correlativo
                };

            var numeros = joinQuery.Select(x => x.Numero).ToList();

            var restantes = filtroVentas.Where(x => !numeros.Contains(x.Numero)).ToList();

            var total = new List<RegistroVenta>();

            total.AddRange(restantes);
            total.AddRange(joinQuery);

            return total;
        }
    }
}
