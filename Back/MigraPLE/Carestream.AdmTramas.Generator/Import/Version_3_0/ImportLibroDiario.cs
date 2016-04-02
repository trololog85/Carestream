using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Import.Version_3_0
{
    public class ImportLibroDiario
    {
        public List<LibroDiario> LeeRegistro(Model.Entities.Import import)
        {
            const string query = "select fecha,numcorre,codigounico,referencia,cuenta,centro,descasent,debe,haber from [sheet1$]";

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
                                var i2 = oleDbdr.GetOrdinal("numcorre");
                                var i3 = oleDbdr.GetOrdinal("codigounico");
                                var i4 = oleDbdr.GetOrdinal("referencia");
                                var i5 = oleDbdr.GetOrdinal("cuenta");
                                var i6 = oleDbdr.GetOrdinal("centro");
                                var i7 = oleDbdr.GetOrdinal("descasent");
                                var i8 = oleDbdr.GetOrdinal("debe");
                                var i9 = oleDbdr.GetOrdinal("haber");

                                var objReg = new LibroDiario();

                                var numLinea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (oleDbdr.IsDBNull(i1)) continue;
                                    objReg = new LibroDiario();

                                    objReg.Linea = numLinea;

                                    objReg.Centro = oleDbdr.IsDBNull(i6) ? String.Empty : Convert.ToInt32(oleDbdr.GetDouble(i6)).ToString();

                                    objReg.CodigoUnico = Convert.ToInt64(oleDbdr.GetDouble(i3)).ToString();

                                    objReg.Cuenta = oleDbdr.IsDBNull(i5) ? String.Empty : Convert.ToInt64(oleDbdr.GetDouble(i5)).ToString();

                                    objReg.Debe = oleDbdr.IsDBNull(i8) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i8));

                                    objReg.DescripcionAsiento = oleDbdr.IsDBNull(i7) ? String.Empty : oleDbdr.GetString(i7);

                                    objReg.Fecha = oleDbdr.GetDateTime(i1);

                                    objReg.Haber = oleDbdr.IsDBNull(i9) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i9));

                                    objReg.NumeroCorrelativo = Convert.ToInt32(oleDbdr.GetDouble(i2));

                                    objReg.Referencia = oleDbdr.IsDBNull(i4) ? String.Empty : oleDbdr.GetString(i4);

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
