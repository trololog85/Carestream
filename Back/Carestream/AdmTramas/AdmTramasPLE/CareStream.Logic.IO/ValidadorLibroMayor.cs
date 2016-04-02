using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Utils;
using CareStream.Data.Access;
using System.Configuration;

namespace CareStream.Logic.IO
{
    public class ValidadorLibroMayor
    {
        public static String ObtienePeriodo(DateTime fecha)
        {
            Int32 mes = fecha.Month;
            Int32 anio = fecha.Year;

            return anio.ToString() + Formato.RellenaNumero(mes).ToString() + "00";
        }

        public static Boolean ValidaMontos(Decimal credito, Decimal debito)
        {
            if (credito == 0 && debito == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
