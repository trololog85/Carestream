using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;
using System.Configuration;

namespace CareStream.Utils
{
    public class Validador
    {
        private static List<CodigoDetalle> lst;
        private static List<CodigoDetalle> lstComprobante;
        private static List<CodigoDetalle> lstCodigoAduana;

        public static void CargaTipoDocumento()
        {
            if (lst == null)
            {
                DACodigoDetalle objDA = new DACodigoDetalle();

                lst = objDA.Listar(3);
            }
        }

        public static void CargaTipoComprobante()
        {
            if (lstComprobante == null)
            {
                DACodigoDetalle objDA = new DACodigoDetalle();

                lstComprobante = objDA.Listar(1);
            }
        }

        public static void CargarCodigoAduana()
        {
            if (lstCodigoAduana == null)
            {
                DACodigoDetalle objDA = new DACodigoDetalle();

                lstCodigoAduana = objDA.Listar(4);
            }
        }


        public static Boolean ValidaCodigoAduana(String doc)
        {
            var filtro = (from o in lstCodigoAduana
                          where o.codigo == doc
                          select o).FirstOrDefault();

            CodigoDetalle obj = (CodigoDetalle)filtro;

            return (obj != null);
        }


        public static Boolean ValidaNumDocumentoTipoDoc(Int32 longitud, Char tipo, Char tipo_long,String num_doc)
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
        
            return valor.IndexOf(c)==-1;
        }
    }
}
