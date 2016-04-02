using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;
using CareStream.Utils;


namespace CareStream.Logic.Excel
{
    public class BLInfoEstructura
    {
        private List<InfoEstructura> lst = new List<InfoEstructura>();

        public void Cargar(String rutaArchivo,Int32 id_estructura)
        {
            using (OleDbConnection oleDbCn = new OleDbConnection(Connection.ExcelConnection(rutaArchivo)))
            {
                oleDbCn.Open();

                String query = "select campo,long,obligatorio,formato,nombre from [estructura$]";

                using (OleDbCommand oleDbCmd = new OleDbCommand(query, oleDbCn))
                {
                    using (OleDbDataReader oleDbdr = oleDbCmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (oleDbdr != null)
                        {
                            if (oleDbdr.HasRows)
                            {
                                Int32 i1 = oleDbdr.GetOrdinal("campo");
                                Int32 i2 = oleDbdr.GetOrdinal("long");
                                Int32 i3 = oleDbdr.GetOrdinal("obligatorio");
                                Int32 i4 = oleDbdr.GetOrdinal("formato");
                                Int32 i5 = oleDbdr.GetOrdinal("nombre");

                                InfoEstructura obj = new InfoEstructura();

                                Int32 cont = 1;

                                while (oleDbdr.Read())
                                {
                                    obj = new InfoEstructura();

                                    obj.id_estructura = id_estructura;
                                    obj.descripcion = oleDbdr.GetString(i5);

                                    if (oleDbdr.GetString(i4) == "Numérico")
                                    {
                                        obj.tipo_dato = "N";
                                    }
                                    else if (oleDbdr.GetString(i4) == "Alfanumérico")
                                    {
                                        obj.tipo_dato = "A";
                                    }
                                    else if (oleDbdr.GetString(i4) == "DD/MM/AAAA")
                                    {
                                        obj.tipo_dato = "F";
                                    }

                                    obj.longitud_campo = Convert.ToInt32(oleDbdr.GetDouble(i2));

                                    if (oleDbdr.GetString(i3) == "Si")
                                    {
                                        obj.obligatorio = true;
                                    }
                                    else
                                    {
                                        obj.obligatorio = false;
                                    }

                                    obj.num_campo = cont;

                                    lst.Add(obj);

                                    cont++;
                                }
                            }
                        }
                    }
                }

                foreach (InfoEstructura inf in lst)
                {
                    if (inf.num_campo == 1)
                    {
                        inf.pos_inicial = 0;
                        inf.pos_final = inf.pos_inicial + inf.longitud_campo;
                    }
                    else
                    {
                        InfoEstructura info = ObtieneInicioFin(inf.num_campo);
                        inf.pos_inicial = info.pos_final + 1;
                        inf.pos_final = inf.pos_inicial + inf.longitud_campo - 1;
                    }

                    inf.id_estructura = id_estructura;
                }

                DAInfoEstructura objDAInfoEst = new DAInfoEstructura();

                objDAInfoEst.GuardarTrama(lst);
            }
        }

        private InfoEstructura ObtieneInicioFin(Int32 n_campo)
        {
            var filtro = from o in lst
                         where o.num_campo == n_campo - 1
                         select o;

            return filtro.ToList<InfoEstructura>()[0];
        }

        private Int32 ObtieneLongitudTrama()
        {
            var filtro = from o in lst
                         orderby o.num_campo descending
                         select o;

            return Convert.ToInt32(((InfoEstructura)(filtro)).pos_final) + 1;
        }
    }
}
