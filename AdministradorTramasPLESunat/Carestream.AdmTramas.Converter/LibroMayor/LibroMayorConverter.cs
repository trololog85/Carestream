using System;
using System.Collections.Generic;
using System.Linq;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.Converter.LibroMayor
{
    public class LibroMayorConverter
    {
        public static List<Model.Entities.LibroMayor> ConvertList(
            IEnumerable<DataAccess.Model.LibroMayor> libroMayor)
        {
            var converLst = libroMayor.Select(ConvertOut).ToList();

            return converLst;
        }

        private static Model.Entities.LibroMayor ConvertOut(DataAccess.Model.LibroMayor libroMayor)
        {
            return new Model.Entities.LibroMayor
            {
                CodigoCuentaContable = libroMayor.CodigoCuentaContable,
                CodigoUnicoOperacion = libroMayor.codunicooperacion,
                CorrelativoCompras = string.Empty,
                CorrelativoConsignaciones = string.Empty,
                CorrelativoVentas = string.Empty,
                Debe = libroMayor.Debe,
                Estado = libroMayor.Estado,
                FechaOperacion = libroMayor.FechaOperacion,
                FechaPeriodo = libroMayor.Periodo,
                Glosa = libroMayor.Glosa,
                Haber = libroMayor.Haber,
                NumLinea = libroMayor.Linea,
                NumeroCorrelativo = libroMayor.NumeroCorrelativo,
                CodigoPlanCuenta = libroMayor.CodigoPlanCuenta
            };
        }
    }
}
