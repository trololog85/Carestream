using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Utils
{
    public class Formato
    {
        public static bool ValidaEntero(string caracter)
        {
            Int64 dec;

            if (Int64.TryParse(caracter, out dec))
            {
                return false;
            }
            else
            {
                if (caracter == "8") //backspace
                {
                    return false;
                }
                else if (caracter == "22")
                {
                    return false;
                }
                else if (caracter == "24")
                {
                    return false;
                }
                else if (caracter == "13")
                {
                    return false;
                }
                else if (caracter == "\b" || caracter == "\r" || caracter == "-")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static bool ValidaNumerico(string valor)
        {
            Decimal dec;

            if (Decimal.TryParse(valor, out dec))
            {
                return false;
            }
            else
            {
                if (valor == "." || valor == "\b" || valor == "-" || valor == "\r" || valor == "8" || valor == "22" ||
                    valor == "24" || valor == "13")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static DateTime ObtieneFecha(string valor, string formato)
        {
            var d = new DateTime();
            var dia = 0;
            var mes = 0;
            var anio = 0;

            switch (formato)
            {
                case "DD.MM.AAAA":
                    dia = Convert.ToInt32(valor.Substring(0, 2));
                    mes = Convert.ToInt32(valor.Substring(3, 2));
                    anio = Convert.ToInt32(valor.Substring(6, 4));

                    d = new DateTime(anio, mes, dia);

                    break;
                case "DD/MM/AAAA":
                    dia = Convert.ToInt32(valor.Substring(0, 2));
                    mes = Convert.ToInt32(valor.Substring(3, 2));
                    anio = Convert.ToInt32(valor.Substring(6, 4));

                    d = new DateTime(anio, mes, dia);

                    break;
            }

            return d;
        }

        public static string FormateaFecha(string formato, DateTime fecha)
        {
            var s = String.Empty;

            if (formato == "DD/MM/AAAA")
            {
                var anio = fecha.Year;
                var mes = fecha.Month;
                var dia = fecha.Day;

                s = String.Format("{0}/{1}/{2}", RellenaNumero(dia), RellenaNumero(mes), FormateaAnio(anio,4));
            }

            if (formato == "AAAA-MM-DD")
            {
                var anio = fecha.Year;
                var mes = fecha.Month;
                var dia = fecha.Day;

                s = String.Format("{0}-{1}-{2}", anio, RellenaNumero(mes), RellenaNumero(dia));
            }

            if (formato == "AAAAMM00")
            {
                var anio = fecha.Year;
                var mes = fecha.Month;

                s = String.Format("{0}{1}00", anio, RellenaNumero(mes));
            }

            return s;
        }

        public static string FormateaAnio(int n, int longitud)
        {
            var l = n.ToString(CultureInfo.InvariantCulture).Length;

            if (l == 4)
                return n.ToString();

            var s = n.ToString(CultureInfo.InvariantCulture);

            for (var i = 0; i < longitud-1; i++)
            {
                s = "0" + s;
            }

            return s;
        }

        public static string FormateaCadena(string cadena, char caracter, int cantidad)
        {
            if (cadena.Length >= cantidad)
                return cadena;

            var reps = cantidad - cadena.Length;

            for (var i = 0; i < reps; i++)
            {
                cadena = caracter + cadena;
            }

            return cadena;
        }

        public static string RellenaNumero(int n)
        {
            Int32 l = n.ToString().Length;

            String s = String.Empty;

            if (l == 1)
            {
                s = "0" + n.ToString();
            }
            else
            {
                return n.ToString();
            }

            return s;
        }

        public static string RellenaCodigo(string codigo)
        {
            String cod = String.Empty;

            if (codigo.Length == 1)
            {
                cod = "0" + codigo;
            }
            else
            {
                cod = codigo;
            }

            return cod;
        }

        public static string ObtieneMoneda(string codMoneda)
        {
            switch (codMoneda)
            {
                case "PEN":
                    return "1";
                case "USD":
                    return "2";
                default:
                    return "1";
            }
        }

        public static bool ValidaError(string ruta)
        {
            //Obtenemos los primeros caracteres de la respuesta
            String rpta = ruta.Substring(0, 5);

            return rpta == "Error";
        }

        public static string RellenaNumero(int n, int longitud, string caracter)
        {
            Int32 i = 1;

            String num = n.ToString();

            for (i = 1; i <= longitud; i++)
            {
                if (num.Length < longitud)
                {
                    num = caracter + num;
                }
            }

            return num;
        }

        public static TipoLibro EligeTipoLibro(int idLibro)
        {
            switch (idLibro)
            {
                case 1:
                    return TipoLibro.Ventas;
                case 2:
                    return TipoLibro.Compras;
                case 3:
                    return TipoLibro.LibroDiario;
                case 4:
                    return TipoLibro.LibroMayor;
                case 5:
                    return TipoLibro.LibroDiarioDetalle;
                case 6:
                    return TipoLibro.NoDomiciliado;
                default:
                    return TipoLibro.Ventas;
            }
        }

        public static bool ValidaAlfanumerico(string valor)
        {
            var len = valor.Length;

            for (var i = 0; i <len; i++)
            {
                var caracter = valor.Substring(i, 1);

                if (Globals.Alfanumerico.All(x => x != caracter))
                    return false;
            }

            return true;
        }

        public static bool ValidaNumericoPositivo(string valor)
        {
            var len = valor.Length;

            for (var i = 0; i < len; i++)
            {
                var caracter = valor.Substring(i, 1);

                if (Globals.Numerico.All(x => x != caracter))
                    return false;
            }

            for (var i = 0; i < len; i++)
            {
                var caracter = valor.Substring(i, 1);

                if (caracter == "-")
                    return false;
            }

            return true;
        }

        public static string GeneraCorrelativo(short numero)
        {
            var cadena = numero.ToString(CultureInfo.InvariantCulture);

            for (var i = 0; cadena.Length < 5; i++)
            {
                cadena = "0" + cadena;
            }

            return "M" + cadena;
        }

        public static string ObtieneNombreArchivo(NombreLibro nombreLibro)
        {
            var sb = new StringBuilder();

            sb.Append(nombreLibro.Identificador);

            sb.Append(nombreLibro.NumeroRuc);

            sb.Append(nombreLibro.Anio);

            sb.Append(nombreLibro.Mes);

            sb.Append(nombreLibro.Dia);

            sb.Append(nombreLibro.IdentificadorLibro);

            sb.Append(nombreLibro.CodigoOportunidad);

            sb.Append(nombreLibro.CodigoOperacion);

            sb.Append(nombreLibro.CodigoLibro);

            sb.Append(nombreLibro.CodigoMoneda);

            sb.Append(nombreLibro.Indicador);

            sb.Append("1");

            sb.Append(".txt");

            return sb.ToString();
        }

        public static string GeneraCorrelativoSinPrefijo(short numero)
        {
            string str = numero.ToString((IFormatProvider)CultureInfo.InvariantCulture);
            int num = 0;
            while (str.Length < 5)
            {
                str = "0" + str;
                ++num;
            }
            return str;
        }

        public static DateTime GeneraFecha(string anio, string mes)
        {
            int month = int.Parse(mes);
            return new DateTime(int.Parse(anio), month, 1);
        }
    }
}
