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
    
    public partial class LibroDiario_ConsultarPorPeriodo_Result
    {
        public int Linea { get; set; }
        public int IdLibroLog { get; set; }
        public System.DateTime Fecha { get; set; }
        public int NumeroCorrelativo { get; set; }
        public string CodigoUnico { get; set; }
        public string Referencia { get; set; }
        public string Cuenta { get; set; }
        public string Centro { get; set; }
        public string DescripcionAsiento { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public short IdLibro { get; set; }
    }
}