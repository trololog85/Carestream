using System;

namespace Carestream.AdmTramas.Generator.Export.Validador.Interface
{
    public interface ILibroDiario
    {
        Tuple<bool, string> ValidaPeriodo(DateTime periodoInformado);
        Tuple<bool,string> ValidaDebeHaber(decimal debe,decimal haber);
        Tuple<bool, string> ValidaFechaOperacion(DateTime fechaOperacion, DateTime fechaPeriodo);
    }
}
