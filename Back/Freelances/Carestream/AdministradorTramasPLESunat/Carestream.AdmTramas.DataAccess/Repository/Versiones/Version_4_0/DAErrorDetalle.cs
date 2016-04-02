using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;
using ErrorLinea = Carestream.AdmTramas.DataAccess.Model.ErrorLinea;

namespace Carestream.AdmTramas.DataAccess.Repository.Versiones.Version_4_0
{
    public class DAErrorDetalle
    {
        private readonly AdmTramasContainer context;

        private bool disposed = false;

        public DAErrorDetalle(AdmTramasContainer context)
        {
            this.context = context;
        }

        public List<ErrorLinea> Listar(int idLibroLog)
        {
            var lst = new List<ErrorLinea>();

            using (context)
            {
                return context.ConsultaErroresPorLog(idLibroLog).ToList();
            }
        }

        public void GuardarErrorDetalle(List<Error> errores, int idlLibroLog)
        {
            var dt = new DataTable();

            var dc1 = new DataColumn("idlibrolog");
            var dc2 = new DataColumn("linea");
            var dc3 = new DataColumn("campo");
            var dc4 = new DataColumn("descripcion");

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);

            var dr = dt.NewRow();

            var errorDetalles = errores.SelectMany(x => x.Detalles);

            foreach (var error in errorDetalles)
            {
                dr = dt.NewRow();

                dr["linea"] = error.Linea;
                dr["campo"] = error.Campo;
                dr["idLibroLog"] = idlLibroLog;
                dr["descripcion"] = error.Mensaje;

                dt.Rows.Add(dr);
            }

            using (var sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (var sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.ErrorLineas";

                    var linea = new SqlBulkCopyColumnMapping("Linea",
                        "Linea");
                    sqlBlk.ColumnMappings.Add(linea);

                    var campo = new SqlBulkCopyColumnMapping("Campo",
                        "Campo");
                    sqlBlk.ColumnMappings.Add(campo);

                    var idLibroLog = new SqlBulkCopyColumnMapping("IdLibroLog",
                        "IdLibroLog");
                    sqlBlk.ColumnMappings.Add(idLibroLog);

                    var descripcion = new SqlBulkCopyColumnMapping("Descripcion",
                        "Descripcion");
                    sqlBlk.ColumnMappings.Add(descripcion);

                    sqlBlk.WriteToServer(dt);
                }

            }
        }
    }
}
