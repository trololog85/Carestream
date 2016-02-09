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
    public class RegistroVenta:IRegistroVenta
    {
        private readonly ICommon _common;

        public RegistroVenta(ICommon common)
        {
            _common = common;
        }

        public Tuple<bool, string> ValidarNumeroCorrelativo(TipoContribuyente tipoContribuyente)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaFechaEmisionComprobante(string estado,DateTime fecha,DateTime periodo)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaFechaEmision1"];
            var regla2 = DateTime.Parse(ConfigurationManager.AppSettings["reglaFechaEmision2"]);

            var periodoInformado = Globals.PeriodoInformado;
            
            if(estado==regla1 && fecha.Equals(regla2))
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Fecha de Emisión del comprobante"));

            if (DateTime.Compare(fecha, periodo) > 0)
                return new Tuple<bool, string>(false, Errores.CampoInvalido("Fecha de Emisión del comprobante",
                    Formato.FormateaFecha("DD/MM/AAAA", fecha)));

            if (DateTime.Compare(fecha, periodoInformado) > 0)
                return new Tuple<bool, string>(false, Errores.CampoInvalido("Fecha de Emisión del comprobante",
                    Formato.FormateaFecha("DD/MM/AAAA", fecha)));

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidaFechaVencimiento(string tipoComprobante,string estado,DateTime fecha,
            DateTime periodo)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaFechaVencimiento1"];
            var regla2 = ConfigurationManager.AppSettings["reglaFechaVencimiento2"];
            var regla3 = DateTime.Parse(ConfigurationManager.AppSettings["reglaFechaVencimiento3"]);
            var periodoInformado = Globals.PeriodoInformado;

            if(tipoComprobante==regla1 && estado==regla2 && fecha.Equals(regla3))
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Fecha de Vencimiento"));

            if (DateTime.Compare(fecha, periodo) > 0)
                return new Tuple<bool, string>(false, Errores.CampoInvalido("Fecha de Vencimiento",
                    Formato.FormateaFecha("DD/MM/AAAA", fecha)));

            if (DateTime.Compare(fecha, periodoInformado) > 0)
                return new Tuple<bool, string>(false, Errores.CampoInvalido("Fecha de Vencimiento",
                    Formato.FormateaFecha("DD/MM/AAAA", fecha)));

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidaTipoComprobante(string tipoComprobante)
        {
            return _common.ValidaTipoComprobante(tipoComprobante);
        }

        public Tuple<bool, string> ValidaNumeroSerieComprobante(TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente, string numeroSerie)
        {
            return _common.ValidaNumeroSerieComprobante(tipoDocumentoCliente, numeroDocumentoCliente, numeroSerie);
        }

        public Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroComprobante)
        {
            return _common.ValidaNumeroComprobante(tipoDocumento, numeroDocumento, numeroComprobante);
        }

        public Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante,string oportunidadAnotacion, string tipoDocumento, 
            decimal valorFacturadoExportacion,decimal importeTotalComprobante,string tipoDocumentoCliente)
        {
            return _common.ValidaTipoDocumentoCliente(tipoComprobante,oportunidadAnotacion,valorFacturadoExportacion,importeTotalComprobante,
                tipoDocumentoCliente);
        }

        public Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante,string oportunidadAnotacion, 
            decimal valorFacturadoExportacion,decimal importeTotalComprobante,string numeroDocumentoCliente,TipoDocumento tipoDocumento)
        {
            return _common.ValidaNumeroDocumentoCliente(tipoComprobante, oportunidadAnotacion, valorFacturadoExportacion, importeTotalComprobante,
                numeroDocumentoCliente,tipoDocumento);
        }

        public Tuple<bool, string> ValidaNombreApellido(string tipoComprobante,string oportunidadAnotacion, 
            decimal valorFacturadoExportacion,decimal importeTotalComprobante,string nombreApellido)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaNombreyApellido1"];
            var regla2 = ConfigurationManager.AppSettings["reglaNombreyApellido2"];
            var regla3 = ConfigurationManager.AppSettings["reglaNombreyApellido3"];
            var regla4 = ConfigurationManager.AppSettings["reglaNombreyApellido4"];
            var regla5 = Convert.ToDecimal(ConfigurationManager.AppSettings["reglaNombreyApellido5"]);
            var regla6 = Convert.ToDecimal(ConfigurationManager.AppSettings["montoTicketValido"]);

            var tipoComprobanteValidos = regla1.Split(',');
            var tipoComprobanteValidos1 = regla3.Split(',');
            var estadoAnotacionValidos = regla4.Split(',');

            var noObligatorio = tipoComprobanteValidos.Any(x => x == Formato.RellenaCodigo(tipoComprobante)) ||
                oportunidadAnotacion == regla2 ||
                (tipoComprobanteValidos1.Any(x => x == Formato.RellenaCodigo(tipoComprobante))
                && estadoAnotacionValidos.Any(x => x == oportunidadAnotacion))
                || valorFacturadoExportacion > regla5 || importeTotalComprobante < regla6;

            if (!noObligatorio && nombreApellido.Trim() == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Nombre del Cliente"));

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidaIVAP(string tipoComprobante, string oportunidadAnotacion,
            decimal? valor)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaIvap1"];
            var regla2 = ConfigurationManager.AppSettings["reglaIvap2"];

            var obligatorio = (tipoComprobante==regla1 && oportunidadAnotacion==regla2);

            if(obligatorio && valor==null)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Base Imponible a las ventas de arroz pilado."));

            return new Tuple<bool, string>(true,"");
        }

        public Tuple<bool, string> ValidaImpuestoIVAP(string tipoComprobante, string oportunidadAnotacion,
            decimal? valor)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaIvap1"];
            var regla2 = ConfigurationManager.AppSettings["reglaIvap2"];

            var obligatorio = (tipoComprobante == regla1 && oportunidadAnotacion == regla2);

            if (obligatorio && valor == null)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("IGV a las ventas de arroz pilado "));

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidaImporteTotal(string tipoComprobante, decimal valor)
        {
            throw new NotImplementedException();
        }

        public Tuple<bool, string> ValidaTipoCambio(decimal valor)
        {
            if(valor<0)
                return new Tuple<bool, string>(false,Errores.CampoInvalido("Tipo de Cambio",valor.ToString()));

            return new Tuple<bool, string>(true,"");
        }

        public Tuple<bool, string> ValidaFechaEmisionComprobanteModificado(string tipoComprobante, DateTime fechaModificada,
            string oportunidadAnotacion,DateTime fechaPeriodo)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaFechaModificada1"];
            var regla2 = ConfigurationManager.AppSettings["reglaFechaModificada1"];
            var fechaDefault = Formato.ObtieneFecha(ConfigurationManager.AppSettings["fechaDefault"],
                "DD/MM/AAAA");

            var tipoComprobantePermitido = regla1.Split(',');

            var obligatorio = (tipoComprobantePermitido.Any(x => x == tipoComprobante) && regla2 != oportunidadAnotacion);

            if(obligatorio && fechaDefault.Equals(fechaModificada))
                return new Tuple<bool, string>(false,Errores.CampoObligatorio("Fecha de Emisión del comprobante modificado"));

            if(!obligatorio)
                return new Tuple<bool, string>(true,ConfigurationManager.AppSettings["fechaDefault"]);

            if(DateTime.Compare(fechaModificada,fechaPeriodo)>0)
                return new Tuple<bool, string>(false, Errores.CampoInvalido("Fecha de Emisión del comprobante modificado",
                    Formato.FormateaFecha("DD/MM/AAAA",fechaModificada)));

            return new Tuple<bool, string>(true,"");
        }

        public Tuple<bool, string> ValidaTipoComprobanteModificado(string tipoComprobante,string oportunidadAnotacion)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaTipoComprobanteModificado1"];
            var regla2 = ConfigurationManager.AppSettings["reglaTipoComprobanteModificado2"];

            var tipoComprobantePermitido = regla1.Split(',');

            var obligatorio = (tipoComprobantePermitido.Any(x => x == tipoComprobante) && regla2 != oportunidadAnotacion);

            if(obligatorio && tipoComprobante=="00")
                return new Tuple<bool, string>(false,Errores.CampoObligatorio("Tipo Comprobante Modificado"));

            if (obligatorio && tipoComprobante != "00")
            {
                var valido = Globals.LstComprobante.Any(x => x.Codigo == tipoComprobante);

                if(!valido)
                    return new Tuple<bool, string>(false,Errores.CampoInvalido("Tipo Comprobante Modificado",tipoComprobante));
            }

            if(!obligatorio)
                return new Tuple<bool, string>(true,"00");

            return new Tuple<bool, string>(true,"");
        }

        public Tuple<bool, string> ValidaNumeroSerieComprobanteModificado(string tipoComprobante,
            string oportunidadAnotacion,string numeroSerieComprobante)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaNumeroSerieModificado1"];
            var regla2 = ConfigurationManager.AppSettings["reglaNumeroSerieModificado2"];

            var tipoComprobantePermitido = regla1.Split(',');

            var obligatorio = (tipoComprobantePermitido.Any(x => x == tipoComprobante) && regla2 != oportunidadAnotacion);

            if (obligatorio && (numeroSerieComprobante=="" || numeroSerieComprobante=="-"))
            {
                return new Tuple<bool, string>(false,Errores.CampoObligatorio("Número de Serie Modificado"));
            }
            
            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidarNumeroComprobanteModificado(string tipoComprobante, string numeroComprobanteModificado,
            string oportunidadAnotacion)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaComprobanteModificado1"];
            var regla2 = ConfigurationManager.AppSettings["reglaComprobanteModificado2"];

            var tipoComprobantePermitido = regla1.Split(',');

            var obligatorio = (tipoComprobantePermitido.Any(x => x == tipoComprobante) && regla2 != oportunidadAnotacion);

            if (obligatorio)
            {
                return new Tuple<bool, string>(true, "-");
            }
            else
            {
                if(numeroComprobanteModificado=="" || numeroComprobanteModificado=="-")
                    return new Tuple<bool, string>(false,Errores.CampoObligatorio("Numero de Comprobante Modificado"));

                //Validamos si es numerico
                if (Formato.ValidaNumericoPositivo(numeroComprobanteModificado))
                    return new Tuple<bool, string>(false, Errores.CampoPositivo("Numero de Comprobante Modificado",
                        numeroComprobanteModificado));
                    
            }

            return new Tuple<bool, string>(true,"");
        }

        public Tuple<bool, string> ValidaValorEmbarcadoExportacion(string tipoComprobanteModificado, decimal? valor)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaValorEmbarcadoExportacion1"];

            var valoresPermitidos = regla1.Split(',');

            if(valoresPermitidos.Any(x=>x==tipoComprobanteModificado) && valor==null)
                return new Tuple<bool, string>(false,Errores.CampoObligatorio("valor embarcado de exportacion"));
                
            return new Tuple<bool, string>(true,"");
        }

        public Tuple<bool, string> ValidaTicket(string ticket, string tipoDocumento,decimal monto)
        {
            var documentos = (ConfigurationManager
                                .AppSettings["ticketValido"])
                                .Split(',');
            var fecha = DateTime.Parse(ConfigurationManager.AppSettings["fechaTicketValido"]);
            var reglaMonto = decimal.Parse(ConfigurationManager.AppSettings["montoTicketValido"]);
            var documento = ConfigurationManager.AppSettings["ticketDocumento"];

            if (documentos.All(d => d != tipoDocumento) && !string.IsNullOrEmpty(ticket))
                return new Tuple<bool, string>(false, Errores.CampoInvalido("Tickets", ticket));

            if (DateTime.Compare(DateTime.Now, fecha) < 0)
                return new Tuple<bool, string>(true,string.Empty);

            if (DateTime.Compare(DateTime.Now, fecha) >= 0)
            {
                if (tipoDocumento == documento && monto>=reglaMonto)
                {
                    if (string.IsNullOrEmpty(ticket))
                        return new Tuple<bool, string>(false, Errores.CampoInvalido("Tickets", ticket));
                }
            }

            return new Tuple<bool, string>(true, string.Empty);
        }

        public Tuple<bool, string> ValidaTipoDocumento(string tipoComprobante, string oportunidadAnotacion,
            string tipoDocumento,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string tipoDocumentoCliente)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaTipoDocumentoCliente1"];
            var regla2 = ConfigurationManager.AppSettings["reglaTipoDocumentoCliente2"];
            var regla3 = ConfigurationManager.AppSettings["reglaTipoDocumentoCliente3"];
            var regla4 = ConfigurationManager.AppSettings["reglaTipoDocumentoCliente4"];
            var regla5 = Convert.ToDecimal(ConfigurationManager.AppSettings["reglaTipoDocumentoCliente5"]);
            var regla6 = Convert.ToDecimal(ConfigurationManager.AppSettings["montoTicketValido"]);

            var tipoComprobanteValidos = regla1.Split(',');
            var tipoComprobanteValidos1 = regla3.Split(',');
            var estadoAnotacionValidos = regla4.Split(',');

            var noObligatorio = tipoComprobanteValidos.Any(x => x == Formato.RellenaCodigo(tipoComprobante)) ||
                oportunidadAnotacion == regla2 ||
                (tipoComprobanteValidos1.Any(x => x == Formato.RellenaCodigo(tipoComprobante))
                && estadoAnotacionValidos.Any(x => x == oportunidadAnotacion))
                || valorFacturadoExportacion > regla5 || importeTotalComprobante < regla6;

            if (!noObligatorio && tipoDocumentoCliente.Trim() == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Tipo de Documento del Cliente"));

            if (tipoDocumentoCliente.Trim() != String.Empty)
            {
                if (Globals.LstTipoDocumento.All(x => x.Codigo != tipoDocumentoCliente))
                    return new Tuple<bool, string>(false, Errores.CampoInvalido("Tipo de Documento del Cliente", tipoDocumentoCliente));
            }

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidaNumeroDocumento(string tipoComprobante, string oportunidadAnotacion,
            decimal valorFacturadoExportacion, decimal importeTotalComprobante, string numeroDocumentoCliente, TipoDocumento tipoDocumento)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente1"];
            var regla2 = ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente2"];
            var regla3 = ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente3"];
            var regla4 = ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente4"];
            var regla5 = Convert.ToDecimal(ConfigurationManager.AppSettings["reglaNumeroDocumentoCliente5"]);
            var regla6 = Convert.ToDecimal(ConfigurationManager.AppSettings["montoTicketValido"]);

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
