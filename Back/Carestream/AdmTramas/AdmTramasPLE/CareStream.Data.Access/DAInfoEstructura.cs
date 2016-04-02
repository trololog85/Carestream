using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CareStream.Utils;


namespace CareStream.Data.Access
{
    public class DAInfoEstructura
    {
        public List<InfoEstructura> ListarxID(Int32 id_estructura)
        {
            List<InfoEstructura> lst = new List<InfoEstructura>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ListarInfoEstructuraxID(id_estructura).ToList<InfoEstructura>();
            }

            return lst;
        }

        public List<InfoEstructura> ListarxCodArchivo(String codArchivo)
        {
            List<InfoEstructura> lst = new List<InfoEstructura>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ObtieneInfoEstructuraxCodArchivo(codArchivo).ToList<InfoEstructura>();
            }

            return lst;
        }

        public void Guardar(InfoEstructura obj)
        {
            BDTramaPLEEntities ent = new BDTramaPLEEntities();

            ent.AddToInfoEstructuras(obj);

            ent.SaveChanges();
        }

        public void GuardarTrama(List<InfoEstructura> lst)
        {
            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("id_estructura");
            DataColumn dc2 = new DataColumn("tipo_dato");
            DataColumn dc3 = new DataColumn("pos_inicial");
            DataColumn dc4 = new DataColumn("pos_final");
            DataColumn dc5 = new DataColumn("longitud_campo");
            DataColumn dc6 = new DataColumn("obligatorio");
            DataColumn dc7 = new DataColumn("num_campo");
            DataColumn dc8 = new DataColumn("descripcion");

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);

            DataRow dr = dt.NewRow();

            foreach (InfoEstructura inf in lst)
            {
                dr = dt.NewRow();

                dr["id_estructura"] = inf.id_estructura;
                dr["tipo_dato"] = inf.tipo_dato;
                dr["pos_inicial"] = inf.pos_inicial;
                dr["pos_final"] = inf.pos_final;
                dr["longitud_campo"] = inf.longitud_campo;
                dr["obligatorio"] = inf.obligatorio;
                dr["num_campo"] = inf.num_campo;
                dr["descripcion"] = inf.descripcion;

                dt.Rows.Add(dr);
            }

            using (SqlConnection sqlCon = new SqlConnection(Connection.DbConnection))
            {
                sqlCon.Open();

                using (SqlBulkCopy sqlBlk = new SqlBulkCopy(sqlCon))
                {
                    sqlBlk.BatchSize = dt.Rows.Count;
                    sqlBlk.DestinationTableName = "dbo.InfoEstructura";

                    SqlBulkCopyColumnMapping id_estructura = new SqlBulkCopyColumnMapping("id_estructura",
                    "id_estructura");
                    sqlBlk.ColumnMappings.Add(id_estructura);

                    SqlBulkCopyColumnMapping tipo_dato = new SqlBulkCopyColumnMapping("tipo_dato",
                    "tipo_dato");
                    sqlBlk.ColumnMappings.Add(tipo_dato);

                    SqlBulkCopyColumnMapping pos_inicial = new SqlBulkCopyColumnMapping("pos_inicial",
                    "pos_inicial");
                    sqlBlk.ColumnMappings.Add(pos_inicial);

                    SqlBulkCopyColumnMapping pos_final = new SqlBulkCopyColumnMapping("pos_final",
                    "pos_final");
                    sqlBlk.ColumnMappings.Add(pos_final);

                    SqlBulkCopyColumnMapping longitud_campo = new SqlBulkCopyColumnMapping("longitud_campo",
                    "longitud_campo");
                    sqlBlk.ColumnMappings.Add(longitud_campo);

                    SqlBulkCopyColumnMapping obligatorio = new SqlBulkCopyColumnMapping("obligatorio",
                    "obligatorio");
                    sqlBlk.ColumnMappings.Add(obligatorio);

                    SqlBulkCopyColumnMapping num_campo = new SqlBulkCopyColumnMapping("num_campo",
                    "num_campo");
                    sqlBlk.ColumnMappings.Add(num_campo);

                    SqlBulkCopyColumnMapping descripcion = new SqlBulkCopyColumnMapping("descripcion",
                    "descripcion");
                    sqlBlk.ColumnMappings.Add(descripcion);

                    sqlBlk.WriteToServer(dt);
                }
            }
        }

        public void Actualizar(InfoEstructura obj)
        {
            BDTramaPLEEntities ent = new BDTramaPLEEntities();

            EntityKey key = ent.CreateEntityKey("InfoEstructuras", obj);

            object InfoToMod;

            if (ent.TryGetObjectByKey(key, out InfoToMod))
            {
                ent.ApplyCurrentValues(key.EntitySetName, obj);
            }

            ent.SaveChanges();
        }
    }
}
