using System.Collections.Generic;
using System.Linq;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Converter.LibroDiarioDetalle
{
    public class LibroDiarioDetalleConverter
    {
        public static List<Model.Entities.LibroDiarioDetalle> ConvertList(
            IEnumerable<DataAccess.Model.LibroDiarioDetalle> registroCompra)
        {
            var converLst = registroCompra.Select(ConvertOut).ToList();

            return converLst;
        }

        private static Model.Entities.LibroDiarioDetalle ConvertOut(DataAccess.Model.LibroDiarioDetalle libroDiario)
        {
            return new Model.Entities.LibroDiarioDetalle
            {
                FechaPeriodo = libroDiario.Periodo,
                CodigoCuentaContable = libroDiario.CuentaContable,
                DescripcionCuentaContable = libroDiario.DescripcionCuenta,
                CodigoPlanCuenta = Formato.RellenaCodigo(libroDiario.CodigoPlanCuenta.Trim()),
                DescripcionPlanCuenta = libroDiario.DescripcionPlanCuenta,
                Estado = libroDiario.Estado,
                Linea = libroDiario.Linea
            };
        }
    }
}
