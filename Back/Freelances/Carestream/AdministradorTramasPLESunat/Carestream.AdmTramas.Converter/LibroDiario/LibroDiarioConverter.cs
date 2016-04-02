using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Carestream.AdmTramas.Common;

namespace Carestream.AdmTramas.Converter.LibroDiario
{
    public class LibroDiarioConverter
    {
        public static List<Model.Entities.LibroDiario> ConvertList(IEnumerable<DataAccess.Model.LibroDiario> libroDiario)
        {
            var converLst = libroDiario.Select(ConvertOut).ToList();

            return converLst;
        }

        private static Model.Entities.LibroDiario ConvertOut(DataAccess.Model.LibroDiario libroDiario)
        {
            return new Model.Entities.LibroDiario
            {
                FechaPeriodo = Globals.PeriodoInformado,
                CodigoUnicoOperacion = libroDiario.CodigoUnico,
                NumeroCorrelativoContable = libroDiario.Correlativo,
                CodigoPlanCuentas = ConfigurationManager.AppSettings["PlanContable"],
                CodigoCuentaContable = libroDiario.Cuenta,
                FechaOperacion = libroDiario.Fecha,
                Glosa = libroDiario.DescripcionAsiento,
                Debe = libroDiario.Debe,
                Haber = libroDiario.Haber,
                CorrelativoVentas = String.Empty,
                CorrelativoCompras = String.Empty,
                CorrelativoConsignaciones = String.Empty,
                EstadoOperacion = libroDiario.estado,
                IdLibroLog = libroDiario.IdLibroLog,
                NumeroLinea = libroDiario.Linea
            };
        }
    }
}
