using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareStream.Logic.Excel
{
    public class LibroMayor
    {
        public Int32 Num_Linea { get; set; }
        public Int32 Id_Archivo_Log { get; set; }
        public String NumDoc { get; set; }
        public String Tipos { get; set; }
        public DateTime FechaOpe { get; set; }
        public Decimal Importe { get; set; }
        public String SubTotal { get; set; }
        public String Cuenta { get; set; }
        public String GL { get; set; }
        public Decimal Debito { get; set; }
        public Decimal Credito { get; set; }
        public Decimal Saldo { get; set; }
        public String Referencia { get; set; }
        public Int64 Item { get; set; }
        public String Descripcion { get; set; }
        public String Glosa { get; set; }
    }
}
