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
    
    public partial class LibroDiarioAgrupado
    {
        public int Linea { get; set; }
        public int IdLibroLog { get; set; }
        public Nullable<short> IdLibro { get; set; }
        public string CodigoUnico { get; set; }
        public string Correlativo { get; set; }
    
        public virtual LibroLog LibroLog { get; set; }
    }
}
