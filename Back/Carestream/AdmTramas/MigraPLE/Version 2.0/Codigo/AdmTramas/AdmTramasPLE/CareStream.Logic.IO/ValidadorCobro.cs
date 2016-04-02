using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Utils;
using CareStream.Data.Access;
using System.Configuration;

namespace CareStream.Logic.IO
{
    public class ValidadorCobro
    {
        public static String ObtienePeriodo(DateTime fecha)
        {
            Int32 mes = fecha.Month;
            Int32 anio = fecha.Year;

            return anio.ToString() + Formato.RellenaNumero(mes).ToString() + "00";
        }

        public static String ObtieneFechaEmisionComprobante(DateTime fecha)
        {
            return Formato.FormateaFecha("DD/MM/AAAA", fecha);
        }

        public static Boolean ValidaFechaVencimiento(DateTime fecha, String tipo_comp)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaFechaVenc"].ToString();
            DateTime dt = DateTime.Parse(ConfigurationManager.AppSettings["fechaVacia"].ToString());

            if (tipo_comp == regla1 && fecha == dt)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static String ObtieneFechaVencimiento(DateTime fecha)
        {
            DateTime dt = DateTime.Parse(ConfigurationManager.AppSettings["fechaVacia"].ToString());

            if (fecha == dt)
            {
                return ConfigurationManager.AppSettings["defaultDate"].ToString();
            }
            else
            {
                return Formato.FormateaFecha("DD/MM/AAAA", fecha);
            }
        }

        public static Boolean ValidaTipoComprobante(String tipo_comp)
        {
            return Validador.BuscaTipoComprobante(tipo_comp);
        }

        public static Boolean ValidaSerieComprobante(String num_serie, String tipo_comprobante)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresComp"].ToString();
            String regla2 = ConfigurationManager.AppSettings["reglaComp2"].ToString();
            Int32 long1 = Int32.Parse(ConfigurationManager.AppSettings["longMin"].ToString());
            Int32 long2 = Int32.Parse(ConfigurationManager.AppSettings["longMax1"].ToString());
            Int32 long3 = Int32.Parse(ConfigurationManager.AppSettings["long3"].ToString());

            /*if (regla1.IndexOf(tipo_comprobante) != -1)
            {
                if (num_serie.Length != long1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (regla2.IndexOf(tipo_comprobante) != -1)
            {
                if (num_serie.Length != long3 || !Validador.ValidaCodigoAduana(num_serie))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (num_serie.Length > long2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }*/

            return true;
        }

        public static String ObtieneNumeroSerie(String tipo_comp, String num_serie)
        {
            String valor = num_serie;

            String regla1 = ConfigurationManager.AppSettings["valoresComp"].ToString();
            String regla2 = ConfigurationManager.AppSettings["reglaComp2"].ToString();
            Int32 long1 = Int32.Parse(ConfigurationManager.AppSettings["longMin"].ToString());
            Int32 long2 = Int32.Parse(ConfigurationManager.AppSettings["longMax1"].ToString());
            Int32 long3 = Int32.Parse(ConfigurationManager.AppSettings["long3"].ToString());

            Int32 num = -1;

            if (Int32.TryParse(num_serie, out num))
            {
                //Regla para longitud 4
                if (regla1.IndexOf(tipo_comp) != -1)
                {
                    valor = Formato.RellenaNumero(num, 4, "0");
                }
                else if (regla2.IndexOf(tipo_comp) != -1)
                {
                    valor = Formato.RellenaNumero(num, 3, "0");
                }
            }
            else
            {
                valor = num_serie;
            }

            return valor;
        }

        public static Boolean ValidaAnioEmision(Int32 anio, String tipo_comprobante)
        {
            String regla2 = ConfigurationManager.AppSettings["reglaComp2"].ToString();
            Int32 anioMin = Int32.Parse(ConfigurationManager.AppSettings["anioMin"].ToString());

            if (tipo_comprobante == String.Empty)
            {
                return true;
            }
            else
            {
                if (regla2.IndexOf(Formato.RellenaNumero(Int32.Parse(tipo_comprobante))) != -1 && anio < anioMin)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static String ObtieneAnioEmision(Int32 anio, String tipo_comprobante)
        {
            String regla2 = ConfigurationManager.AppSettings["reglaComp2"].ToString();
            String vald = ConfigurationManager.AppSettings["defaultTipoDoc"].ToString();

            if (tipo_comprobante == String.Empty)
            {
                return vald;
            }
            else
            {
                if (regla2.IndexOf(Formato.RellenaNumero(Int32.Parse(tipo_comprobante))) == -1)
                {
                    return vald;
                }
                else
                {
                    return anio.ToString();
                }
            }
        }

        public static Boolean ValidaNumerodeComprobante(String num_comprobante)
        {
            Int64 p = 0;

            if (Int64.TryParse(num_comprobante, out p))
            {
                if (Int64.Parse(num_comprobante) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static Boolean ValidaTipoDocumento(String tipo_comp, String tipo_doc,String tipo_doc_mod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_d"].ToString();
            String regla2 = ConfigurationManager.AppSettings["valoresFechaEmis"].ToString();
            String regla3 = ConfigurationManager.AppSettings["valoresTipoDoc_c_24"].ToString();

            if (regla1.IndexOf(tipo_comp) != -1 || (regla2.IndexOf(tipo_comp)!=-1 && regla3.IndexOf(tipo_doc_mod)!=-1))
            {
                //Quiere decir que no es obligatorio

                //Validamos el valor con la siguiente funcion
                return true;
            }
            else
            {
                //Quiere decir que es obligatorio
                if (tipo_doc == String.Empty)
                {
                    return false;
                }
                else
                { 
                    //tiene un valor validamos con la tabla
                    return Validador.BuscaTipoDocumento(tipo_doc);
                }
            }
        }

        public static String ObtieneTipoDocumento(String tipo_doc)
        {
            if (tipo_doc == String.Empty || tipo_doc == "-")
            {
                return ConfigurationManager.AppSettings["defaultTipoDoc"].ToString();
            }
            else
            {
                return tipo_doc;
            }
        }

        public static Boolean ValidaNumDocumento(String numero_documento, String tipo_comp, String tipo_comp_mod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_d"].ToString();
            String regla2 = ConfigurationManager.AppSettings["valoresFechaEmis"].ToString();
            String regla3 = ConfigurationManager.AppSettings["valoresTipoDoc_c_24"].ToString();

            if (regla1.IndexOf(tipo_comp) != -1 || (regla2.IndexOf(tipo_comp) != -1 && regla3.IndexOf(tipo_comp_mod) != -1))
            {
                //Quiere decir que no es obligatorio

                //Validamos el valor con la siguiente funcion
                return true;
            }
            else
            {
                //Quiere decir que es obligatorio
                if (numero_documento == String.Empty)
                {
                    return false;
                }
            }

            return true;
        }

        public static String ObtieneNumDocumento(String numero_documento)
        {
            if (numero_documento == String.Empty)
            {
                return ConfigurationManager.AppSettings["defaultNumDoc"].ToString();
            }
            else
            {
                return numero_documento;
            }
        }

        public static Boolean ValidaNombre(String nombre, String tipo_comp, String tipo_comp_mod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_d"].ToString();
            String regla2 = ConfigurationManager.AppSettings["valoresFechaEmis"].ToString();
            String regla3 = ConfigurationManager.AppSettings["valoresTipoDoc_c_24"].ToString();

            if (regla1.IndexOf(tipo_comp) != -1 || (regla2.IndexOf(tipo_comp) != -1 && regla3.IndexOf(tipo_comp_mod) != -1))
            {
                //Quiere decir que no es obligatorio

                //Validamos el valor con la siguiente funcion
                return true;
            }
            else
            {
                //Quiere decir que es obligatorio
                if (nombre == String.Empty)
                {
                    return false;
                }
            }

            return true;
        }

        public static String ObtieneNombre(String nombre)
        {
            if (nombre == String.Empty)
            {
                return ConfigurationManager.AppSettings["defaultNumDoc"].ToString();
            }
            else
            {
                return nombre;
            }
        }

        public static Boolean ValidaDecimal(Decimal baseImp, String tipo_comp)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(tipo_comp) == -1 && baseImp < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static String ObtieneValor(Decimal valor)
        {
            if (valor == -1)
            {
                return ConfigurationManager.AppSettings["defaultValor"].ToString();
            }
            else
            {
                return valor.ToString();
            }
        }

        public static Boolean ValiaCompNoDomic(String comprobante)
        {
            Int64 p = 0;

            if (Int64.TryParse(comprobante, out p))
            {
                if (Int64.Parse(comprobante) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static String ObtieneCompNoDomic(String comprobante, String tipo_comp)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaComp"].ToString();

            if (regla1.IndexOf(tipo_comp) != -1)
            {
                return comprobante;
            }
            else
            {
                return ConfigurationManager.AppSettings["defaultNumDoc"].ToString();
            }
        }

        public static String ObtieneFechaEmision(DateTime fechaEmision, String num_constancia)
        {
            String regla = ConfigurationManager.AppSettings["numDefault"].ToString();
            DateTime fechaVacia = DateTime.Parse(ConfigurationManager.AppSettings["fechaVacia"]);

            if (num_constancia != regla)
            {
                if (fechaEmision == fechaVacia)
                {
                    return ConfigurationManager.AppSettings["defaultDate"].ToString();
                }
                else
                {
                    return Formato.FormateaFecha("DD/MM/AAAA", fechaEmision);
                }
            }
            else
            {
                return ConfigurationManager.AppSettings["defaultDate"].ToString();
            }
        }

        public static String ObtieneNumeroConstancia(String num_constancia)
        {
            if (num_constancia != String.Empty)
            {
                return num_constancia;
            }
            else
            {
                return ConfigurationManager.AppSettings["numDefault"].ToString();
            }
        }

        public static String ObtieneMarcaComprobante(Decimal retencion)
        { 
            Decimal valor = Decimal.Parse(ConfigurationManager.AppSettings["numDefault"].ToString());

            if (retencion == valor)
            {
                return ConfigurationManager.AppSettings["defaultCampo32"].ToString();
            }
            else
            {
                return ConfigurationManager.AppSettings["defaultTipoDoc"].ToString();
            }
        }

        public static String ObtieneEstadoRegistro(DateTime fechaPeriodo, DateTime fechaEmision)
        {
            String fijo = ConfigurationManager.AppSettings["fijo"].ToString();


            DateTime dt1 = new DateTime(fechaPeriodo.Year,fechaPeriodo.Month,1);
            DateTime dt2 = new DateTime(fechaEmision.Year,fechaEmision.Month,1);

            if (dt1.CompareTo(dt2)>0)
            {
                return "6";
            }
            else
            {
                return fijo;
            }
        
        
        
        }

        public static Boolean ValidaFechaEmisionMod(String tipo_comprobante, DateTime periodoInformado,DateTime fechaMod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"];

            Boolean rpta = true;

            if (regla1.IndexOf(Formato.RellenaNumero(Int32.Parse(tipo_comprobante))) != -1)
            {
                if (periodoInformado == DateTime.Parse("1900-01-01"))
                {
                    rpta = false;
                }
                else
                {
                    if (fechaMod.CompareTo(periodoInformado) > 0)
                    {
                        rpta = false;
                    }
                }
            }

            return rpta;
        }

        public static String ObtieneFechaEmisionMod(String tipo_comprobante, DateTime fechaMod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"];
            String fechaDefault = ConfigurationManager.AppSettings["defaultFecha"];

            if (regla1.IndexOf(Formato.RellenaNumero(Int32.Parse(tipo_comprobante))) != -1)
            {
                if (fechaMod == DateTime.Parse("1900-01-01"))
                {
                    return fechaDefault;
                }
                
                return Formato.FormateaFecha("DD/MM/AAAA",fechaMod);
            }
            else
            {
                return fechaDefault;
            }
        }

        public static Boolean ValidaTipoComprobanteMod(String tipo_comprobante, String tipo_comp_mod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"];

            Boolean rpta = true;

            if (regla1.IndexOf(Formato.RellenaNumero(Int32.Parse(tipo_comprobante))) != -1)
            {
                if (tipo_comp_mod == String.Empty)
                {
                    rpta = false;
                }
                else
                {
                    rpta = Validador.BuscaTipoComprobante(Formato.RellenaNumero(Int32.Parse(tipo_comp_mod)));
                }
            }

            return rpta;
        }

        public static String ObtieneTipoComprobanteMod(String tipo_comprobante, String tipo_comp_mod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"];
            String def = ConfigurationManager.AppSettings["tipoCompDefault"];

            if (regla1.IndexOf(Formato.RellenaNumero(Int32.Parse(tipo_comprobante))) != -1)
            {
                return Formato.RellenaNumero(Int32.Parse(tipo_comp_mod));
            }
            else
            {
                return def;
            }

        }

        public static String ObtieneNumeroSerieCompMod(String num_serie_comp_mod)
        {
            String def = ConfigurationManager.AppSettings["defaultNumDoc"];

            if (num_serie_comp_mod == String.Empty)
            {
                return def;
            }
            else
            {
                return num_serie_comp_mod;
            }
        }

        public static Boolean ValidaNumComprobanteMod(String tipo_comprobante,String num_comprobante_mod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"];

            Boolean rpta = true;

            if (regla1.IndexOf(Formato.RellenaNumero(Int32.Parse(tipo_comprobante))) != -1)
            {
                if (num_comprobante_mod == String.Empty)
                {
                    rpta = false;
                }
            }

            return rpta;
        }

        public static String ObtieneNumComprobanteMod(String num_comprobante_mod)
        {
            String def = ConfigurationManager.AppSettings["defaultNumDoc"];

            if (num_comprobante_mod == String.Empty)
            {
                return def;
            }
            else
            {
                return num_comprobante_mod;
            }
        }
    }
}
