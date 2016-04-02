using System;
using System.Globalization;
using System.Windows.Markup;
using MigraPle.Api.Windows.Utils.Entities;

namespace MigraPle.Api.Windows.Utils
{
    public class Formater
    {
        public static string FormateaFecha(FormatoFecha formato, DateTime fecha)
        {
            var sFecha = String.Empty;

            if (formato == FormatoFecha.DDMMAAAA)
            {
                var anio = fecha.Year;
                var mes = fecha.Month;
                var dia = fecha.Day;

                sFecha = String.Format("{0}/{1}/{2}", RellenaNumero(dia), RellenaNumero(mes), FormateaAnio(anio, 4));
            }

            if (formato == FormatoFecha.AAAAMMDD)
            {
                var anio = fecha.Year;
                var mes = fecha.Month;
                var dia = fecha.Day;

                sFecha = String.Format("{0}-{1}-{2}", anio, RellenaNumero(mes), RellenaNumero(dia));
            }

            if (formato == FormatoFecha.AAAAMM00)
            {
                var anio = fecha.Year;
                var mes = fecha.Month;

                sFecha = String.Format("{0}{1}00", anio, RellenaNumero(mes));
            }

            return sFecha;
        }

        public static string RellenaNumero(int n)
        {
            var l = n.ToString().Length;

            if (l == 1)
                return "0" + n;
            
            return n.ToString();
        }

        public static string FormateaAnio(int n, int longitud)
        {
            var l = n.ToString().Length;

            if (l == 4)
                return n.ToString();

            var s = n.ToString();

            for (var i = 0; i < longitud - 1; i++)
            {
                s = "0" + s;
            }

            return s;
        }
    }
}
