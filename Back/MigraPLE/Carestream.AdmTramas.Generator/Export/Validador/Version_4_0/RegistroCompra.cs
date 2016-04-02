using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Generator.Export.Mensajes;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Tipos;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_4_0
{
    public class RegistroCompra:IRegistroCompra
    {
        private readonly ICommon _common;

        public RegistroCompra(ICommon common)
        {
            _common = common;
        }

        public Tuple<bool, string> ValidaFechaPeriodo(DateTime periodoInformado)
        {
            return _common.ValidaFechaPeriodo(periodoInformado);
        }

        public Tuple<bool, string> ValidaFechaEmision(DateTime fechaEmision)
        {
            if(DateTime.Compare(fechaEmision,Globals.PeriodoInformado)>0)
                return new Tuple<bool, string>(false,
                Errores.CampoInvalido("Fecha de Emisión del Comprobante", fechaEmision.ToString(CultureInfo.InvariantCulture)));

            return new Tuple<bool, string>(true, String.Empty);
        }

        public Tuple<bool,string> ValidaFechaVencimiento(DateTime fechaVencimiento, string tipoComprobante,
            DateTime fechaPeriodo)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaFechaVenc1"];
            var regla2 = DateTime.Parse(ConfigurationManager.AppSettings["reglaFechaVenc2"]);

            if (tipoComprobante == regla1 && fechaVencimiento == regla2)
            {
                return new Tuple<bool, string>(false,
                    Errores.CampoObligatorio("Fecha de vencimiento"));
            }

            if (fechaVencimiento == regla2)
                return new Tuple<bool, string>(true, String.Empty);

            var mesFechaVencimiento = fechaVencimiento.Month;
            var mesPeriodoInformado = Globals.PeriodoInformado.Month + 1;
            var mesPeriodo = fechaPeriodo.Month + 1;

            if(mesFechaVencimiento > mesPeriodoInformado)
                return new Tuple<bool, string>(false,
                    Errores.CampoInvalido("Fecha de vencimiento", Formato.FormateaFecha("DD/MM/AAAA", fechaVencimiento)));

            if(mesFechaVencimiento > mesPeriodo)
                return new Tuple<bool, string>(false,
                    Errores.CampoInvalido("Fecha de vencimiento", Formato.FormateaFecha("DD/MM/AAAA", fechaVencimiento)));

            return new Tuple<bool, string>(true, String.Empty);
        }

        public Tuple<bool, string> ValidaTipoComprobante(string tipoComprobante)
        {
            return _common.ValidaTipoComprobante(tipoComprobante);
        }

        public Tuple<bool, string> ValidaNumeroSerieComprobante(TipoDocumento tipoDocumentoCliente, string numeroDocumentoCliente, string numeroSerie)
        {
            return _common.ValidaNumeroSerieComprobante(tipoDocumentoCliente, numeroDocumentoCliente, numeroSerie);
        }

        public Tuple<bool, string> ValidaAnioEmisionDua(DateTime fechaEmision, string tipoComprobante, DateTime periodo)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaFechaEmisionDua1"];
            var regla2 = Int32.Parse(ConfigurationManager.AppSettings["reglaFechaEmisionDua2"]);

            var tipoComprobantePermitido = regla1.Split(',');
            var anioDua = fechaEmision.Year;
            var anioPeriodoInformado = Globals.PeriodoInformado.Year;
            var anioPeriodo = periodo.Year;

            if (tipoComprobantePermitido.Any(x=>x==tipoComprobante) && (anioDua < regla2 || anioDua > anioPeriodoInformado || anioDua > anioPeriodo))
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Fecha de Emisión del Comprobante"));

            return new Tuple<bool, string>(true, String.Empty);
        }
        
        public Tuple<bool, string> ValidaNumeroComprobante(TipoDocumento tipoDocumento, string numeroDocumento, string numeroComprobante)
        {
            return _common.ValidaNumeroComprobante(tipoDocumento, numeroDocumento, numeroComprobante);
        }

        public Tuple<bool, string> ValidaTipoDocumentoCliente(string tipoComprobante,string tipoDocumento,
            string tipoDocumentoCliente, string tipoComprobanteModificado)
        {
            return _common.ValidaTipoDocumentoCliente(tipoComprobante, tipoDocumentoCliente, tipoComprobanteModificado);
        }

        public Tuple<bool, string> ValidaNumeroDocumentoCliente(string tipoComprobante,
            string numeroDocumentoCliente, TipoDocumento tipoDocumento, string tipoComprobanteModificado)
        {
            return _common.ValidaNumeroDocumentoCliente(tipoComprobante,
                numeroDocumentoCliente, tipoDocumento, tipoComprobanteModificado);
        }

        public Tuple<bool, string> ValidaNombreApellido(string tipoComprobante,string nombreApellido,
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

            if (!noObligatorio && nombreApellido.Trim() == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Nombre del Cliente"));

            return new Tuple<bool, string>(true, "");
        }

        public Tuple<bool, string> ValidaTipodeCambio(decimal tipoDeCambio)
        {
            if (tipoDeCambio < 0)
                return new Tuple<bool, string>(false,
                    Errores.CampoPositivo("Tipo de Cambio", tipoDeCambio.ToString(CultureInfo.InvariantCulture)));

            return new Tuple<bool, string>(true,String.Empty);
        }

        public Tuple<bool, string> ValidaFechaEmisionModificada(string tipoComprobante, DateTime fechaMod)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaFechaEmisionMod1"];
            var regla2 = DateTime.Parse(ConfigurationManager.AppSettings["reglaFechaEmisionMod2"]);

            var tipoComprobanteValido = regla1.Split(',');

            var obligatorio = tipoComprobanteValido.Any(x => x == Formato.RellenaCodigo(tipoComprobante));

            if(obligatorio && regla2.Equals(fechaMod))
                return new Tuple<bool, string>(false,Errores.CampoObligatorio("Fecha de Emisión que se modifica."));

            if (DateTime.Compare(fechaMod, Globals.PeriodoInformado) > 0 || DateTime.Compare(fechaMod, Globals.PeriodoInformado) > 0)
                return new Tuple<bool, string>(false, Errores.CampoInvalido("Fecha de Emisión que se modifica.",Formato.FormateaFecha("DD/MM/AAAA",fechaMod)));

            return new Tuple<bool, string>(true,String.Empty);
        }

        public Tuple<bool, string> ValidaTipoComprobanteModificada(string tipoComprobante, string tipoComprobanteModificado)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaTipoComprobanteMod1"];

            var tipoComprobanteValido = regla1.Split(',');

            var obligatorio = tipoComprobanteValido.Any(x => x == Formato.RellenaCodigo(tipoComprobante));

            if (obligatorio && tipoComprobanteModificado == String.Empty)
                return new Tuple<bool, string>(false,Errores.CampoObligatorio("Tipo de Comprobante que se Modifica"));

            return new Tuple<bool, string>(true,String.Empty);
        }

        public Tuple<bool, string> ValidaNumeroSerieComprobanteModificado(string tipoComprobante, string numSerieComprobanteModificado)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaTipoComprobanteMod1"];

            var tipoComprobanteValido = regla1.Split(',');

            var obligatorio = tipoComprobanteValido.Any(x => x == Formato.RellenaCodigo(tipoComprobante));

            if (obligatorio && numSerieComprobanteModificado == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Numero de Serie del Comprobante que se Modifica"));

            return new Tuple<bool, string>(true, String.Empty);
        }

        public Tuple<bool, string> ValidaCodigoDUA(string tipoComprobanteModificado, string codigoDUA)
        {
            if(tipoComprobanteModificado==String.Empty)
                return new Tuple<bool, string>(true,String.Empty);

            var valido = Globals.LstCodigoAduana.Any(x => x.Codigo == Formato.RellenaCodigo(tipoComprobanteModificado));

            if(!valido)
                return new Tuple<bool, string>(false,
                    Errores.CampoInvalido("Tipo de Comprobante que se modifica.",tipoComprobanteModificado));

            var regla1 = ConfigurationManager.AppSettings["reglaCodigoDUA"];

            var tipoComprobanteValido = regla1.Split(',');

            var obligatorio = tipoComprobanteValido.Any(x => x == tipoComprobanteModificado);

            if(obligatorio && codigoDUA==String.Empty)
                return new Tuple<bool, string>(false,Errores.CampoObligatorio("Código de la Dependencia Aduanera"));

            return new Tuple<bool, string>(true,String.Empty);
        }

        public Tuple<bool, string> ValidaNumeroComprobanteModificado(string tipoComprobante, string numeroComprobanteModificado)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaTipoComprobanteMod1"];

            var tipoComprobanteValido = regla1.Split(',');

            var obligatorio = tipoComprobanteValido.Any(x => x == Formato.RellenaCodigo(tipoComprobante));

            if (obligatorio && numeroComprobanteModificado == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Número de Comprobante que se Modifica"));

            return new Tuple<bool, string>(true, String.Empty);
        }

        public Tuple<bool, string> ValidaNumeroComprobanteNoDomiciliado(string tipoComprobante, string numeroComprobanteNoDomic)
        {
            var regla1 = ConfigurationManager.AppSettings["reglaTipoComprobanteMod1"];

            var tipoComprobanteValido = regla1.Split(',');

            var obligatorio = tipoComprobanteValido.Any(x => x == Formato.RellenaCodigo(tipoComprobante));

            if (obligatorio && numeroComprobanteNoDomic == String.Empty)
                return new Tuple<bool, string>(false, Errores.CampoObligatorio("Número de Comprobante no Domiciliado"));

            return new Tuple<bool, string>(true, String.Empty);
        }

        public Tuple<bool, string> ValidaFechaEmisionConstancia(DateTime fechaPeriodo,DateTime fechaEmision)
        {
            if(fechaEmision==DateTime.Parse("1900-01-01"))
                return new Tuple<bool, string>(false,"");

            var mesPeriodoInformado = Globals.PeriodoInformado.Month + 1;
            var mesPeriodo = fechaPeriodo.Month + 1;
            var mesEmision = fechaEmision.Month;

            if (mesEmision > mesPeriodoInformado || mesEmision > mesPeriodo)
                return new Tuple<bool, string>(false,
                    Errores.CampoInvalido("Fecha de Emisión", Formato.FormateaFecha("DD/MM/AAAA", fechaEmision)));
            

            return new Tuple<bool, string>(true, String.Empty);
        }
    }
}
