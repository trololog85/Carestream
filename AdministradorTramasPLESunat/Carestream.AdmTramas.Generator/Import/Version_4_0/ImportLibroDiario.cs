using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Import.Version_4_0
{
    public class ImportLibroDiario : IImportLibroDiario
    {
        public List<LibroDiario> LeeRegistro(Model.Entities.Import import)
        {
            var query = Globals.queryLibroDiario;

            var lst = new List<LibroDiario>();

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
                                var i1 = oleDbdr.GetOrdinal("fecha");
                                var i2 = oleDbdr.GetOrdinal("NumeroCorrelativo");
                                var i3 = oleDbdr.GetOrdinal("CodigoUnicoOperacion");
                                var i4 = oleDbdr.GetOrdinal("Referencia");
                                var i5 = oleDbdr.GetOrdinal("Cuenta");
                                var i6 = oleDbdr.GetOrdinal("Centro");
                                var i7 = oleDbdr.GetOrdinal("DescripcionAsiento");
                                var i8 = oleDbdr.GetOrdinal("DEBE");
                                var i9 = oleDbdr.GetOrdinal("HABER");
                                var i10 = oleDbdr.GetOrdinal("Correlativo");
                                var i11 = oleDbdr.GetOrdinal("estado");

                                var objReg = new LibroDiario();

                                var numLinea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (oleDbdr.IsDBNull(i1)) continue;
                                    objReg = new LibroDiario();

                                    objReg.Linea = numLinea;

                                    objReg.Fecha = oleDbdr.GetDateTime(i1);

                                    objReg.NumeroCorrelativo = Convert.ToInt32(oleDbdr.GetDouble(i2));

                                    objReg.CodigoUnico = oleDbdr.GetString(i3);

                                    objReg.Referencia = oleDbdr.IsDBNull(i4) ? String.Empty : oleDbdr.GetString(i4);

                                    objReg.Cuenta = oleDbdr.IsDBNull(i5) ? string.Empty : oleDbdr.GetString(i5);

                                    objReg.Centro = oleDbdr.IsDBNull(i6) ? String.Empty : oleDbdr.GetString(i6);

                                    objReg.DescripcionAsiento = oleDbdr.IsDBNull(i7) ? String.Empty : oleDbdr.GetString(i7);
                                    
                                    objReg.Debe = oleDbdr.IsDBNull(i8) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i8));

                                    objReg.Haber = oleDbdr.IsDBNull(i9) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i9));

                                    objReg.Correlativo = oleDbdr.IsDBNull(i10)? String.Empty: oleDbdr.GetString(i10);

                                    objReg.estado = oleDbdr.IsDBNull(i11)
                                        ? "1"
                                        : Convert.ToInt16(oleDbdr.GetDouble(i11)).ToString(CultureInfo.InvariantCulture);

                                    numLinea++;

                                    lst.Add(objReg);
                                }
                            }
                        }
                    }
                }
            }

            return ActualizaCorrelativo(lst);
        }

        private List<LibroDiario> ActualizaCorrelativo(IEnumerable<LibroDiario> libroDiarios)
        {
            var resto = libroDiarios.Where(x => x.Cuenta != "7011100000");
            var c70 = AgrupaCuenta70(libroDiarios);

            var total = new List<LibroDiario>();
            total.AddRange(resto);
            total.AddRange(c70);

            var final = new List<LibroDiario>();


            var agrupado = (from grp in total
                            group grp by grp.CodigoUnico
                                into g
                                select g).ToList();

            var contador = (short)1;

            foreach (var grupo in agrupado)
            {
                foreach (var registro in grupo)
                {
                    registro.Correlativo = Formato.GeneraCorrelativo(contador,registro.Correlativo);
                    contador++;
                    final.Add(registro);
                }

                contador = 1;
            }

            return final;
        }

        private IEnumerable<LibroDiario> AgrupaCuenta70(IEnumerable<LibroDiario> registros)
        {
            var result = new List<LibroDiario>();

            var cuentas70 = registros.Where(x => x.Cuenta == "7011100000");
            var cuentas70Debe = cuentas70.Where(x => x.Haber == 0);
            var cuentas70Haber = cuentas70.Where(x => x.Debe == 0);

            var cuos = cuentas70.GroupBy(c => c.CodigoUnico).Select(x => x.Key);

            var sumarizadoDebe = (from grupo in cuentas70Debe
                              group grupo by new
                              {
                                  grupo.Fecha,
                                  grupo.CodigoUnico,
                                  grupo.Cuenta,
                                  grupo.Centro,
                                  grupo.Referencia,
                                  grupo.DescripcionAsiento,
                                  grupo.estado,
                                  grupo.Correlativo
                              }
                                  into g
                                  select new LibroDiario()
                                  {
                                      Centro = g.Key.Centro,
                                      CodigoUnico = g.Key.CodigoUnico,
                                      Cuenta = g.Key.Cuenta,
                                      Debe = g.Sum(x=>x.Debe),
                                      Haber = g.Sum(x=>x.Haber),
                                      DescripcionAsiento = g.Key.DescripcionAsiento,
                                      Referencia = g.Key.Referencia,
                                      Fecha = g.Key.Fecha,
                                      estado = g.Key.estado,
                                      Correlativo = g.Key.Correlativo
                                  }).ToList();

            var sumarizadoHaber = (from grupo in cuentas70Haber
                                  group grupo by new
                                  {
                                      grupo.Fecha,
                                      grupo.CodigoUnico,
                                      grupo.Cuenta,
                                      grupo.Centro,
                                      grupo.Referencia,
                                      grupo.DescripcionAsiento,
                                      grupo.estado,
                                      grupo.Correlativo
                                  }
                                      into g
                                      select new LibroDiario()
                                      {
                                          Centro = g.Key.Centro,
                                          CodigoUnico = g.Key.CodigoUnico,
                                          Cuenta = g.Key.Cuenta,
                                          Debe = g.Sum(x => x.Debe),
                                          Haber = g.Sum(x => x.Haber),
                                          DescripcionAsiento = g.Key.DescripcionAsiento,
                                          Referencia = g.Key.Referencia,
                                          Fecha = g.Key.Fecha,
                                          estado = g.Key.estado,
                                          Correlativo = g.Key.Correlativo
                                      }).ToList();

            decimal diferencia = 0;

            foreach (var registro in cuos)
            {
                var debe = sumarizadoDebe.FirstOrDefault(r => r.CodigoUnico == registro);
                var haber = sumarizadoHaber.FirstOrDefault(r => r.CodigoUnico == registro);

                if (debe != null && haber != null)
                {
                    diferencia = debe.Debe - haber.Haber;

                    if (diferencia > 0)
                    {
                        debe.Debe = diferencia;
                        debe.Haber = 0;
                        result.Add(debe);
                    }
                    else
                    {
                        haber.Haber = diferencia*-1;
                        haber.Debe = 0;
                        result.Add(haber);
                    }
                }
                else
                {
                    if(debe!=null)
                        result.Add(debe);

                    if(haber!=null)
                        result.Add(haber);
                }
            }

            return result;
        }
    }
}
