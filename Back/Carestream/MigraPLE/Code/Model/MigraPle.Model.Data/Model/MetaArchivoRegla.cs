//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MigraPle.DataAccess.Sql.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MetaArchivoRegla
    {
        public int idRegla { get; set; }
        public int idMetaArchivo { get; set; }
        public bool activo { get; set; }
    
        public virtual MetaArchivo MetaArchivo { get; set; }
        public virtual Regla Regla { get; set; }
    }
}
