using System;
using System.Collections.Generic;
using Carestream.AdmTramas.Generator.Export.Validador.Interface;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Generator.Export.Validador
{
    public class ValidadorLibroDiario
    {
        private readonly ILibroDiario _libroDiario;
        private long _idLibroLog;

        public ValidadorLibroDiario(ILibroDiario libroDiario)
        {
            _libroDiario = libroDiario;
        }

        public List<Error> ValidaRegistros(List<LibroDiario> libroDiario)
        {
            var errores = new List<Error>();

            Error error = null;

            foreach (var libro in libroDiario)
            {
                error = Validar(libro);
                if(error.Detalles.Count>0) 
                    errores.Add(error);
            }

            return errores;
        }

        private Error Validar(LibroDiario libroDiario)
        {
            var error = new Error();

            var errorDetalle = new List<ErrorDetalle>();
            var result = new Tuple<bool, string>(false, "");

            var fechaPeriodo = libroDiario.FechaPeriodo;
            var fechaOperacion = libroDiario.FechaOperacion;
            var debe = libroDiario.Debe;
            var haber = libroDiario.Haber;
            _idLibroLog = libroDiario.IdLibroLog;

            //1.Fecha Periodo
            result = _libroDiario.ValidaPeriodo(fechaPeriodo);

            RegistraError(errorDetalle, "Fecha Periodo", result, libroDiario.NumeroLinea);

            //2.Fecha Operacion
            result = _libroDiario.ValidaFechaOperacion(fechaOperacion, fechaPeriodo);

            RegistraError(errorDetalle, "Fecha Periodo", result, libroDiario.NumeroLinea);

            //3.Validar Debe y Haber
            result = _libroDiario.ValidaDebeHaber(debe, haber);

            RegistraError(errorDetalle, "Deber/Haber", result, libroDiario.NumeroLinea);

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
                    Campo = campo,
                    IdLibroLog = _idLibroLog
                };

                lstErrorDetalle.Add(error);
            }
        }
    }
}
