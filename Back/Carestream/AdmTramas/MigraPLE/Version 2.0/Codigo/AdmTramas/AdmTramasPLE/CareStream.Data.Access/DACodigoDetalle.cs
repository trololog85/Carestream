using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CareStream.Utils;

namespace CareStream.Data.Access
{
    public class DACodigoDetalle
    {
        public List<CodigoDetalle> Listar(Int32 tipo)
        {
            List<CodigoDetalle> lst = new List<CodigoDetalle>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ListarCodigoDetalle(tipo).ToList<CodigoDetalle>();
            }

            return lst;
        }
    }
}
