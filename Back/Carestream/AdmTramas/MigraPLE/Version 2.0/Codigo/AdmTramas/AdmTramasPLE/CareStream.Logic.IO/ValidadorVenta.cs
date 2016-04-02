using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Utils;
using CareStream.Data.Access;
using System.Configuration;

namespace CareStream.Logic.IO
{
    public class ValidadorVenta
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

        public static Boolean ValidaTipoComprobante(Int32 tipo_comp)
        {
            return Validador.BuscaTipoComprobante(Formato.RellenaNumero(tipo_comp));
        }

        public static String ObtieneTipoComprobante(Int32 tipo_doc)
        {
            if (tipo_doc == -1)
            {
                return ConfigurationManager.AppSettings["tipoCompDefault"].ToString();
            }
            else 
            {
                return Formato.RellenaNumero(tipo_doc);
            }
        }

        public static Boolean ValidaNumSerie(Int32 tipo_comp,String numSerie)
        {
            Boolean rpta = true;

            String regla1 = ConfigurationManager.AppSettings["valoresComp"].ToString();

            /*if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1)
            {
                if (numSerie.Length > 4)
                {
                    rpta = false;
                }
            }
            else
            {
                if (numSerie.Length > 20)
                {
                    rpta = false;
                }
            }*/

            return rpta;
        }

        public static String ObtieneNumSerie(Int32 tipo_comp, String numSerie)
        {
            if (tipo_comp == Int32.Parse(ConfigurationManager.AppSettings["numDefault"].ToString()))
            {
                return ConfigurationManager.AppSettings["defaultNumDoc"].ToString();
            }
            else
            {
                return numSerie;
            }
        }

        public static Boolean ValidaTipoDocumento(Int32 tipo_comp, String tipo_doc,Decimal valor_fact_exp)
        {
            Boolean rpta = true;

            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_a"].ToString();
            String regla2 = ConfigurationManager.AppSettings["campo27Default"].ToString();
            String valor2 = ConfigurationManager.AppSettings["valoresTipoDoc_b"].ToString();
            String regla3 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();


            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1 && regla2 != valor2 &&
                regla3.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1 && valor_fact_exp <= 0)
            {
                //Quiere decir que debe ser obligatorio
                if (tipo_doc == String.Empty)
                {
                    return false;
                }
                else
                {
                    //Al existir un valor validamos con la tabla 10
                    return Validador.BuscaTipoDocumento(tipo_doc);
                }
            }
            else
            { 
                //En caso sea opcional se valida si existe

                if (tipo_doc != String.Empty && tipo_doc!="0")
                {
                    //Al existir un valor validamos con la tabla 10
                    return Validador.BuscaTipoDocumento(tipo_doc);
                }
            }
            
            return rpta;
        }
        
        public static String ObtieneTipoDocumento(String tipo_doc,String num_ruc,String nombre)
        {
            String defAnu = ConfigurationManager.AppSettings["validaAnulado"];

            if (num_ruc == String.Empty || nombre.Trim() == defAnu)
            {
                return "0";
            }

            //Previamente si validó la regla, solo se comprueba el valor

            if (tipo_doc == String.Empty)
            {
                return ConfigurationManager.AppSettings["defaultTipoDoc"].ToString();
            }
            else
            {
                return tipo_doc;
            }
        }

        public static Boolean ValidaNumDocumento(Int32 tipo_comp, String num_documento, Decimal valor_fact_exp,
            String tipo_doc)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_a"].ToString();
            String regla2 = ConfigurationManager.AppSettings["campo27Default"].ToString();
            String valor2 = ConfigurationManager.AppSettings["valoresTipoDoc_b"].ToString();
            String regla3 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();
            String regla4 = ConfigurationManager.AppSettings["valoresTipoDoc_c_24"].ToString();

            CodigoDetalle cod = Validador.ObtieneTipoDocumento(tipo_doc);

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1 && regla2 != valor2 &&
                regla3.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1 && valor_fact_exp <= 0)
            {
                return Validador.ValidaNumDocumentoTipoDoc(Int32.Parse(cod.campo1), Convert.ToChar(cod.campo2),
                Convert.ToChar(cod.campo3), num_documento);
            }
            else
            {
                return true;
            }
        }

        public static String ObtieneNumDocumento(String num_documento)
        {
            //Previamente si validó la regla, solo se comprueba el valor

            if (num_documento == String.Empty)
            {
                return ConfigurationManager.AppSettings["defaultNumDoc"].ToString();
            }
            else
            {
                return num_documento;
            }
        }

        public static Boolean ValidaNombreApellido(Int32 tipo_comp, String nombreApe, Decimal valor_fact_exp)
        {
            Boolean rpta = true;

            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_a"].ToString();
            String regla2 = ConfigurationManager.AppSettings["campo27Default"].ToString();
            String valor2 = ConfigurationManager.AppSettings["valoresTipoDoc_b"].ToString();
            String regla3 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();


            /*if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1 && regla2 != valor2 &&
                regla3.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1 && valor_fact_exp <= 0)
            {
                //Quiere decir que debe ser obligatorio
                if (nombreApe == String.Empty)
                {
                    return false;
                }
                else
                {
                    //Al existir un valor validamos con la tabla 10
                    return Validador.BuscaTipoDocumento(nombreApe);
                }
            }
            else
            {
                //En caso sea opcional se valida si existe
                if (nombreApe != String.Empty)
                {
                    //Al existir un valor validamos con la tabla 10
                    return BuscaTipoDocumento(nombreApe);
                }
            }*/

            return rpta;
        }

        public static String ObtieneNombreApellido(String nombreApe)
        {
            //Previamente si validó la regla, solo se comprueba el valor

            if (nombreApe == String.Empty)
            {
                return ConfigurationManager.AppSettings["defaultNombApe"].ToString();
            }
            else
            {
                return nombreApe;
            }
        }

        public static Boolean ValidaValorFacturadoExp(Int32 tipo_comp,Decimal valor)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1)
            {
                //No deberia aceptar negativos        
                if (valor < 0)
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
                return true;
            }
        }

        public static String ObtieneValorFacturaExp(Decimal valor)
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

        public static Boolean ValidaBaseImponible(Int32 tipo_comp, Decimal valor)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1)
            {
                //No deberia aceptar negativos        
                if (valor < 0)
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
                return true;
            }
        }

        public static String ObtieneBaseImponible(Decimal valor)
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

        public static Boolean ValidaImporteTotalEx(Int32 tipo_comp, Decimal valor)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1)
            {
                //No deberia aceptar negativos        
                if (valor < 0)
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
                return true;
            }
        }

        public static String ObtieneImporteTotalEx(Decimal valor)
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

        public static Boolean ValidaImporteTotalIn(Int32 tipo_comp, Decimal valor)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1)
            {
                //No deberia aceptar negativos        
                if (valor < 0)
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
                return true;
            }
        }

        public static String ObtieneImporteTotlIn(Decimal valor)
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

        public static Boolean ValidaISC(Int32 tipo_comp, Decimal valor)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1)
            {
                //No deberia aceptar negativos        
                if (valor < 0)
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
                return true;
            }
        }

        public static String ObtieneISC(Decimal valor)
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

        public static Boolean ValidaIGV(Int32 tipo_comp, Decimal valor)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1)
            {
                //No deberia aceptar negativos        
                if (valor < 0)
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
                return true;
            }
        }

        public static String ObtieneIGV(Decimal valor)
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

        public static Boolean ValidaIVAP(Int32 tipo_comp, Decimal valor)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1)
            {
                //No deberia aceptar negativos        
                if (valor < 0)
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
                return true;
            }
        }

        public static String ObtieneIVAP(Decimal valor)
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

        public static Boolean ValidaImporteTotal(Int32 tipo_comp, Decimal valor)
        {
            String regla1 = ConfigurationManager.AppSettings["reglaImporte"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) == -1)
            {
                //No deberia aceptar negativos        
                if (valor < 0)
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
                return true;
            }
        }

        public static String ObtieneImporteTotal(Decimal valor)
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

        public static String ObtieneTipoCambio(Decimal valor)
        {
            if (valor == -1)
            {
                return ConfigurationManager.AppSettings["defaultTipoCambio"].ToString();
            }
            else
            {
                return valor.ToString();
            }
        }

        public static String ObtieneFechaEmisionComprobante(Int32 tipo_comp,DateTime fecha)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresFechaEmis"].ToString();
            String regla2 = ConfigurationManager.AppSettings["campo27Default"].ToString();
            String valor = ConfigurationManager.AppSettings["valoresTipoDoc_b"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1 && regla2 != valor)
            {
                return Formato.FormateaFecha("DD/MM/AAAA", fecha);
            }
            else
            {
                return ConfigurationManager.AppSettings["defaultFecha"].ToString();
            }
        }

        public static String ObtieneFechaEmisionModificada(DateTime fechaEmision, Int32 tipo_comp)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();
            String regla2 = ConfigurationManager.AppSettings["reglaCampo27"].ToString();
            String valor = ConfigurationManager.AppSettings["valoresTipoDoc_b"].ToString();
            String valor1 = ConfigurationManager.AppSettings["validaTipoComp"].ToString();

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1 && valor!=regla2)
            {
                return Formato.FormateaFecha("DD/MM/AAAA", fechaEmision);
            }
            else
            {
                if (fechaEmision != DateTime.Parse("1900-01-01"))
                {
                    return Formato.FormateaFecha("DD/MM/AAAA", fechaEmision);
                }
                else
                {
                    return ConfigurationManager.AppSettings["defaultDate"].ToString();
                }
            }
        }

        public static Boolean ValidaTipoComprobanteMod(Int32 tipo_comp, String tipo_comp_mod,String razon_social)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();
            String regla2 = "1";
            String valorAnulado = ConfigurationManager.AppSettings["validaAnulado"].ToString();
            String valor = ConfigurationManager.AppSettings["valoresTipoDoc_b"].ToString();
            String default24 = ConfigurationManager.AppSettings["campo24Default"].ToString();

            if (valorAnulado == razon_social.Trim())
            {
                regla2 = "2";
            }

            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1 && regla2 != valor)
            {
                if (tipo_comp_mod == String.Empty)
                {
                    return false;
                }
                else
                { 
                    if (Formato.RellenaNumero(Int32.Parse(tipo_comp_mod)) == default24)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        public static String ObtieneTipoComprobanteMod(String tipo_comp_mod)
        {
            if (tipo_comp_mod.Trim() == String.Empty)
            {
                return ConfigurationManager.AppSettings["tipoCompDefault"].ToString();
            }
            else
            {
                return Formato.RellenaNumero(Int32.Parse(tipo_comp_mod));
            }
        }

        public static Boolean ValidaSerieComprobanteMod(Int32 tipo_comp, String tipo_comp_mod,String num_serie_comp)
        {
            Boolean rpta = true;

            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();
            String regla2 = ConfigurationManager.AppSettings["campo27Default"].ToString();
            String valor = ConfigurationManager.AppSettings["valoresTipoDoc_b"].ToString();
            String valor1 = ConfigurationManager.AppSettings["validaTipoComp"].ToString();
            String defCampo24 = ConfigurationManager.AppSettings["defaultCampo24"].ToString();

            //Validacion de valor
            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1 && regla2 != valor && 
                   tipo_comp_mod != defCampo24)
            {
                if(num_serie_comp.Trim() == String.Empty)
                {
                    rpta = false;
                }
            }

            //Validacion de Longitud
            String reglaLong1 = ConfigurationManager.AppSettings["reglaLong"].ToString();
            String reglaLong2 = ConfigurationManager.AppSettings["reglaLong1"].ToString();
            Int32 lmin = Int32.Parse(ConfigurationManager.AppSettings["longMin"].ToString());
            Int32 lmax = Int32.Parse(ConfigurationManager.AppSettings["longMax"].ToString());
            Int32 longMax1 = Int32.Parse(ConfigurationManager.AppSettings["longMax1"].ToString());

            //Regla1
            /*if (reglaLong1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1)
            {
                if (num_serie_comp.Length != lmin && num_serie_comp.Length != lmax)
                {
                    rpta = false;
                }
            }

            //Regla2
            if (reglaLong2.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1)
            {
                if (num_serie_comp.Length > longMax1)
                {
                    rpta = false;
                }
            }*/

            //Regla4
            Int64 p =0;

            if (Int64.TryParse(num_serie_comp, out p))
            {
                if (Int64.Parse(num_serie_comp) < 0)
                {
                    rpta = false;
                }
            }

            return rpta;
        }

        public static Boolean ValidarNumeroComprobanteMod(Int32 tipo_comp, String tipo_comp_mod, String num_comp_mod,
            String razon_social)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();
            String campo24 = ConfigurationManager.AppSettings["reglaCampo24"].ToString();
            String campo27 = ConfigurationManager.AppSettings["reglaCampo27"].ToString();
            String defcampo24 = ConfigurationManager.AppSettings["defaultCampo24"].ToString();
            String valor_anulado = ConfigurationManager.AppSettings["validaAnulado"].ToString();
            String estado = "1";

            if(razon_social == valor_anulado)
            {
                estado = campo27;
            }

            //Si se cumple el campo no puede ser "-"
            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1 && estado != campo27 && tipo_comp_mod != defcampo24)
            {
                if (num_comp_mod.Trim() == String.Empty)
                {
                    return false;
                }
                else
                { 
                    //al tener valor validamos si es numerico y si es positivo
                    Int64 p = 0;

                    if (Int64.TryParse(num_comp_mod, out p))
                    {
                        if (Int64.Parse(num_comp_mod) < 0)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static String ObtieneNumeroSerieMod(Int32 tipo_comp,String tipo_comp_mod, String num_serie_comp)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();
            String regla2 = ConfigurationManager.AppSettings["campo27Default"].ToString();
            String valor = ConfigurationManager.AppSettings["valoresTipoDoc_b"].ToString();
            String valor1 = ConfigurationManager.AppSettings["validaTipoComp"].ToString();
            String defaultStr = ConfigurationManager.AppSettings["defaultNumDoc"].ToString();

            //Validacion de valor
            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1 && regla2 != valor && tipo_comp_mod != valor1)
            {
                //Validamos si tiene valor
                return num_serie_comp;
            }
            else
            {
                return defaultStr;
            }
        
        }

        public static String ObtieneNumComprobanteMod(String num_comp_mod)
        {
            String defaultStr = ConfigurationManager.AppSettings["defaultNumDoc"].ToString();

            if (num_comp_mod == String.Empty)
            {
                return defaultStr;
            }
            else
            {
                return num_comp_mod;
            }
        }

        public static Boolean ValidaFechaModificada(Int32 tipo_comp, String razon_social,DateTime fecha_mod)
        {
            String regla1 = ConfigurationManager.AppSettings["valoresTipoDoc_c_5"].ToString();
            String regla2 = ConfigurationManager.AppSettings["reglaCampo27"].ToString();
            String valorAnulado = ConfigurationManager.AppSettings["validaAnulado"].ToString();

            String valor = "1";

            if (valorAnulado == razon_social.Trim())
            {
                valor = "2";
            }

            //Validamos la regla
            if (regla1.IndexOf(Formato.RellenaNumero(tipo_comp), 0) != -1 && regla2 != valor)
            {
                if (fecha_mod == DateTime.Parse("1900-01-01"))
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
                return true;
            }
        }
    }
}
