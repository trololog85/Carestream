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
    public class ImportLibroMayor : IImportLibroMayor
    {
        public List<LibroMayor> LeeRegistro(Model.Entities.Import import)
        {
            const string query =
                "select NUMDOC,TIPO,FECHAOPE,IMPORTE,SUBTOTAL,CUENTA,GL,DEBITO,CREDITO,SALDO,REFERENCIA,ITEM,DESCRIPCION,GLOSA from [sheet1$]";

            var lst = new List<LibroMayor>();

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
                                var i1 = oleDbdr.GetOrdinal("NUMDOC");
                                var i2 = oleDbdr.GetOrdinal("TIPO");
                                var i3 = oleDbdr.GetOrdinal("FECHAOPE");
                                var i4 = oleDbdr.GetOrdinal("IMPORTE");
                                var i5 = oleDbdr.GetOrdinal("SUBTOTAL");
                                var i6 = oleDbdr.GetOrdinal("CUENTA");
                                var i7 = oleDbdr.GetOrdinal("GL");
                                var i8 = oleDbdr.GetOrdinal("DEBITO");
                                var i9 = oleDbdr.GetOrdinal("CREDITO");
                                var i10 = oleDbdr.GetOrdinal("SALDO");
                                var i11 = oleDbdr.GetOrdinal("REFERENCIA");
                                var i12 = oleDbdr.GetOrdinal("ITEM");
                                var i13 = oleDbdr.GetOrdinal("DESCRIPCION");
                                var i14 = oleDbdr.GetOrdinal("GLOSA");

                                var obj = new LibroMayor();

                                var numLinea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (oleDbdr.IsDBNull(i1)) continue;
                                    obj = new LibroMayor();

                                    obj.Linea = numLinea;

                                    //obj.NumeroDocumento = Convert.ToInt64(oleDbdr.GetDouble(i1)).ToString();

                                    //obj.Tipo = oleDbdr.IsDBNull(i2) ? String.Empty : oleDbdr.GetString(i2);

                                    //obj.FechaOperacion = oleDbdr.IsDBNull(i3)
                                    //    ? DateTime.Parse("1900-01-01")
                                    //    : Formato.ObtieneFecha(oleDbdr.GetString(i3), "DD.MM.AAAA");

                                    //if (oleDbdr.IsDBNull(i4))
                                    //{
                                    //    obj.Importe = -1;
                                    //}
                                    //else
                                    //{
                                    //    obj.Importe = Convert.ToDecimal(oleDbdr.GetDouble(i4));
                                    //}

                                    //obj.SubTotal = oleDbdr.IsDBNull(i5) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i5));

                                    //obj.Cuenta = oleDbdr.IsDBNull(i6)
                                    //    ? String.Empty
                                    //    : Convert.ToInt64(oleDbdr.GetDouble(i6)).ToString(CultureInfo.InvariantCulture);

                                    //obj.GL = oleDbdr.IsDBNull(i7)
                                    //    ? String.Empty
                                    //    : Convert.ToInt64(oleDbdr.GetDouble(i7)).ToString(CultureInfo.InvariantCulture);

                                    //obj.Debito = oleDbdr.IsDBNull(i8) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i8));

                                    //obj.Credito = oleDbdr.IsDBNull(i9) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i9));

                                    //obj.Saldo = oleDbdr.IsDBNull(i10) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i10));

                                    //obj.Referencia = oleDbdr.IsDBNull(i11) ? String.Empty : oleDbdr.GetString(i11);

                                    //obj.Item = oleDbdr.IsDBNull(i12)
                                    //    ? String.Empty
                                    //    : oleDbdr.GetDouble(i12).ToString(CultureInfo.InvariantCulture);

                                    //obj.Descripcion = oleDbdr.IsDBNull(i13) ? String.Empty : oleDbdr.GetString(i13);

                                    obj.Glosa = oleDbdr.IsDBNull(i14)
                                        ? String.Empty
                                        : Convert.ToInt64(oleDbdr.GetDouble(i14)).ToString();

                                    numLinea++;

                                    lst.Add(obj);
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