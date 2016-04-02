using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Import.Version_4_0
{
    public class ImportLibroMayor : IImportLibroMayor
    {
        public List<LibroMayor> LeeRegistro(Model.Entities.Import import)
        {
            var query = Globals.queryLibroMayor;

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
                                var i1 = oleDbdr.GetOrdinal("periodo");
                                var i2 = oleDbdr.GetOrdinal("CUO");
                                var i3 = oleDbdr.GetOrdinal("Correlativo");
                                var i4 = oleDbdr.GetOrdinal("CodigoPlanCuenta");
                                var i5 = oleDbdr.GetOrdinal("CodigoCuentaContable");
                                var i6 = oleDbdr.GetOrdinal("FechaOperacion");
                                var i7 = oleDbdr.GetOrdinal("Glosa");
                                var i8 = oleDbdr.GetOrdinal("Debe");
                                var i9 = oleDbdr.GetOrdinal("Haber");
                                var i10 = oleDbdr.GetOrdinal("CuoVentas");
                                var i11 = oleDbdr.GetOrdinal("CuoCompras");
                                var i12 = oleDbdr.GetOrdinal("CuoConsignaciones");
                                var i13 = oleDbdr.GetOrdinal("Estado");

                                var obj = new LibroMayor();

                                var numLinea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (oleDbdr.IsDBNull(i3)) continue;
                                    obj = new LibroMayor();

                                    obj.Linea = numLinea;

                                    obj.Periodo = oleDbdr.GetString(i1);

                                    obj.codunicooperacion = oleDbdr.GetString(i2);

                                    obj.NumeroCorrelativo = oleDbdr.GetString(i3);

                                    obj.CodigoPlanCuenta = oleDbdr.GetString(i4);

                                    obj.CodigoCuentaContable = oleDbdr.GetString(i5);

                                    obj.FechaOperacion = oleDbdr.GetDataTypeName(i6) == "DBTYPE_WVARCHAR"
                                        ? Formato.ObtieneFecha(oleDbdr.GetString(i6),"DD/MM/AAAA")
                                        : oleDbdr.GetDateTime(i6);
                                    Debug.Print(numLinea.ToString());

                                    obj.Glosa = oleDbdr.GetString(i7);

                                    obj.Debe = oleDbdr.IsDBNull(i8) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i8));

                                    obj.Haber = oleDbdr.IsDBNull(i9) ? 0 : Convert.ToDecimal(oleDbdr.GetDouble(i9));

                                    obj.CuoVentas = oleDbdr.IsDBNull(i10) ? String.Empty : oleDbdr.GetString(i10);

                                    obj.CuoCompras = oleDbdr.IsDBNull(i11) ? String.Empty : oleDbdr.GetString(i11);

                                    obj.CuoConsignaciones = oleDbdr.IsDBNull(i12) ? String.Empty : oleDbdr.GetString(i12);

                                    obj.Estado = oleDbdr.IsDBNull(i13) ? String.Empty : oleDbdr.GetString(i13);

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
