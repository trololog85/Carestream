//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Carestream.AdmTramas.DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class LibroDiarioDetalle
    {
        public int Linea { get; set; }
        public int IdLibroLog { get; set; }
        public System.DateTime Periodo { get; set; }
        public string CuentaContable { get; set; }
        public string DescripcionCuenta { get; set; }
        public string CodigoPlanCuenta { get; set; }
        public string DescripcionPlanCuenta { get; set; }
        public string Estado { get; set; }
        public short IdLibro { get; set; }
    
        public virtual LibroLog LibroLog { get; set; }
    }
}