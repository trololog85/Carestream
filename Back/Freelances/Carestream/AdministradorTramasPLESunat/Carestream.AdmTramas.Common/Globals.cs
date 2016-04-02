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
        public static List<CodigoDetalle> LstCodigoMoneda { get; set; }
        public static List<CodigoDetalle> LstCodigoBienes { get; set; }
        public static List<CodigoDetalle> LstExoneraciones { get; set; }

        public static string queryVentas { get; set; }
        public static string queryCompras { get; set; }
        public static string queryLibroDiario { get; set; }
        public static string queryLibroMayor { get; set; }
        public static string queryDiarioDetalle { get; set; }
        public static string queryNoDomiciliado { get; set; }


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

        


        //TODO Completar listas auxiliares
        /*public class Common
        {
            public static Boolean ValidaCodigoAduana(String doc)
            {
                var filtro = (from o in lstCodigoAduana
                              where o.codigo == doc
                              select o).FirstOrDefault();

                CodigoDetalle obj = (CodigoDetalle)filtro;

                return (obj != null);
            }


            public static Boolean ValidaNumDocumentoTipoDoc(Int32 longitud, Char tipo, Char tipo_long, String num_doc)
            {
                //Validamos la longitud
                if (num_doc.Length > longitud || num_doc.Length < longitud)
                {
                    return false;
                }

                //Validamos si es o no numerico
                if (tipo == 'N')
                {
                    Int64 r;

                    return Int64.TryParse(num_doc, out r);
                }

                return true;
            }

            public static Boolean BuscaTipoDocumento(String doc)
            {
                var filtro = (from o in lst
                              where o.codigo == doc
                              select o).FirstOrDefault();

                CodigoDetalle obj = (CodigoDetalle)filtro;

                return (obj != null);
            }

            public static Boolean BuscaTipoComprobante(String doc)
            {
                var filtro = (from o in lstComprobante
                              where o.codigo == doc
                              select o).FirstOrDefault();

                CodigoDetalle obj = (CodigoDetalle)filtro;

                return (obj != null);
            }

            public static CodigoDetalle ObtieneTipoDocumento(String doc)
            {
                var filtro = (from o in lst
                              where o.codigo == doc
                              select o).FirstOrDefault();

                CodigoDetalle obj = (CodigoDetalle)filtro;

                return obj;
            }

            /// <summary>
            /// Valida que el campo Alfanumerico no contenga el caraceter pipe.
            /// </summary>
            /// <param name="valor">Cadena Alfanumerica</param>
            /// <returns>
            /// Devuelve un Boolean
            /// </returns>
            public static Boolean ValidaPipe(String valor)
            {
                String c = ConfigurationManager.AppSettings["separador"].ToString();

                return valor.IndexOf(c) == -1;
            }
        }*/
    }
}
