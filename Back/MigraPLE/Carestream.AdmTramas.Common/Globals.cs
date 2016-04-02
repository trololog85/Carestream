using System;
using System.Collections.Generic;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Common
{
    public class Globals
    {
        public static int Progreso { get; set; }
        public static DateTime PeriodoInformado { get; set; }
        public static List<CodigoDetalle> LstTipoDocumento { get; set; }
        public static List<CodigoDetalle> LstComprobante { get; set; }
        public static List<CodigoDetalle> LstCodigoAduana { get; set; }

        public static string queryVentas { get; set; }
        public static string queryCompras { get; set; }
        public static string queryLibroDiario { get; set; }
        public static string queryLibroMayor { get; set; }
        public static string queryDiarioDetalle { get; set; }


        public static List<string> Alfanumerico = new List<string>
        {
            "a","b","c","d","e","f","g","h","i","j","k","l","n","m","ñ","o",
            "p","q","r","s","t","u","v","w","x","y","z",
            "0","1","2","3","4","5","6","7","8","9"
        };

        public static List<string> Numerico = new List<string>
        {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"
        };
    }
}
