using System;
using System.Collections.Generic;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Entities;
using LibroMayor = Carestream.AdmTramas.Model.Campos.LibroMayor;

namespace Carestream.AdmTramas.Generator.Export.Validador
{
    public class ValidadorLibroMayor
    {
        private readonly ILibroMayor _libroMayor;

        public ValidadorLibroMayor(ILibroMayor libroMayor)
        {
            _libroMayor = libroMayor;
        }

        public List<Error> ValidaRegistros(List<Model.Entities.LibroMayor> libroDiario)
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

        private Error Validar(Model.Entities.LibroMayor libroMayor)
        {
            var error = new Error();

            var errorDetalle = new List<ErrorDetalle>();
            var result = new Tuple<bool, string>(false, "");

            var fechaPeriodo = libroMayor.FechaPeriodo;
            var debe = libroMayor.Debe;
            var haber = libroMayor.Haber;

            //1. Valida Fecha Periodo
            //result = _libroMayor.ValidaFechaPeriodo(fechaPeriodo);

            RegistraError(errorDetalle, LibroMayor.FechaPeriodo, result, libroMayor.NumLinea);

            result = _libroMayor.ValidaMontos(debe, haber);

            RegistraError(errorDetalle, LibroMayor.Montos, result, libroMayor.NumLinea);

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
