using System;
using Carestream.AdmTramas.Generator.Export.Mensajes;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_4_0
{
    public class LibroDiarioDetalle:ILibroDiarioDetalles
    {
        private readonly ICommon _common;

        public LibroDiarioDetalle(ICommon common)
        {
            _common = common;
        }

        public Tuple<bool, string> ValidaPeriodo(DateTime periodoInformado)
        {
            return _common.ValidaFechaPeriodo(periodoInformado);
        }

        public Tuple<bool, string> ValidaCuentaContable(string cuentaContable)
        {
            var len = cuentaContable.Length;

            if(len<3 || len>24)
                return new Tuple<bool, string>(false,
                    Errores.CampoLongitudInvalida("Codigo Cuenta Contable",cuentaContable));

            return new Tuple<bool, string>(true,string.Empty);
        }
    }
}
