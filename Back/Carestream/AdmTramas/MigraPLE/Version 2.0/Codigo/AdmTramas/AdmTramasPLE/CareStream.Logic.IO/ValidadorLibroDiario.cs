using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Utils;
using CareStream.Data.Access;
using System.Configuration;

namespace CareStream.Logic.IO
{
    public class ValidadorLibroDiario
    {
        public static String ObtienePeriodo(DateTime fecha)
        {
            Int32 mes = fecha.Month;
            Int32 anio = fecha.Year;

            return anio.ToString() + Formato.RellenaNumero(mes).ToString() + "00";
        }

        public static Boolean ValidaDebe(Decimal debe)
        {
            return debe < 0;
        }

        public static Boolean ValidaHaber(Decimal debe)
        {
            return debe < 0;
        }
    }
}
