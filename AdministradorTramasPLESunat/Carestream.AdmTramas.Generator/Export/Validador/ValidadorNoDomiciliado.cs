using System.Collections.Generic;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Generator.Export.Validador
{
    public class ValidadorNoDomiciliado
    {
        private readonly INoDomiciliado _iValidadorNoDomiciliado;
        private long _idLibroLog;

        public ValidadorNoDomiciliado(INoDomiciliado iValidadorNoDomiciliado)
        {
            _iValidadorNoDomiciliado = iValidadorNoDomiciliado;
        }

        public List<Error> ValidaRegistros(List<RegistroNoDomiciliado> registroVentas)
        {
            var errores = new List<Error>();

            return errores;
        }
    }
}
