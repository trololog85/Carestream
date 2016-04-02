using System;
using System.Configuration;
using System.Linq;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Generator.Export.Mensajes;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Tipos;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_4_0
{
    public class Common:ICommon
    {
        public string ObtienePeriodo(DateTime fecha)
        {
            var mes = fecha.Month;
            var anio = fecha.Year;

            return String.Format("{0}{1}00", anio, Formato.RellenaNumero(mes));
        }

        public Tuple<bool, string> ValidaFechaPeriodo(DateTime periodoInformado)
        {
            if (DateTime.Compare(periodoInformado, Globals.PeriodoInformado) > 0)
                return new Tuple<bool, string>(false,
                    Errores.CampoInvalido("Periodo Informado", Formato.FormateaFecha("DD/MM/AAAA", periodoInformado)));

            return new Tuple<bool, string>(true,String.Empty);
        }

        public Tuple<bool, string> ValidaTipoComprobante(string tipoComprobante)
        {
            return BuscaTipoComprobante(tipoComprobante) ? 
                new Tuple<bool, string>(false,Errores.CampoInvalido("Tipo de Comprobante",tipoComprobante)) : 
                new Tuple<bool, string>(true,"");
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
            var pipe = ConfigurationManager.AppSettings["separador"];

            return valor.IndexOf(pipe) == -1;
        }

        public Tuple<bool,string> ValidaNumeroSerieComprobante(TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente,string numeroSerie)
        {
            //Valida pipe
            if (!ValidaPipe(numeroSerie))
            {
                return new Tuple<bool, string>(false, Errores.Pipe("Numero de Serie", numeroSerie));
            }

            //Validamos que exista, es obligatorio
            if (numeroSerie.Trim() == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Número de Serie"));

            //Validamos regla general tipo y numero de documento del cliente
            return ReglaGeneralTipoyNroDocumento(tipoDocumentoCliente, numeroDocumentoCliente);
        }

        public Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente, string numeroComprobante)
        {
            //Valida pipe
            if (!ValidaPipe(numeroComprobante))
            {
                return new Tuple<bool, string>(false, Errores.Pipe("Numero de Comprobante", numeroComprobante));
            }

            //Validamos que exista, es obligatorio
            if (numeroComprobante.Trim() == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Número de Serie"));

            //Validamos regla general tipo y numero de documento del cliente
            return ReglaGeneralTipoyNroDocumento(tipoDocumentoCliente, numeroDocumentoCliente);
        }

        public Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion,decimal importeTotalComprobante,string tipoDocumentoCliente)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaTipoDocumentoCliente1"];
            var regla2 = ConfigurationManager.AppSettings["reglaTipoDocumentoCliente2"];
            var regla3 = ConfigurationManager.AppSettings["reglaTipoDocumentoCliente3"];
            var regla4 = ConfigurationManager.AppSettings["reglaTipoDocumentoCliente4"];
            var regla5 = Convert.ToDecimal(ConfigurationManager.AppSettings["reglaTipoDocumentoCliente5"]);
            var regla6 = Convert.ToDecimal(ConfigurationManager.AppSettings["reglaTipoDocumentoCliente6"]);

            var tipoComprobanteValidos = regla1.Split(',');
            var tipoComprobanteValidos1 = regla3.Split(',');
            var estadoAnotacionValidos = regla4.Split(',');

            var noObligatorio = tipoComprobanteValidos.Any(x=>x==Formato.RellenaCodigo(tipoComprobante))||
                oportunidadAnotacion==regla2 || 
                (tipoComprobanteValidos1.Any(x=>x==Formato.RellenaCodigo(tipoComprobante)) 
                && estadoAnotacionValidos.Any(x=>x==oportunidadAnotacion))
                || valorFacturadoExportacion>regla5 || importeTotalComprobante<regla6;

            if (!noObligatorio && tipoDocumentoCliente.Trim()==String.Empty)
                return new Tuple<bool, string>(false,Errores.CampoObligatorio("Tipo de Documento del Cliente"));

            if (tipoDocumentoCliente.Trim() != String.Empty)
            {
                if(Globals.LstTipoDocumento.All(x=>x.Codigo!=tipoDocumentoCliente))
                    return new Tuple<bool, string>(false, Errores.CampoInvalido("Tipo de Documento del Cliente", tipoDocumentoCliente));
            }

            return new Tuple<bool, string>(true,"");
        }

        public Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante, string tipoDocumentoCliente,
            string tipoComprobanteModificado)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaNombreyApellidoCompras1"];
            var regla2 = ConfigurationManager.AppSettings["reglaNombreyApellido3"];
            var regla3 = ConfigurationManager.AppSettings["reglaNombreyApellido4"];

            var tipoComprobanteValidos = regla1.Split(',');
            var tipoComprobanteValidos1 = regla2.Split(',');
            var tipoComprobanteValidos2 = regla3.Split(',');

            var noObligatorio = (tipoComprobanteValidos.Any(x => x == Formato.RellenaCodigo(tipoComprobante))) ||
                                (tipoComprobanteValidos1.Any(x => x == Formato.RellenaCodigo(tipoComprobante))
                                 && tipoComprobanteValidos2.Any(x => x == tipoComprobanteModificado));

            if (!noObligatorio && tipoDocumentoCliente.Trim() == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Tipo de Documento del Cliente"));

            if (tipoDocumentoCliente.Trim() != String.Empty)
            {
                if (Globals.LstTipoDocumento.All(x => x.Codigo != tipoDocumentoCliente))
                    return new Tuple<bool, string>(false, Errores.CampoInvalido("Tipo de Documento del Cliente", tipoDocumentoCliente));
            }

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string numeroDocumentoCliente,
            TipoDocumento tipoDocumento)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente1"];
            var regla2 = ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente2"];
            var regla3 = ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente3"];
            var regla4 = ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente4"];
            var regla5 = Convert.ToDecimal(ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente5"]);
            var regla6 = Convert.ToDecimal(ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente6"]);

            var tipoComprobanteValidos = regla1.Split(',');
            var tipoComprobanteValidos1 = regla3.Split(',');
            var estadoAnotacionValidos = regla4.Split(',');

            var noObligatorio = tipoComprobanteValidos.Any(x => x == Formato.RellenaCodigo(tipoComprobante)) ||
                oportunidadAnotacion == regla2 ||
                (tipoComprobanteValidos1.Any(x => x == Formato.RellenaCodigo(tipoComprobante))
                && estadoAnotacionValidos.Any(x => x == oportunidadAnotacion))
                || valorFacturadoExportacion > regla5 || importeTotalComprobante < regla6;

            if (!noObligatorio && numeroDocumentoCliente.Trim() == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Número de Documento"));

            if (numeroDocumentoCliente.Trim() != String.Empty)
            {
                return ReglaGeneralTipoyNroDocumento(tipoDocumento, numeroDocumentoCliente);
            }

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante,
            string numeroDocumentoCliente,TipoDocumento tipoDocumento,string tipoComprobanteModificado)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaNombreyApellidoCompras1"];
            var regla2 = ConfigurationManager.AppSettings["reglaNombreyApellido3"];
            var regla3 = ConfigurationManager.AppSettings["reglaNombreyApellido4"];

            var tipoComprobanteValidos = regla1.Split(',');
            var tipoComprobanteValidos1 = regla2.Split(',');
            var tipoComprobanteValidos2 = regla3.Split(',');

            var noObligatorio = (tipoComprobanteValidos.Any(x => x == Formato.RellenaCodigo(tipoComprobante))) ||
                                (tipoComprobanteValidos1.Any(x => x == Formato.RellenaCodigo(tipoComprobante))
                                 && tipoComprobanteValidos2.Any(x => x == tipoComprobanteModificado));

            if (!noObligatorio && numeroDocumentoCliente.Trim() == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Número de Documento"));

            if (numeroDocumentoCliente.Trim() != String.Empty)
            {
                return ReglaGeneralTipoyNroDocumento(tipoDocumento, numeroDocumentoCliente);
            }

            return new Tuple<bool, string>(true, "");
        }

        private Tuple<bool, string> ReglaGeneralTipoyNroDocumento(TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente)
        {
            var len = numeroDocumentoCliente.Length;

            switch (tipoDocumentoCliente)
            {
                case TipoDocumento.Otros:
                    if (!Formato.ValidaAlfanumerico(numeroDocumentoCliente))
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));
                    
                    if (len > 15)
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));
                    break;
                case TipoDocumento.CarnetExtranjeria:
                    if (!Formato.ValidaAlfanumerico(numeroDocumentoCliente))
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));

                    if (len > 12)
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));
                    break;
                case TipoDocumento.CedulaDiplomatica:
                    if (!Formato.ValidaNumerico(numeroDocumentoCliente))
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));

                    if (len != 15)
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));
                    break;
                case TipoDocumento.LibretaElectoral:
                    if (!Formato.ValidaNumerico(numeroDocumentoCliente))
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));

                    if (len != 8)
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));
                    break;
                case TipoDocumento.Pasaporte:
                    if (!Formato.ValidaAlfanumerico(numeroDocumentoCliente))
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));

                    if (len > 12)
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));
                    break;
                case TipoDocumento.RegUnicoContribuyente:
                    if (!Formato.ValidaNumerico(numeroDocumentoCliente))
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));

                    if (len != 11)
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Número de Documento del Cliente",
                            numeroDocumentoCliente));
                    break;    
            }
            return new Tuple<bool, string>(true, "");
        }
    }
}
