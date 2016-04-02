using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CareStream.Utils;
using System.Configuration;

namespace CareStream.Data.Access
{
    public class DAErrorLineaDetalle
    {
        public void Guardar(ErrorLineaDetalle obj)
        {
            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                ent.AddToErrorLineaDetalles(obj);

                ent.SaveChanges();
            }
        }

        public List<ErrorLineaDetalle> ListarxArchivoLog(Int32 id_archivo_log)
        {
            List<ErrorLineaDetalle> lst = new List<ErrorLineaDetalle>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ObtieneErrorDetallexArchivoLog(id_archivo_log).ToList<ErrorLineaDetalle>();
            }

            return lst;
        }

        public void GuardarLote(List<ErrorLineaDetalle> lst)
        { 
            String cons = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

            using (SqlConnection sqlCon = new SqlConnection(cons))
            {
                sqlCon.Open();

                DataTable dt = new DataTable();

                DataColumn dc1 = new DataColumn("id_archivo_log");
                DataColumn dc2 = new DataColumn("n_linea");
                DataColumn dc3 = new DataColumn("nombre_campo");
                DataColumn dc4 = new DataColumn("descripcion");

                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dt.Columns.Add(dc4);

                DataRow dtr = dt.NewRow();

                foreach (ErrorLineaDetalle obj in lst)
                {
                    dtr = dt.NewRow();

                    dtr["id_archivo_log"] = obj.id_archivo_log;
                    dtr["n_linea"] = obj.n_linea;
                    dtr["nombre_campo"] = obj.nombre_campo;
                    dtr["descripcion"] = obj.descripcion;

                    dt.Rows.Add(dtr);
                }

                using (SqlBulkCopy sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.errorlineadetalle";

                    SqlBulkCopyColumnMapping id_archivo_log = new SqlBulkCopyColumnMapping("id_archivo_log",
                    "id_archivo_log");
                    sqlBlk.ColumnMappings.Add(id_archivo_log);

                    SqlBulkCopyColumnMapping n_linea = new SqlBulkCopyColumnMapping("n_linea",
                    "n_linea");
                    sqlBlk.ColumnMappings.Add(n_linea);

                    SqlBulkCopyColumnMapping nombre_campo = new SqlBulkCopyColumnMapping("nombre_campo",
                    "nombre_campo");
                    sqlBlk.ColumnMappings.Add(nombre_campo);

                    SqlBulkCopyColumnMapping descripcion = new SqlBulkCopyColumnMapping("descripcion",
                    "descripcion");
                    sqlBlk.ColumnMappings.Add(descripcion);

                    sqlBlk.WriteToServer(dt);
                }
            }


        }
    }
}
