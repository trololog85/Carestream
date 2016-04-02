using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;
using CareStream.Logic.Excel;

namespace CareStream.Logic.Facade
{
    public class FInfoEstructura
    {
        public List<InfoEstructura> Listar(Int32 id)
        {
            DAInfoEstructura objDA = new DAInfoEstructura();

            List<InfoEstructura> lst = objDA.ListarxID(id);

            return lst;
        }

        public String Actualizar(InfoEstructura obj)
        {
            String rpta = String.Empty;

            DAInfoEstructura objDA = new DAInfoEstructura();

            try
            {
                objDA.Actualizar(obj);
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }
}
