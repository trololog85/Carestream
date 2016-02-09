using System;
using System.Globalization;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Generator.Export.Mensajes;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_4_0
{
    public class LibroDiario : ILibroDiario
    {
        private readonly ICommon _common;

        public LibroDiario(ICommon common)
        {
            _common = common;
        }

        public Tuple<bool, string> ValidaPeriodo(DateTime periodoInformado)
        {
            return _common.ValidaFechaPeriodo(periodoInformado);
        }

        public Tuple<bool, string> ValidaDebeHaber(decimal debe, decimal haber)
        {
            if (debe < 0)
                return new Tuple<bool, string>(false,
                    Errores.CampoPositivo("Debe", debe.ToString(CultureInfo.InvariantCulture)));

            if (haber < 0)
                return new Tuple<bool, string>(false,
                    Errores.CampoPositivo("Haber", debe.ToString(CultureInfo.InvariantCulture)));

            if (haber == 0 && debe == 0)
                return new Tuple<bool, string>(false,
                    Errores.CampoInvalido("Debe/Haber", "Debe es 0 y Haber es 0"));

            return new Tuple<bool, string>(true, String.Empty);
        }

        public Tuple<bool, string> ValidaFechaOperacion(DateTime fechaOperacion, DateTime fechaPeriodo)
        {
            if (DateTime.Compare(fechaOperacion, Globals.PeriodoInformado) > 0)
                return new Tuple<bool, string>(false,
                    Errores.CampoInvalido("Fecha de la Operación", Formato.FormateaFecha("DD/MM/AAAA", fechaOperacion)));

            if (DateTime.Compare(fechaOperacion, fechaPeriodo) > 0)
                return new Tuple<bool, string>(false,
                    Errores.CampoInvalido("Fecha de la Operación", Formato.FormateaFecha("DD/MM/AAAA", fechaOperacion)));

            return new Tuple<bool, string>(true, String.Empty);
        }
    }
}
