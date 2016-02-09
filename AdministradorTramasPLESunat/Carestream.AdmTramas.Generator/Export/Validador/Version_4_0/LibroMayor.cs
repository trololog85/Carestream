using System;
using System.Globalization;
using Carestream.AdmTramas.Generator.Export.Mensajes;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_4_0
{
    public class LibroMayor:ILibroMayor
    {
        private readonly ICommon _common;

        public LibroMayor(ICommon common)
        {
            _common = common;
        }

        public Tuple<bool, string> ValidaFechaPeriodo(DateTime fechaPeriodo)
        {
            return _common.ValidaFechaPeriodo(fechaPeriodo);
        }

        public Tuple<bool, string> ValidaMontos(decimal debe, decimal haber)
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
    }
}
