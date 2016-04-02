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
    public class ImportLibroDiarioDetalle : IImportLibroDiarioDetalle
    {
        public List<LibroDiarioDetalle> LeeRegistro(Model.Entities.Import import)
        {
            var query = Globals.queryDiarioDetalle;

            var lst = new List<LibroDiarioDetalle>();

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
                                var i2 = oleDbdr.GetOrdinal("CuentaContable");
                                var i3 = oleDbdr.GetOrdinal("DescripcionCuenta");
                                var i4 = oleDbdr.GetOrdinal("CodPlanContable");
                                var i5 = oleDbdr.GetOrdinal("DescPlanContable");
                                var i6 = oleDbdr.GetOrdinal("Estado");
                                
                                var objReg = new LibroDiarioDetalle();

                                var numLinea = 1;

                                while (oleDbdr.Read())
                                {
                                    if (oleDbdr.IsDBNull(i1)) continue;
                                    objReg = new LibroDiarioDetalle();

                                    objReg.Linea = numLinea;

                                    objReg.Periodo = oleDbdr.GetDateTime(i1);

                                    objReg.CuentaContable = oleDbdr.GetString(i2);

                                    objReg.DescripcionCuenta = oleDbdr.GetString(i3);

                                    objReg.CodigoPlanCuenta = oleDbdr.GetString(i4);

                                    objReg.DescripcionPlanCuenta = oleDbdr.IsDBNull(i5) ? String.Empty : oleDbdr.GetString(i5);

                                    objReg.Estado = oleDbdr.IsDBNull(i6)
                                        ? String.Empty
                                        : oleDbdr.GetString(i6);

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