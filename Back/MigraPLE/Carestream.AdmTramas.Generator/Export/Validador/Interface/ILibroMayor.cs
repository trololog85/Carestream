using System;

namespace Carestream.AdmTramas.Generator.Export.Validador.Interface
{
    public interface ILibroMayor
    {
        Tuple<bool, string> ValidaFechaPeriodo(DateTime fechaPeriodo);
        Tuple<bool, string> ValidaMontos(decimal debe,decimal haber);
    }
}
