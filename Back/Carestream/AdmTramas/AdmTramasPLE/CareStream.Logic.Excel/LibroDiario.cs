using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareStream.Logic.Excel
{
    public class LibroDiario
    {
        public Int32 NumLinea { get; set; }
        public Int32 IdArchivoLog { get; set; }
        public DateTime Fecha { get; set; }
        public Int32 NumCorrelativo { get; set; }
        public String CodigoUnico { get; set; }
        public String Reference { get; set; }
        public String Cuenta { get; set; }
        public String Centro { get; set; }
        public String DescAsiento { get; set; }
        public Decimal Debe { get; set; }
        public Decimal Haber { get; set; }
    }
}
