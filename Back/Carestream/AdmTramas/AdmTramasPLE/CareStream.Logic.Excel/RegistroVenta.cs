using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareStream.Logic.Excel
{
    public class RegistroVenta
    {
        public Int32 NumCorrelativo { get; set; }
        public DateTime FechaComprobante { get; set; }
        public Int32 TipoComprobante { get; set; }
        public Int64 InternoComprobante { get; set; }
        public String SerieComprobante { get; set; }
        public String NumComprobante { get; set; }
        public Char TipoDocumento {get;set;}
        public String NumDocumento { get; set; }
        public String CodigoDoc { get; set; }
        public String NombRazSocial { get; set; }
        public Decimal ValorVentaOrig { get; set; }
        public String MonedaValorVenta { get; set; }
        public Decimal TipoCambio { get; set; }
        public Decimal VV { get; set; }
        public Decimal IGV { get; set; }
        public Decimal PV { get; set; }
        public DateTime FechaMod { get; set; }
        public String TipoMod { get; set; }
        public String SerieMod { get; set; }
        public String NumMod { get; set; }
        public Decimal VVMod { get; set; }
        public Decimal IGVMod { get; set; }
        public Decimal PVMod { get; set; }
        public Int32 Id_Archivo_Log { get; set; }
        public Int32 Num_Linea { get; set; }
        public String Num_Unico_Ope { get; set; }
        public Decimal Ope_No_Gravada { get; set; }
        public Char Estado { get; set; }
    }
}
