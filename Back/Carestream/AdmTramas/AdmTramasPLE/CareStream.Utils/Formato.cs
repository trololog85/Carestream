using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareStream.Utils
{
    public class Formato
    {
        public static Boolean ValidaEntero(String caracter)
        {
            Int32 dec;

            if (Int32.TryParse(caracter, out dec))
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

        public static Boolean ValidaNumerico(String caracter)
        {
            Decimal dec;

            if (Decimal.TryParse(caracter, out dec))
            {
                return false;
            }
            else
            {
                if (caracter == "." || caracter == "\b" || caracter == "-" || caracter == "\r" || caracter == "8" || caracter == "22" ||
                    caracter == "24" || caracter == "13")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static DateTime ObtieneFecha(String valor, String formato)
        {
            DateTime d = new DateTime();

            if (formato == "DD.MM.AAAA")
            {
                Int32 dia = Convert.ToInt32(valor.Substring(0, 2));
                Int32 mes = Convert.ToInt32(valor.Substring(3, 2));
                Int32 anio = Convert.ToInt32(valor.Substring(6, 4));

                d = new DateTime(anio, mes, dia);
            }

            return d;
        }

        public static String FormateaFecha(String formato, DateTime fecha)
        {
            String s = String.Empty;

            if (formato == "DD/MM/AAAA")
            {
                Int32 anio = fecha.Year;
                Int32 mes = fecha.Month;
                Int32 dia = fecha.Day;

                s = RellenaNumero(dia) + "/" + RellenaNumero(mes) + "/" + anio;
            }
        
            return s;
        }

        public static String RellenaNumero(Int32 n)
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

        public static String RellenaCodigo(String codigo)
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

        public static Int16 ObtieneMoneda(String codMoneda)
        {
            switch (codMoneda)
            { 
                case "PEN":
                    return 1;
                case "USD":
                    return 2;
                default:
                    return 1;
            }
        }

        public static Boolean ValidaError(String ruta)
        { 
            //Obtenemos los primeros caracteres de la respuesta
            String rpta = ruta.Substring(0, 5);

            return rpta == "Error";
        }

        public static String RellenaNumero(Int32 n,Int32 longitud,String caracter)
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
    }
}
