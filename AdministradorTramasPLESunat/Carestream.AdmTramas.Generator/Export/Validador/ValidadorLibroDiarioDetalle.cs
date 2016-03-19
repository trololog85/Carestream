using System;
using System.Collections.Generic;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Generator.Export.Validador
{
    public class ValidadorLibroDiarioDetalle
    {
        private readonly ILibroDiarioDetalles _libroDiario;
        private long _idLibroLog;

        public ValidadorLibroDiarioDetalle(ILibroDiarioDetalles libroDiario)
        {
            _libroDiario = libroDiario;
        }
        public List<Error> ValidaRegistros(List<LibroDiarioDetalle> libroDiario)
        {
            var errores = new List<Error>();

            Error error = null; 

            foreach (var libro in libroDiario)
            {
                error = Validar(libro);
                if (error.Detalles.Count > 0)
                    errores.Add(error);
            }

            return errores;
        }

        private Error Validar(LibroDiarioDetalle diarioDetalle)
        {
            var error = new Error();

            var errorDetalle = new List<ErrorDetalle>();
            var result = new Tuple<bool, string>(false, "");

            var fechaPeriodo = diarioDetalle.FechaPeriodo;
            var cuenta = diarioDetalle.CodigoCuentaContable;
            var linea = diarioDetalle.Linea;

            //1. Valida Fecha Periodo
            result = _libroDiario.ValidaPeriodo(fechaPeriodo);

            RegistraError(errorDetalle, Model.Campos.LibroDiarioDetalle.Periodo, result,linea);

            //2. NumeroCuenta
            result = _libroDiario.ValidaCuentaContable(cuenta);

            RegistraError(errorDetalle, Model.Campos.LibroDiarioDetalle.CodigoCuentaContable, result, linea);

            error.Detalles = errorDetalle;

            return error;
        }

        private void RegistraError(ICollection<ErrorDetalle> lstErrorDetalle, string campo, Tuple<bool, string> result,
            int linea)
        {
            if (!result.Item1)
            {
                var error = new ErrorDetalle
                {
                    Linea = linea,
                    Mensaje = result.Item2,
                    Campo = campo
                };

                lstErrorDetalle.Add(error);
            }
        }
    }
}
