using System;

namespace Carestream.AdmTramas.Generator.Export.Validador.Interface
{
    public interface ILibroDiarioDetalles
    {
        Tuple<bool, string> ValidaPeriodo(DateTime periodoInformado);
        Tuple<bool, string> ValidaCuentaContable(string cuentaContable);
    }
}
