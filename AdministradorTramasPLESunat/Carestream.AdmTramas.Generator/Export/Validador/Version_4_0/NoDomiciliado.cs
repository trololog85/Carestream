using Carestream.AdmTramas.Generator.Export.Validador.Interface;

namespace Carestream.AdmTramas.Generator.Export.Validador.Version_4_0
{
    public class NoDomiciliado: INoDomiciliado
    {
        private readonly ICommon _common;

        public NoDomiciliado(ICommon common)
        {
            _common = common;
        }
    }
}
