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
    
    public partial class LibroLog_ListaLibroDiario_Result
    {
        public int id { get; set; }
        public short IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public Nullable<System.DateTime> FechaCarga { get; set; }
        public Nullable<System.DateTime> FechaGeneracion { get; set; }
        public int Registros { get; set; }
        public string RUC { get; set; }
        public string IndicadorOperacion { get; set; }
        public string IndicadorMoneda { get; set; }
        public string IndicadorLibro { get; set; }
        public string TipoLog { get; set; }
        public Nullable<int> Errores { get; set; }
        public Nullable<System.DateTime> FechaPeriodo { get; set; }
    }
}