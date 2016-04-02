using System;

namespace Carestream.AdmTramas.Model.Entities
{
    public class LibroDiarioDetalle
    {
        public DateTime FechaPeriodo { get; set; }
        public string CodigoCuentaContable { get; set; }
        public string DescripcionCuentaContable { get; set; }
        public string CodigoPlanCuenta { get; set; }
        public string DescripcionPlanCuenta { get; set; }
        public string Estado { get; set; }
        public int Linea { get; set; }
    }
}
