﻿using System;

namespace Carestream.AdmTramas.Model.Entities
{
    public class LibroMayor
    {
        public string FechaPeriodo { get; set; }
        public string CodigoUnicoOperacion { get; set; }
        public string NumeroCorrelativo { get; set; }
        public string CodigoCuentaContable { get; set; }
        public DateTime FechaOperacion { get; set; }
        public string Glosa { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public string CorrelativoVentas { get; set; }
        public string CorrelativoCompras { get; set; }
        public string CorrelativoConsignaciones { get; set; }
        public string Estado { get; set; }
        public int NumLinea { get; set; }
        public string CodigoPlanCuenta { get; set; }
        public string Moneda { get; set; }
        public string TipoDocumentoEmisor { get; set; }
        public string NumeroDocumentoEmisor { get; set; }
        public string TipoComprobante { get; set; }
        public string NumeroSerieComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public DateTime FechaContable { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoLibro { get; set; }
    }
}
