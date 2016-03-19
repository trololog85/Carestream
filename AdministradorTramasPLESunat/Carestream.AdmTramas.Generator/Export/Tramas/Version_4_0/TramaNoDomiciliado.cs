using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Version_4_0
{
    public class TramaNoDomiciliado
    {
        private readonly string separador = ConfigurationManager.AppSettings["separador"];

        public void GeneraTrama(List<RegistroNoDomiciliado> registros, RutaArchivo ruta)
        {
            var trama = new List<string>();
            string linea = null;

            foreach (var registro in registros)
            {
                linea = ArmaEstructura(registro);
                trama.Add(linea);
            }

            Archivo.GuardarTrama(trama, ruta);
        }

        private string ArmaEstructura(RegistroNoDomiciliado registro)
        {
            var trama = new StringBuilder();

            var fechaPeriodo = registro.Periodo;
            var cuo = registro.CUO;
            var correlativo = registro.NumeroCorrelativo;
            var fechaEmision = Formato.FormateaFecha("DD/MM/AAAA",(DateTime)registro.FechaEmision);
            var tipoComprobante = registro.TipoComprobante;
            var serieComprobante = registro.NumeroSerieComprobante;
            var numerComprobante = registro.NumeroComprobante;
            var valorAdquisicion = registro.ValorAdquisicion;
            var otrosConceptos = registro.OtrosConceptos;
            var importeTotal = registro.ImporteTotalAdquisicion;
            var tipoComprobanteFiscal = registro.TipoComprobanteFiscal;
            var serieComprobanteFiscal = registro.NumeroSerieComprobanteFiscal;
            var anioEmisionDUA = registro.AnioEmisionDUA;
            var numeroComprobanteFisco = registro.NumeroComprobanteDUA;
            var montoIGV = registro.IGV;
            var moneda = registro.Moneda;
            var tipoCambio = registro.TipoCambio;
            var pais = registro.Pais;
            var razonSocial = registro.RazonSocial;
            var domicilio = registro.Domicilio;
            var numeroIdentificacion = registro.NumeroIdentificacionSujeto;
            var numeroIdentificacionFiscal = registro.NumeroIdentificacionFiscal;
            var razonSocialBeneficiario = registro.RazonSocialBeneficiario;
            var paisBeneficiario = registro.PaisBeneficiario;
            var vinculo = registro.Vinculo;
            var rentaBruta = registro.RentaBruta;
            var deduccion = registro.Deduccion;
            var rentaNeta = registro.RentaNeta;
            var tasaRetencion = registro.TasaRetencion;
            var impuestoRetenido = registro.ImpuestoRetenido;
            var convenios = registro.Convenio;
            var exoneracion = registro.ExoneracionAplicada;
            var tipoRenta = registro.TipoRenta;
            var modalidadServicio = registro.ServicioPrestado;
            var articulo76 = registro.Campo35;
            var estado = registro.Estado;

            trama.Append(fechaPeriodo);
            trama.Append(separador);
            trama.Append(cuo);
            trama.Append(separador);
            trama.Append(correlativo);
            trama.Append(separador);
            trama.Append(fechaEmision);
            trama.Append(separador);
            trama.Append(tipoComprobante);
            trama.Append(separador);
            trama.Append(serieComprobante);
            trama.Append(separador);
            trama.Append(numerComprobante);
            trama.Append(separador);
            trama.Append(valorAdquisicion);
            trama.Append(separador);
            trama.Append(otrosConceptos);
            trama.Append(separador);
            trama.Append(importeTotal);
            trama.Append(separador);
            trama.Append(tipoComprobanteFiscal);
            trama.Append(separador);
            trama.Append(serieComprobanteFiscal);
            trama.Append(separador);
            trama.Append(anioEmisionDUA);
            trama.Append(separador);
            trama.Append(numeroComprobanteFisco);
            trama.Append(separador);
            trama.Append(montoIGV);
            trama.Append(separador);
            trama.Append(moneda);
            trama.Append(separador);
            trama.Append(tipoCambio);
            trama.Append(separador);
            trama.Append(pais);
            trama.Append(separador);
            trama.Append(razonSocial);
            trama.Append(separador);
            trama.Append(domicilio);
            trama.Append(separador);
            trama.Append(numeroIdentificacion);
            trama.Append(separador);
            trama.Append(numeroIdentificacionFiscal);
            trama.Append(separador);
            trama.Append(razonSocialBeneficiario);
            trama.Append(separador);
            trama.Append(paisBeneficiario);
            trama.Append(separador);
            trama.Append(vinculo);
            trama.Append(separador);
            trama.Append(rentaBruta);
            trama.Append(separador);
            trama.Append(deduccion);
            trama.Append(separador);
            trama.Append(rentaNeta);
            trama.Append(separador);
            trama.Append(tasaRetencion);
            trama.Append(separador);
            trama.Append(impuestoRetenido);
            trama.Append(separador);
            trama.Append(convenios);
            trama.Append(separador);
            trama.Append(exoneracion);
            trama.Append(separador);
            trama.Append(tipoRenta);
            trama.Append(separador);
            trama.Append(modalidadServicio);
            trama.Append(separador);
            trama.Append(articulo76);
            trama.Append(separador);
            trama.Append(estado);
            trama.Append(separador);

            return trama.ToString();
        }
    }
}
