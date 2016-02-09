using System;
using System.Configuration;

namespace Carestream.AdmTramas.Generator.Export.Mensajes
{
    public class Errores
    {
        public static string Pipe(string campo, string valor)
        {
            return String.Format("El campo {0} con valor {1} contiene el caracter pipe.",
                campo, valor);
        }

        public static string CampoLongitudInvalida(string campo,string valor)
        {
            return String.Format("El {0} {1} no contiene una longitud válida.",campo, valor);
        }

        public static string CampoObligatorio(string campo)
        {
            return String.Format("El campo {0} es obligatorio.",campo);
        }

        public static string CampoPositivo(string campo, string valor)
        {
            return String.Format("El campo {0} {1} solo permite valores positivos.", campo,valor);
        }

        public static string CampoInvalido(string campo, string valor)
        {
            return String.Format("El campo {0} {1} es inválido.", campo, valor);
        }
    }
}
