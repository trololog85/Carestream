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
    
    public partial class Estructura
    {
        public short Id { get; set; }
        public short NumCampo { get; set; }
        public string Descripcion { get; set; }
        public string TipoDato { get; set; }
        public int PosicionInicial { get; set; }
        public int PosicionFinal { get; set; }
        public short Longitud { get; set; }
        public byte Obligatorio { get; set; }
        public short IdLibro { get; set; }
        public string Version { get; set; }
        public string Nombre { get; set; }
        public string NombreCampo { get; set; }
    
        public virtual Libro Libro { get; set; }
    }
}