using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;

namespace CareStream.Logic.Facade
{
    public class FCodigoDetalle
    {
        public List<CodigoDetalle> Listar(Int32 tipo)
        {
            DACodigoDetalle objDA = new DACodigoDetalle();

            List<CodigoDetalle> lst = new List<CodigoDetalle>();

            try
            {
                lst = objDA.Listar(tipo);
            }
            catch (Exception ex)
            {
                String s = ex.Message;
            }


            return lst;
        }
    }
}
