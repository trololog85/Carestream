﻿using System;

namespace Carestream.AdmTramas.Model.Entities
{
    public class RegistroNoDomiciliado
    {
        public int IdLibroLog { get; set; }
        public int Linea { get; set; }
        public short IdLibro { get; set; }
        public string Periodo { get; set; }
        public string CUO { get; set; }
        public string NumeroCorrelativo { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public string TipoComprobante { get; set; }
        public string NumeroSerieComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public Nullable<decimal> ValorAdquisicion { get; set; }
        public Nullable<decimal> OtrosConceptos { get; set; }
        public decimal ImporteTotalAdquisicion { get; set; }
        public string TipoComprobanteFiscal { get; set; }
        public string NumeroSerieComprobanteFiscal { get; set; }
        public string AnioEmisionDUA { get; set; }
        public string NumeroComprobanteDUA { get; set; }
        public Nullable<decimal> IGV { get; set; }
        public string Moneda { get; set; }
        public Nullable<decimal> TipoCambio { get; set; }
        public string Pais { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string NumeroIdentificacionSujeto { get; set; }
        public string NumeroIdentificacionFiscal { get; set; }
        public string RazonSocialBeneficiario { get; set; }
        public string PaisBeneficiario { get; set; }
        public string Vinculo { get; set; }
        public Nullable<decimal> RentaBruta { get; set; }
        public Nullable<decimal> Deduccion { get; set; }
        public Nullable<decimal> RentaNeta { get; set; }
        public Nullable<decimal> TasaRetencion { get; set; }
        public Nullable<decimal> ImpuestoRetenido { get; set; }
        public string Convenio { get; set; }
        public string ExoneracionAplicada { get; set; }
        public string TipoRenta { get; set; }
        public string ServicioPrestado { get; set; }
        public string Campo35 { get; set; }
        public string Estado { get; set; }
    }
}
