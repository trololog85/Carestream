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
    
    public partial class Libro
    {
        public Libro()
        {
            this.LibroLogs = new HashSet<LibroLog>();
            this.Estructuras = new HashSet<Estructura>();
            this.RegistroNoDomiciliadoes = new HashSet<RegistroNoDomiciliado>();
        }
    
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    
        public virtual ICollection<LibroLog> LibroLogs { get; set; }
        public virtual ICollection<Estructura> Estructuras { get; set; }
        public virtual ICollection<RegistroNoDomiciliado> RegistroNoDomiciliadoes { get; set; }
    }
}
