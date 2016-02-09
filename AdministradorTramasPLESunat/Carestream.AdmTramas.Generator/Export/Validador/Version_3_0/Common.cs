using System;
using System.Configuration;
using System.Linq;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Tipos;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_3_0
{
    public class Common
    {
        public string ObtienePeriodo(DateTime fecha)
        {
            var mes = fecha.Month;
            var anio = fecha.Year;

            return String.Format("{0}{1}00", anio, Formato.RellenaNumero(mes));
        }

        public Tuple<bool,string> ValidaTipoComprobante(string tipoComprobante)
        {
            return new Tuple<bool, string>(true,"");

            //return BuscaTipoComprobante(Formato.RellenaCodigo(tipoComprobante));
        }

        public Tuple<bool, string> ValidaNumeroSerieComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroSerie)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroSerie)
        {
            /*var defaultTipoDocumento = ConfigurationManager.AppSettings["defaultTipoDocumento"];
            var defaultNumeroSerie = ConfigurationManager.AppSettings["defaultNumeroSerie"];

            //Validamos si es 00
            var tipoDoc = Formato.RellenaCodigo(tipoDocumento);

            if (defaultTipoDocumento == tipoDoc)
            {
                return new Tuple<bool, string>(true,defaultNumeroSerie);
            }

            //Validamos si esta dentro de los valores permitidos
            var tipoDocumentos = ConfigurationManager.AppSettings["numeroSerie"];
            var longitud1 = ConfigurationManager.AppSettings["longitudNumeroSerie1"];
            var longitud2 = ConfigurationManager.AppSettings["longitudNumeroSerie2"];

            var permitidos = tipoDocumentos.Split(',');

            //Validamos si tiene longitud permitida
            if (permitidos.Any(x => x == tipoDocumento))
            {
                if (numeroSerie.Length == Int32.Parse(longitud1))
                {
                    return new Tuple<bool, string>(true,"");
                }
                else
                {
                    return new Tuple<bool, string>(false,Errores.NumeroSerieInvalido(numeroSerie));
                }
            }
            else
            {
                if (numeroSerie.Length == Int32.Parse(longitud2))
                {
                    return new Tuple<bool, string>(true,"");
                }
                else
                {
                    return new Tuple<bool, string>(false,Errores.NumeroSerieInvalido(numeroSerie));
                }
            }*/

            return new Tuple<bool, string>(true,"");
        }

        public string ObtieneFechaEmisionComprobante(DateTime fecha)
        {
            return Formato.FormateaFecha("DD/MM/AAAA", fecha);
        }

        private static bool BuscaTipoComprobante(string doc)
        {
            var result = Globals.LstComprobante.Where(x => x.Codigo == doc);

            return result.Any();
        }

        public bool ValidaPipe(string valor)
        {
            var c = ConfigurationManager.AppSettings["separador"];

            return valor.IndexOf(c) == -1;
        }

        public Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string oportunidadAnotacion, decimal valorFacturadoExportacion,
            decimal importeTotalComprobante, string tipoDocumentoCliente)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string numeroDocumentoCliente,
            TipoDocumento tipoDocumento)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante, string numeroDocumentoCliente, TipoDocumento tipoDocumento,
            string tipoComprobanteModificado)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string tipoDocumentoCliente, string tipoComprobanteModificado)
        {
            throw new NotImplementedException();
        }
    }
}
