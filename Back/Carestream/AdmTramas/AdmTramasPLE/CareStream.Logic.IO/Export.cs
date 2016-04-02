using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;
using System.IO;
using System.Configuration;
using CareStream.Utils;
using CareStream.Logic.IO;


namespace CareStream.Logic.IO
{
    public class Export
    {
        private DAArchivoLogDetalle objDArchivoLog = new DAArchivoLogDetalle(); 
        private ErrorLineaDetalle error = new ErrorLineaDetalle();
        private ArchivoLogDetalle logDetalle = new ArchivoLogDetalle();

        public String GenerarArchivoRegistroVentas(String rutaArchivo,Int32 id_archivo, String cod_archivo,String num_ruc,Int32 id_ope,Int32 id_libro,String id_moneda,
            Int32 mes,Int32 anio,Int32 id_archivo_log)
        {
            //Registramos la carga
            DAInputDetalle objDA = new DAInputDetalle();

            List<InputRegistroVenta> lst = objDA.ObtieneDetalleExport(mes, anio, id_archivo_log);

            //Guardamos la carga cabecera
            ArchivoLog objArchLog = new ArchivoLog();
            objArchLog.id_archivo = id_archivo;
            objArchLog.fecha_carga = DateTime.Now;
            objArchLog.cant_registros = lst.Count;
            objArchLog.tipo_ope = "E";
            objArchLog.nombre_carga = ObtieneNombreArchivo(num_ruc, anio, mes, cod_archivo, id_ope, id_libro, id_moneda);


            DAArchivoLog objDALog = new DAArchivoLog();

            Int32 i = objDALog.Guardar(objArchLog);

            //Generamos el archivo
            List<InfoEstructura> lstInfo = Obtiene(cod_archivo);
            
            List<String> lstExport = new List<String>();

            Char separador = Convert.ToChar(ConfigurationManager.AppSettings["separador"].ToString());

            StringBuilder registro = new StringBuilder();

            InfoEstructura info = new InfoEstructura();

            String defaultString = ConfigurationManager.AppSettings["defaultNumDoc"].ToString();

            Validador.CargaTipoDocumento();
            Validador.CargaTipoComprobante();

            List<ErrorLineaDetalle> lstErrores = new List<ErrorLineaDetalle>();
            ErrorLineaDetalle error;
            Boolean bError = false;

            String valor = ConfigurationManager.AppSettings["validaAnulado"].ToString();

            foreach(InputRegistroVenta reg in lst)
            {
                bError = false;

                registro = new StringBuilder();

                //SOLO CONSIDERAR LOS REGISTROS QUE NO ESTAN ANULADOS
                //1.Periodo
                registro.Append(ValidadorVenta.ObtienePeriodo(Convert.ToDateTime(reg.fecha_comprobante)));
                registro.Append(separador);

                //2.NumCorrelativo
                info = ObtieneInfoEstructura("COR", lstInfo);

                if (Validador.ValidaPipe(reg.num_unico_ope))
                {
                    if (ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.num_comprobante.ToString()))
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El campo Numero Correlativo: {0} está fuera de la longitud permitida.", reg.num_comprobante);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Numero Correlativo";

                        lstErrores.Add(error);
                    }
                    else
                    {
                        registro.Append(reg.num_unico_ope);
                        registro.Append(separador);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El campo Numero Correlativo: {0} contiene el caracter pipe.", reg.interno_comprobante);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Numero Correlativo";

                    lstErrores.Add(error);
                }

                //3.Fecha de Emision del Comprobante
                registro.Append(ValidadorVenta.ObtieneFechaEmisionComprobante(Convert.ToDateTime(reg.fecha_comprobante)));
                registro.Append(separador);

                //4.Fecha de Vencimiento
                registro.Append(ConfigurationManager.AppSettings["defaultDate"].ToString());
                registro.Append(separador);

                //5.Tipo de Comprobante
                if (ValidadorVenta.ObtieneTipoComprobante(Convert.ToInt32(reg.tipo_comprobante)) != defaultString)
                {
                    if (ValidadorVenta.ValidaTipoComprobante(Convert.ToInt32(reg.tipo_comprobante)))
                    {
                        registro.Append(Formato.RellenaNumero(Convert.ToInt32(reg.tipo_comprobante)));
                        registro.Append(separador);
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El tipo de Comprobante: {0} no es válido.", reg.tipo_comprobante);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Tipo de Comprobante";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    registro.Append(defaultString);
                    registro.Append(separador);
                }

                //6.Numero de Serie del Comprobante
                if (Validador.ValidaPipe(reg.serie_comprobante.ToString()))
                {
                    if (ValidadorVenta.ObtieneNumSerie(Convert.ToInt32(reg.tipo_comprobante), reg.serie_comprobante) != defaultString)
                    {
                        if (ValidadorVenta.ValidaNumSerie(Convert.ToInt32(reg.tipo_comprobante), reg.serie_comprobante))
                        {
                            registro.Append(Formato.RellenaNumero(Convert.ToInt32(reg.serie_comprobante),4,"0"));
                            registro.Append(separador);
                        }
                        else
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("El número de serie del Comprobante: {0} no es válido.", reg.serie_comprobante);
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Número de Serie Comprobante";

                            lstErrores.Add(error);
                        }
                    }
                    else
                    {
                        registro.Append(defaultString);
                        registro.Append(separador);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El número de serie del Comprobante: {0} contiene el caracter pipe.", reg.serie_comprobante);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Número de Serie Comprobante";

                    lstErrores.Add(error);
                }

                //7.Numero del comprobante de pago
                if (Validador.ValidaPipe(reg.num_comprobante.ToString()))
                {
                    info = ObtieneInfoEstructura("NUMC", lstInfo);

                    if (ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.num_comprobante.ToString()))
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El número de comprobante: {0} no es válido.", reg.num_comprobante);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Número de Comprobante";

                        lstErrores.Add(error);
                    }
                    else
                    {
                        registro.Append(reg.num_comprobante);
                        registro.Append(separador);
                    }

                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El número de comprobante: {0} contiene el caracter pipe.", reg.num_comprobante);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Número de Comprobante";

                    lstErrores.Add(error);
                }

                //8.Registro de tickets
                registro.Append(ConfigurationManager.AppSettings["numDefault"].ToString());
                registro.Append(separador);

                //9.Tipo de documento de Identidad
                if (Validador.ValidaPipe(reg.tipo_documento.ToString()))
                {
                    if (ValidadorVenta.ValidaTipoDocumento(Convert.ToInt32(reg.tipo_comprobante),
                                        reg.tipo_documento.ToString(), Convert.ToDecimal(reg.pv)))
                    {
                        registro.Append(ValidadorVenta.ObtieneTipoDocumento(reg.tipo_documento,reg.num_documento,reg.nombre_razon_social));
                        registro.Append(separador);
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El Tipo de Documento: {0} no es válido.", reg.tipo_documento);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Tipo de Documento";

                        lstErrores.Add(error);
                    }

                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Tipo de Documento: {0} contiene el caracter pipe.", reg.tipo_documento);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Tipo de Documento";

                    lstErrores.Add(error);
                }

                //10.Numero de documento de identidad del cliente
                if (Validador.ValidaPipe(reg.num_documento.ToString()))
                {
                    if (ValidadorVenta.ValidaNumDocumento(Convert.ToInt32(reg.tipo_comprobante),
                    reg.num_documento, Convert.ToDecimal(reg.pv), reg.tipo_documento))
                    {
                        info = ObtieneInfoEstructura("NUMD", lstInfo);

                        if (ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.num_documento.ToString()))
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("El Número de Documento: {0} no cumple con la longitud.", reg.serie_comprobante);
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Número de Documento";

                            lstErrores.Add(error);
                        }
                        else
                        {
                            registro.Append(ValidadorVenta.ObtieneNumDocumento(reg.num_documento));
                            registro.Append(separador);
                        }
                    }
                    else
                    {
                        if (reg.nombre_razon_social.Trim() == "ANULADO" && reg.num_documento.Length == 0)
                        {
                            registro.Append(ConfigurationManager.AppSettings["defaultNumDoc"]);
                            registro.Append(separador);

                        }
                        else
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("El Número de Documento: {0} no es válido.", reg.num_documento);
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Número de Documento";

                            lstErrores.Add(error);
                        }
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Número de Documento: {0} contiene el caracter pipe.", reg.num_documento);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Número de Documento";

                    lstErrores.Add(error);
                }

                //11.Apellidos y Nombres
                if (Validador.ValidaPipe(reg.nombre_razon_social.ToString()))
                {
                    if (ValidadorVenta.ValidaNombreApellido(Convert.ToInt32(reg.tipo_comprobante),
                    reg.nombre_razon_social.Trim(), Convert.ToDecimal(reg.pv)))
                    {
                        info = ObtieneInfoEstructura("APNOMB", lstInfo);

                        if (ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.nombre_razon_social.ToString()))
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("El Nombre/Razon Social: {0} no cumple con la longitud.", reg.nombre_razon_social);
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Nombre/Razon Social";

                            lstErrores.Add(error);
                        }
                        else
                        {
                            registro.Append(ValidadorVenta.ObtieneNombreApellido(reg.nombre_razon_social.Trim()));
                            registro.Append(separador);
                        }
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("Los Nombres o la Razón Social: {0} no son válidos.", reg.nombre_razon_social);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Nombre/Razon Social";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("Los Nombres o la Razón Social: {0} contiene el caracter pipe.", reg.nombre_razon_social);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Nombre/Razon Social";

                    lstErrores.Add(error);
                }

                //12.Valor facturado de la exportacion
                registro.Append(ValidadorVenta.ObtieneImporteTotal(Convert.ToDecimal(reg.ope_no_gravada)));
                registro.Append(separador);

                //13.Base imponible de la operacion gravada
                registro.Append(Convert.ToDecimal(reg.vv));
                registro.Append(separador);

                //14.Importe Total de la operacion exonerada
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //15.Importe Total de la operacion inafecta
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //16.ISC
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //17.IGV
                if (ValidadorVenta.ValidaIGV(Convert.ToInt32(reg.tipo_comprobante), Convert.ToDecimal(reg.igv)))
                {
                    registro.Append(ValidadorVenta.ObtieneIGV(Convert.ToDecimal(reg.igv)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El IGV con valor: {0} no es válido..", reg.igv);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "IGV";

                    lstErrores.Add(error);
                }

                //18.Base Imponible IVAP
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //19.IVAP
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //20.Otros Tributos
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //21.Importe total del comprobante de pago
                registro.Append(ValidadorVenta.ObtieneImporteTotal(Convert.ToDecimal(reg.pv)));
                registro.Append(separador);

                //22.Tipo de Cambio
                registro.Append(ValidadorVenta.ObtieneTipoCambio(Convert.ToDecimal(reg.tipo_cambio)));
                registro.Append(separador);

                //23.Fecha de emision modificada
                if (ValidadorVenta.ValidaFechaModificada(Convert.ToInt32(reg.tipo_comprobante), reg.nombre_razon_social,
                    Convert.ToDateTime(reg.fechamod)))
                {
                    registro.Append(ValidadorVenta.ObtieneFechaEmisionModificada(Convert.ToDateTime(reg.fechamod), Convert.ToInt32(reg.tipo_comprobante)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("La fecha modificada: {0} no es válido.", reg.fechamod);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Fecha de Comprobante Modificada";

                    lstErrores.Add(error);
                }

                //24.Tipo de Comprobante Modificado
                if (ValidadorVenta.ValidaTipoComprobanteMod(Convert.ToInt32(reg.tipo_comprobante), reg.tipomod,
                    reg.nombre_razon_social))
                {
                    registro.Append(ValidadorVenta.ObtieneTipoComprobanteMod(reg.tipomod));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El tipo de comprobante modificado: {0} no es válido.", reg.tipomod);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Tipo de Comprobante modificado";

                    lstErrores.Add(error);
                }

                //25.Numero de serie del comprobante modificado
                if (Validador.ValidaPipe(reg.seriemod.ToString()))
                {
                    if (ValidadorVenta.ValidaSerieComprobanteMod(Convert.ToInt32(reg.tipo_comprobante), reg.tipomod, reg.seriemod))
                    {
                        String val = ValidadorVenta.ObtieneNumeroSerieMod(Convert.ToInt32(reg.tipo_comprobante), reg.tipomod, reg.seriemod);

                        Int32 salida;

                        if (Int32.TryParse(val, out salida))
                        {
                            registro.Append(Formato.RellenaNumero(Convert.ToInt32(val), 4, "0"));
                            registro.Append(separador);
                        }
                        else
                        {
                            registro.Append(val);
                            registro.Append(separador);
                        }
                    }
                    else
                    {
                        if (reg.nombre_razon_social.Trim() == "ANULADO" && reg.num_documento.Length == 0)
                        {
                            registro.Append(ConfigurationManager.AppSettings["defaultNumDoc"]);
                            registro.Append(separador);

                        }
                        else
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("El número de serie del comprobante modificado: {0} no es válido.", reg.seriemod);
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Número de serie modificado";

                            lstErrores.Add(error);
                        }
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El número de serie del comprobante modificado: {0} contiene el caracter pipe.", reg.seriemod);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Número de serie modificado";

                    lstErrores.Add(error);
                }

                //26.Numero del comprobante
                if (ValidadorVenta.ValidarNumeroComprobanteMod(Convert.ToInt32(reg.tipo_comprobante),
                    reg.tipomod,reg.nomod,reg.nombre_razon_social))
                {
                    registro.Append(ValidadorVenta.ObtieneNumComprobanteMod(reg.nomod));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Número de Comprobante Modificado: {0} no es válido.", reg.nomod);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Número de Comprobante Modificado";

                    lstErrores.Add(error);                
                }
                
                //27.Oportunidad de la anotacion
                if (reg.estado == "0")
                {
                    if (reg.nombre_razon_social == valor)
                    {
                        registro.Append(ConfigurationManager.AppSettings["estadoAnulado"].ToString());
                        registro.Append(separador);
                    }
                    else
                    {
                        registro.Append(ConfigurationManager.AppSettings["campo27Default"].ToString());
                        registro.Append(separador);
                    }
                }
                else
                {
                    registro.Append(reg.estado);
                    registro.Append(separador);
                }

                GrabarDetalleLinea(i, reg.id_linea, registro.ToString(), bError);

                lstExport.Add(registro.ToString());
            }

            if (lstErrores.Count > 0)
            {
                DAErrorLineaDetalle objDALinea = new DAErrorLineaDetalle();

                objDALinea.GuardarLote(lstErrores);

                //return "Error";
            }

            File.EliminarArchivo(rutaArchivo + @"\" + objArchLog.nombre_carga);

            File.Inserta(lstExport, rutaArchivo + @"\" + objArchLog.nombre_carga);
            
            return String.Empty;
        }

        public String GenerarArchivoRegistroCompras(String rutaArchivo, Int32 id_archivo, String cod_archivo, String num_ruc, Int32 id_ope, Int32 id_libro, String id_moneda,
            Int32 mes, Int32 anio, Int32 id_archivo_log)
        {
            //Registramos la carga
            DAInputDetalle objDA = new DAInputDetalle();

            List<InputRegistroCompra> lst = objDA.ObtieneDetalleExportRegCompra(mes, anio, id_archivo_log);

            DateTime fechaPeriodo = new DateTime(anio, mes, 1);

            //Guardamos la carga cabecera
            ArchivoLog objArchLog = new ArchivoLog();
            objArchLog.id_archivo = id_archivo;
            objArchLog.fecha_carga = DateTime.Now;
            objArchLog.cant_registros = lst.Count;
            objArchLog.tipo_ope = "E";
            objArchLog.nombre_carga = ObtieneNombreArchivo(num_ruc, anio, mes, cod_archivo, id_ope, id_libro, id_moneda);

            DAArchivoLog objDALog = new DAArchivoLog();

            Int32 i = objDALog.Guardar(objArchLog);

            //Generamos el archivo
            List<InfoEstructura> lstInfo = Obtiene(cod_archivo);

            List<String> lstExport = new List<String>();

            Char separador = Convert.ToChar(ConfigurationManager.AppSettings["separador"].ToString());

            StringBuilder registro = new StringBuilder();

            InfoEstructura info = new InfoEstructura();

            String defaultString = ConfigurationManager.AppSettings["defaultNumDoc"].ToString();

            Validador.CargaTipoDocumento();

            Validador.CargaTipoComprobante();

            Validador.CargarCodigoAduana();

            List<ErrorLineaDetalle> lstErrores = new List<ErrorLineaDetalle>();

            ErrorLineaDetalle error;

            Boolean bError = false;

            String valor = ConfigurationManager.AppSettings["validaAnulado"].ToString();


            foreach (InputRegistroCompra reg in lst)
            {
                bError = false;

                registro = new StringBuilder();

                DateTime dt = new DateTime(anio, mes, 1);

                //1.Periodo
                if (reg.estado == "0" || reg.estado=="7")
                {
                    registro.Append(ValidadorCobro.ObtienePeriodo(dt));
                    registro.Append(separador);
                }
                else
                {
                    registro.Append(ValidadorCobro.ObtienePeriodo(Convert.ToDateTime(reg.fecha_emision)));
                    registro.Append(separador);
                }

                //2.NumCorrelativo
                info = ObtieneInfoEstructura("CORR", lstInfo);

                if (Validador.ValidaPipe(reg.no_ope_rac.ToString()))
                {
                    if (ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.no_ope_rac.ToString()))
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El campo N° Operacion: {0} está fuera de la longitud permitida.", reg.no_ope_rac);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "N° Operacion";

                        lstErrores.Add(error);
                    }
                    else
                    {
                        registro.Append(reg.no_ope_rac);
                        registro.Append(separador);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El campo N° Operacion: {0} contiene el caracter pipe.", reg.no_ope_rac);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "N° Operacion";

                    lstErrores.Add(error);
                }

                //3.Fecha de Emision del Comprobante
                registro.Append(ValidadorCobro.ObtieneFechaEmisionComprobante(Convert.ToDateTime(reg.fecha_emision)));
                registro.Append(separador);

                //4.Fecha de Vencimiento
                if (ValidadorCobro.ValidaFechaVencimiento(Convert.ToDateTime(reg.fecha_vencimiento), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneFechaVencimiento(Convert.ToDateTime(reg.fecha_vencimiento)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = "El campo Fecha de Vencimiento es obligatorio.";
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Fecha de Vencimiento";

                    lstErrores.Add(error);
                }

                //5.Tipo de Comprobante
                if (reg.tipo_comprobante != String.Empty)
                {
                    if (ValidadorCobro.ValidaTipoComprobante(reg.tipo_comprobante))
                    {
                        registro.Append(reg.tipo_comprobante);
                        registro.Append(separador);
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El tipo de Comprobante: {0} no es válido.", reg.tipo_comprobante);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Tipo de Comprobante";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    registro.Append(ConfigurationManager.AppSettings["tipoCompDefault"]);
                    registro.Append(separador);
                }

                //6.Numero de Serie del Comprobante
                if (reg.nro_serie_comprobante != String.Empty)
                {
                    String num_serie = ValidadorCobro.ObtieneNumeroSerie(reg.tipo_comprobante, reg.nro_serie_comprobante);

                    if (Validador.ValidaPipe(reg.nro_serie_comprobante))
                    {
                        if (ValidadorCobro.ValidaSerieComprobante(reg.nro_serie_comprobante, reg.tipo_comprobante))
                        {
                            registro.Append(num_serie);
                            registro.Append(separador);
                        }
                        else
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("El número de serie del Comprobante: {0} no es válido.", reg.nro_serie_comprobante);
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Número de Serie Comprobante";

                            lstErrores.Add(error); 
                        }
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El número de serie del Comprobante: {0} contiene caracter pipe.", reg.nro_serie_comprobante);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Número de Serie Comprobante";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    registro.Append(ConfigurationManager.AppSettings["defaultNumDoc"].ToString());
                    registro.Append(separador);
                }

                //7.Año de Emision de la DUA o DSI
                if (ValidadorCobro.ValidaAnioEmision(Convert.ToInt32(reg.anio_emision_comprobante), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneAnioEmision(Convert.ToInt32(reg.anio_emision_comprobante), reg.tipo_comprobante));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El año de emision: {0} no es válido.", reg.anio_emision_comprobante);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Año de Emision.";

                    lstErrores.Add(error);
                }

                //8.Numero de Comprobante
                info = ObtieneInfoEstructura("NUMC", lstInfo);

                if (Validador.ValidaPipe(reg.numero_comprobante))
                {
                    if (!ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.numero_comprobante))
                    {
                        if (reg.numero_comprobante != String.Empty)
                        {
                            if (ValidadorCobro.ValidaNumerodeComprobante(reg.numero_comprobante))
                            {
                                registro.Append(reg.numero_comprobante);
                                registro.Append(separador);
                            }
                            else
                            {
                                bError = true;

                                error = new ErrorLineaDetalle();

                                error.descripcion = String.Format("El número de comprobante: {0} no es válido.", reg.numero_comprobante);
                                error.id_archivo_log = i;
                                error.n_linea = reg.id_linea;
                                error.nombre_campo = "Número de Comprobante.";

                                lstErrores.Add(error);
                            }
                        }
                        else
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = "El número de comprobante es obligatorio";
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Número de Comprobante";

                            lstErrores.Add(error);
                        }
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El número de comprobante: {0} no cumple con la longitud permitida.", reg.numero_comprobante);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Número de Comprobante.";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El número de comprobante: {0} no puede contener el caraceter pipe.", reg.numero_comprobante);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Número de Comprobante.";

                    lstErrores.Add(error);
                }

                //9.Valor en duro
                registro.Append(ConfigurationManager.AppSettings["defaultTipoDoc"].ToString());
                registro.Append(separador);

                //10.Tipo de documento de Identidad
                if (Validador.ValidaPipe(reg.tipo_documento))
                {
                    String tipo_doc_aux = String.Empty;
                    Int32 num =-1;

                    if (Int32.TryParse(reg.tipo_documento, out num))
                    {
                        tipo_doc_aux = num.ToString();
                    }
                    else
                    {
                        tipo_doc_aux = reg.tipo_documento;
                    }

                    if (ValidadorCobro.ValidaTipoDocumento(reg.tipo_comprobante, tipo_doc_aux,
                        String.Empty))
                    {
                        registro.Append(ValidadorCobro.ObtieneTipoDocumento(tipo_doc_aux));
                        registro.Append(separador);
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El Tipo de Documento: {0} no es válido.", reg.tipo_documento);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Tipo de Documento";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Tipo de Documento: {0} contiene el caracter pipe.", reg.tipo_documento);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Tipo de Documento";

                    lstErrores.Add(error);
                }

                //11.Numero de documento de identidad del cliente
                if (Validador.ValidaPipe(reg.numero_documento.ToString()))
                {
                    if (ValidadorCobro.ValidaNumDocumento(reg.numero_documento,reg.tipo_comprobante,String.Empty))
                    {
                        info = ObtieneInfoEstructura("NRUCPROV", lstInfo);

                        if (ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.numero_documento.ToString()))
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("El Número de Documento: {0} no cumple con la longitud.", reg.numero_documento);
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Número de Documento";

                            lstErrores.Add(error);
                        }
                        else
                        {
                            registro.Append(ValidadorCobro.ObtieneNumDocumento(reg.numero_documento));
                            registro.Append(separador);
                        }
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El Número de Documento: {0} no es válido.", reg.numero_documento);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Número de Documento";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Número de Documento: {0} contiene el caracter pipe.", reg.numero_documento);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Número de Documento";

                    lstErrores.Add(error);
                }

                //12.Apellidos y Nombres
                if (Validador.ValidaPipe(reg.apell_nomb_raz_soc))
                {
                    if (ValidadorCobro.ValidaNombre(reg.apell_nomb_raz_soc,reg.tipo_comprobante,String.Empty))
                    {
                        info = ObtieneInfoEstructura("APELLNOMB", lstInfo);

                        if (ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.apell_nomb_raz_soc.ToString()))
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("El Nombre/Razon Social: {0} no cumple con la longitud.", reg.apell_nomb_raz_soc);
                            error.id_archivo_log = i;
                            error.n_linea = reg.id_linea;
                            error.nombre_campo = "Nombre/Razon Social";

                            lstErrores.Add(error);
                        }
                        else
                        {
                            registro.Append(ValidadorCobro.ObtieneNombre(reg.apell_nomb_raz_soc.Trim()));
                            registro.Append(separador);
                        }
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("Los Nombres o la Razón Social: {0} no son válidos.", reg.apell_nomb_raz_soc);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Nombre/Razon Social";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("Los Nombres o la Razón Social: {0} contiene el caracter pipe.", reg.apell_nomb_raz_soc);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Nombre/Razon Social";

                    lstErrores.Add(error);
                }

                //13.Base Imponible Gravada
                if (ValidadorCobro.ValidaDecimal(Convert.ToDecimal(reg.base_imponible_grav), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneValor(Convert.ToDecimal(reg.base_imponible_grav)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("La base imponible gravada: {0} no puede ser menor a 0.", reg.base_imponible_grav);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Base Imponible Gravada";

                    lstErrores.Add(error);
                }

                //14.IGV Gravado
                if (ValidadorCobro.ValidaDecimal(Convert.ToDecimal(reg.igv_gravado), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneValor(Convert.ToDecimal(reg.igv_gravado)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El IGV Gravado: {0} no puede ser menor a 0.", reg.igv_gravado);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "IGV Gravado";

                    lstErrores.Add(error);
                }

                //15.Base Imponible Adqs
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //16.Monto IGV
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //17.Base Imponible Adqs
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //18.Monto IGV
                registro.Append(ConfigurationManager.AppSettings["defaultValor"].ToString());
                registro.Append(separador);

                //19.Adquisiciones no gravadas
                if (ValidadorCobro.ValidaDecimal(Convert.ToDecimal(reg.adq_no_grav), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneValor(Convert.ToDecimal(reg.adq_no_grav)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("La Base No Gravada: {0} no puede ser menor a 0.", reg.adq_no_grav);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Base No Gravada";

                    lstErrores.Add(error);
                }

                //20.ISC
                if (ValidadorCobro.ValidaDecimal(Convert.ToDecimal(reg.isc), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneValor(Convert.ToDecimal(reg.isc)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El valor ISC: {0} no puede ser menor a 0.", reg.isc);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "ISC";

                    lstErrores.Add(error);
                }

                //21.Otros Tributos
                if (ValidadorCobro.ValidaDecimal(Convert.ToDecimal(reg.otros_tributos), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneValor(Convert.ToDecimal(reg.otros_tributos)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El valor: {0} no puede ser menor a 0.", reg.otros_tributos);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Otros Tributos";

                    lstErrores.Add(error);
                }

                //22.Total
                if (ValidadorCobro.ValidaDecimal(Convert.ToDecimal(reg.total), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneValor(Convert.ToDecimal(reg.total)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Total: {0} no puede ser menor a 0.", reg.total);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Total";

                    lstErrores.Add(error);
                }

                //23.Tipo de Cambio
                if (ValidadorCobro.ValidaDecimal(Convert.ToDecimal(reg.tipo_cambio), reg.tipo_comprobante))
                {
                    registro.Append(ValidadorCobro.ObtieneValor(Convert.ToDecimal(reg.tipo_cambio)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Tipo de Cambio: {0} no puede ser menor a 0.", reg.tipo_cambio);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Tipo de Cambio";

                    lstErrores.Add(error);
                }

                //24.Fecha de Comp que se modifica
                if (ValidadorCobro.ValidaFechaEmisionMod(reg.tipo_comprobante,Convert.ToDateTime(reg.fecha_emision),Convert.ToDateTime(reg.fecha_original)))
                {
                    registro.Append(ValidadorCobro.ObtieneFechaEmisionMod(reg.tipo_comprobante, Convert.ToDateTime(reg.fecha_original)));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("La fecha de emisión {0} no es válida.", reg.fecha_original);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Fecha Emisión que se Modifica";

                    lstErrores.Add(error);
                }

                //25.Tipo de Comprobante que se modifica
                if (ValidadorCobro.ValidaTipoComprobanteMod(reg.tipo_comprobante, reg.tipo_doc_orig))
                {
                    registro.Append(ValidadorCobro.ObtieneTipoComprobanteMod(reg.tipo_comprobante, reg.tipo_doc_orig));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El tipo de comprobante modificado {0} no es válido.", reg.tipo_doc_orig);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Tipo de Comprobante Modificado.";

                    lstErrores.Add(error);
                }
                
                //26.Numero de serie de comp que se mod
                registro.Append(ValidadorCobro.ObtieneNumeroSerieCompMod(reg.num_serie_orig));
                registro.Append(separador);

                //27.Numero de Comp
                if (ValidadorCobro.ValidaNumComprobanteMod(reg.tipo_comprobante, reg.num_doc_orig))
                {
                    registro.Append(ValidadorCobro.ObtieneNumComprobanteMod(reg.num_doc_orig));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El numero de comprobante modificado {0} no es válido.", reg.num_doc_orig);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Numero de Comprobante Modificado.";

                    lstErrores.Add(error);
                }

                //28.Num Comp no domiciliado
                info = ObtieneInfoEstructura("NUMCNODOC", lstInfo);

                if (!ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.comp_no_domic))
                {
                    if (ValidadorCobro.ValiaCompNoDomic(reg.comp_no_domic))
                    {
                        registro.Append(ValidadorCobro.ObtieneCompNoDomic(reg.comp_no_domic, reg.tipo_comprobante));
                        registro.Append(separador);
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El Comprobante no domiciliado: {0} no puede ser menor a 0.", reg.comp_no_domic);
                        error.id_archivo_log = i;
                        error.n_linea = reg.id_linea;
                        error.nombre_campo = "Comprobante no Domiciliado";

                        lstErrores.Add(error);
                    }
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Comprobante no domiciliado: {0} está fuera de la longitud permitida.", reg.no_ope_rac);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "Comprobante no Domiciliado";

                    lstErrores.Add(error);
                }

                //29.Fecha Emision Constancia
                registro.Append(ValidadorCobro.ObtieneFechaEmision(Convert.ToDateTime(reg.fecha_emision_const), reg.num_constancia));
                registro.Append(separador);

                //30.Numero de Constancia
                info = ObtieneInfoEstructura("NUMCONS", lstInfo);

                if (!ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.num_constancia))
                {
                    registro.Append(ValidadorCobro.ObtieneNumeroConstancia(reg.num_constancia));
                    registro.Append(separador);
                }
                else
                {
                    bError = true;

                    error = new ErrorLineaDetalle();

                    error.descripcion = String.Format("El Numero de Constancia: {0} está fuera de la longitud permitida.", reg.no_ope_rac);
                    error.id_archivo_log = i;
                    error.n_linea = reg.id_linea;
                    error.nombre_campo = "N° de Constancia";

                    lstErrores.Add(error);
                }

                //31.Marca Comprobante
                //registro.Append(ValidadorCobro.ObtieneMarcaComprobante(Convert.ToDecimal(reg.importe_retencion)));
                registro.Append("0");
                registro.Append(separador);

                //32.
                //registro.Append(ConfigurationManager.AppSettings["fijo"].ToString());
                if (reg.estado == "0")
                {
                    registro.Append(ValidadorCobro.ObtieneEstadoRegistro(fechaPeriodo, Convert.ToDateTime(reg.fecha_emision)));
                    registro.Append(separador);
                }
                else
                {
                    registro.Append(reg.estado);
                    registro.Append(separador);
                }

                GrabarDetalleLinea(i, reg.id_linea, registro.ToString(), bError);

                lstExport.Add(registro.ToString());
            }

            if (lstErrores.Count > 0)
            {
                DAErrorLineaDetalle objDALinea = new DAErrorLineaDetalle();

                objDALinea.GuardarLote(lstErrores);

                //return "Error";
            }

            File.EliminarArchivo(rutaArchivo + @"\" + objArchLog.nombre_carga);

            File.Inserta(lstExport, rutaArchivo + @"\" + objArchLog.nombre_carga);

            return String.Empty;
        }

        public String GenerarArchivoLibroDiario(String rutaArchivo, Int32 id_archivo, String cod_archivo, String num_ruc, Int32 id_ope, Int32 id_libro, String id_moneda,
            Int32 mes, Int32 anio, Int32 id_archivo_log)
        {
            //Registramos la carga
            DAInputDetalle objDA = new DAInputDetalle();

            List<InputLibroDiario> lst = objDA.ObtieneDetalleLibroDiario(id_archivo_log);

            //Guardamos la carga cabecera
            ArchivoLog objArchLog = new ArchivoLog();
            objArchLog.id_archivo = id_archivo;
            objArchLog.fecha_carga = DateTime.Now;
            objArchLog.cant_registros = lst.Count;
            objArchLog.tipo_ope = "E";
            objArchLog.nombre_carga = ObtieneNombreArchivo(num_ruc, anio, mes, cod_archivo, id_ope, id_libro, id_moneda);

            DAArchivoLog objDALog = new DAArchivoLog();

            Int32 i = objDALog.Guardar(objArchLog);

            //Generamos el archivo
            List<InfoEstructura> lstInfo = Obtiene(cod_archivo);

            List<String> lstExport = new List<String>();

            Char separador = Convert.ToChar(ConfigurationManager.AppSettings["separador"].ToString());

            StringBuilder registro = new StringBuilder();

            InfoEstructura info = new InfoEstructura();

            String defaultString = ConfigurationManager.AppSettings["defaultNumDoc"].ToString();

            Validador.CargaTipoDocumento();
            Validador.CargaTipoComprobante();

            List<ErrorLineaDetalle> lstErrores = new List<ErrorLineaDetalle>();
            ErrorLineaDetalle error;
            Boolean bError = false;

            foreach (InputLibroDiario reg in lst)
            {
                bError = false;

                registro = new StringBuilder();

                if(!(reg.debe == 0 && reg.haber ==0))
                {
                    //1.Periodo
                    registro.Append(ValidadorLibroDiario.ObtienePeriodo(Convert.ToDateTime(reg.fecha)));
                    registro.Append(separador);

                    //2.Correlativo
                    registro.Append(reg.numcorre);
                    registro.Append(separador);

                    //3.Codigo de Plan Utilizado
                    registro.Append("01");
                    registro.Append(separador);

                    //4.Cuenta contable
                    info = ObtieneInfoEstructura("CUENTA", lstInfo);

                    if (!ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.cuenta))
                    {
                        registro.Append(reg.cuenta);
                        registro.Append(separador);
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El Numero de Cuenta: {0} está fuera de la longitud permitida.", reg.cuenta);
                        error.id_archivo_log = i;
                        error.n_linea = reg.num_linea;
                        error.nombre_campo = "N° de Cuenta";

                        lstErrores.Add(error);
                    }

                    //5.Fecha de la Operacion
                    registro.Append(Formato.FormateaFecha("DD/MM/AAAA", Convert.ToDateTime(reg.fecha)));
                    registro.Append(separador);

                    //6.Glosa
                    if (reg.descasent.Trim() == String.Empty)
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("La Glosa es obligatoria.", reg.descasent);
                        error.id_archivo_log = i;
                        error.n_linea = reg.num_linea;
                        error.nombre_campo = "Glosa";

                        lstErrores.Add(error);
                    }
                    else
                    {
                        info = ObtieneInfoEstructura("GLOSA", lstInfo);

                        if (!ValidaLongitud(Convert.ToInt32(info.longitud_campo), reg.descasent))
                        {
                            registro.Append(reg.descasent);
                            registro.Append(separador);
                        }
                        else
                        {
                            bError = true;

                            error = new ErrorLineaDetalle();

                            error.descripcion = String.Format("La Glosa: {0} está fuera de la longitud permitida.", reg.cuenta);
                            error.id_archivo_log = i;
                            error.n_linea = reg.num_linea;
                            error.nombre_campo = "Glosa";

                            lstErrores.Add(error);
                        }
                    }

                    

                    //7.Movimientos del Debe
                    if (!ValidadorLibroDiario.ValidaDebe(Convert.ToDecimal(reg.debe)))
                    {
                        registro.Append(reg.debe);
                        registro.Append(separador);
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El monto Debe: {0} no es válido.", reg.debe);
                        error.id_archivo_log = i;
                        error.n_linea = reg.num_linea;
                        error.nombre_campo = "Debe";

                        lstErrores.Add(error);
                    }

                    //8.Movimientos del Haber
                    if (!ValidadorLibroDiario.ValidaDebe(Convert.ToDecimal(reg.haber)))
                    {
                        registro.Append(reg.haber);
                        registro.Append(separador);
                    }
                    else
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = String.Format("El monto Haber: {0} no es válido.", reg.haber);
                        error.id_archivo_log = i;
                        error.n_linea = reg.num_linea;
                        error.nombre_campo = "Haber";

                        lstErrores.Add(error);
                    }

                    //9.Estado de la operacion
                    registro.Append(ConfigurationManager.AppSettings["fijo"]);
                    registro.Append(separador);

                    GrabarDetalleLinea(i, reg.num_linea, registro.ToString(), bError);

                    lstExport.Add(registro.ToString());
                }
            }

            if (lstErrores.Count > 0)
            {
                DAErrorLineaDetalle objDALinea = new DAErrorLineaDetalle();

                objDALinea.GuardarLote(lstErrores);

                //return "Error";
            }

            File.EliminarArchivo(rutaArchivo + @"\" + objArchLog.nombre_carga);

            File.Inserta(lstExport, rutaArchivo + @"\" + objArchLog.nombre_carga);

            return String.Empty;
        }

        public String GenerarArchivoLibroMayor(String rutaArchivo, Int32 id_archivo, String cod_archivo, String num_ruc, Int32 id_ope, Int32 id_libro, String id_moneda,
            Int32 mes, Int32 anio, Int32 id_archivo_log)
        {
            //Registramos la carga
            DAInputDetalle objDA = new DAInputDetalle();

            List<InputLibroMayor> lst = objDA.ObtieneDetalleLibroMayor(id_archivo_log);

            //Guardamos la carga cabecera
            ArchivoLog objArchLog = new ArchivoLog();
            objArchLog.id_archivo = id_archivo;
            objArchLog.fecha_carga = DateTime.Now;
            objArchLog.cant_registros = lst.Count;
            objArchLog.tipo_ope = "E";
            objArchLog.nombre_carga = ObtieneNombreArchivo(num_ruc, anio, mes, cod_archivo, id_ope, id_libro, id_moneda);

            DAArchivoLog objDALog = new DAArchivoLog();

            Int32 i = objDALog.Guardar(objArchLog);

            //Generamos el archivo
            List<InfoEstructura> lstInfo = Obtiene(cod_archivo);

            List<String> lstExport = new List<String>();

            Char separador = Convert.ToChar(ConfigurationManager.AppSettings["separador"].ToString());

            StringBuilder registro = new StringBuilder();

            InfoEstructura info = new InfoEstructura();

            String defaultString = ConfigurationManager.AppSettings["defaultNumDoc"].ToString();

            Validador.CargaTipoDocumento();
            Validador.CargaTipoComprobante();

            List<ErrorLineaDetalle> lstErrores = new List<ErrorLineaDetalle>();
            ErrorLineaDetalle error;
            Boolean bError = false;

            foreach (InputLibroMayor reg in lst)
            {
                bError = false;

                if (!(reg.credito == 0 && reg.debito == 0))
                {
                    registro = new StringBuilder();

                    //1.Fecha del Periodo
                    registro.Append(ValidadorLibroMayor.ObtienePeriodo(Convert.ToDateTime(reg.fecha_ope)));
                    registro.Append(separador);

                    //2.Numero correlativo
                    registro.Append(reg.item);
                    registro.Append(separador);

                    //3.Codigo cuenta contable
                    registro.Append(reg.cuenta);
                    registro.Append(separador);

                    //4.Fecha de la Operacion
                    registro.Append(Formato.FormateaFecha("DD/MM/AAAA", Convert.ToDateTime(reg.fecha_ope)));
                    registro.Append(separador);

                    //5.Descripcion de la operacion
                    if (reg.descripcion.Trim() == String.Empty)
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = "La Glosa es obligatoria.";
                        error.id_archivo_log = i;
                        error.n_linea = reg.num_linea;
                        error.nombre_campo = "Glosa";

                        lstErrores.Add(error);
                    }
                    else
                    {
                        registro.Append(reg.descripcion);
                        registro.Append(separador);
                    }

                    //6.Parte deudora de saldos y movimientos
                    registro.Append(reg.debito);
                    registro.Append(separador);

                    //7.Parte creedora de saldos y movimientos
                    registro.Append(reg.credito);
                    registro.Append(separador);

                    //8.Estado de la operacion
                    registro.Append(ConfigurationManager.AppSettings["fijo"]);
                    registro.Append(separador);

                    //Valida los campos credito y debito
                    if (ValidadorLibroMayor.ValidaMontos(Convert.ToDecimal(reg.credito), Convert.ToDecimal(reg.debito)))
                    {
                        bError = true;

                        error = new ErrorLineaDetalle();

                        error.descripcion = "El crédito y débito no pueden ser ambos 0.";
                        error.id_archivo_log = i;
                        error.n_linea = reg.num_linea;
                        error.nombre_campo = "Crédito y Débito";

                        lstErrores.Add(error);
                    }

                    GrabarDetalleLinea(i, reg.num_linea, registro.ToString(), bError);

                    lstExport.Add(registro.ToString());
                }
            }

            if (lstErrores.Count > 0)
            {
                DAErrorLineaDetalle objDALinea = new DAErrorLineaDetalle();

                objDALinea.GuardarLote(lstErrores);

                //return "Error";
            }

            File.EliminarArchivo(rutaArchivo + @"\" + objArchLog.nombre_carga);

            File.Inserta(lstExport, rutaArchivo + @"\" + objArchLog.nombre_carga);

            return String.Empty;
        }

        private List<InfoEstructura> Obtiene(String cod_archivo)
        {
            DAInfoEstructura obj = new DAInfoEstructura();

            List<InfoEstructura> lst = new List<InfoEstructura>();

            lst = obj.ListarxCodArchivo(cod_archivo);

            return lst;
        }

        public Boolean ValidaLongitud(Int32 longitud, String campo)
        {
            return campo.Length > longitud;
        }

        private InfoEstructura ObtieneInfoEstructura(String nombre,List<InfoEstructura> pLst)
        {
            var filtro = (from o in pLst
                         where o.nombre_input == nombre
                         select o).FirstOrDefault();

            InfoEstructura obj = (InfoEstructura)filtro;

            return obj;
        }

        private void GrabarDetalleLinea(Int32 id_archivo_log, Int32 n_linea, String trama, Boolean estado)
        {
            logDetalle = new ArchivoLogDetalle();

            logDetalle.id_archivo_log = id_archivo_log;
            logDetalle.estado = estado;
            logDetalle.n_linea = n_linea;
            logDetalle.trama = trama;

            objDArchivoLog = new DAArchivoLogDetalle();

            objDArchivoLog.Guardar(logDetalle);
        }

        private String ObtieneNombreArchivo(String num_ruc, Int32 anio, Int32 mes,String id_archivo,Int32 id_ope,
            Int32 id_libro,String id_moneda)
        {
            StringBuilder sb = new StringBuilder();

            String identificador = ConfigurationManager.AppSettings["LE"].ToString();

            //Identificador
            sb.Append(identificador);

            //RUC
            sb.Append(num_ruc);

            //Año
            sb.Append(anio);

            //Mes
            sb.Append(Formato.RellenaNumero(mes));

            //Dia
            String dia = ConfigurationManager.AppSettings["diadefault"].ToString();
            sb.Append(dia);

            //Identificador Libro
            sb.Append(id_archivo);

            //Codigo de Oportunidad
            String cod = ConfigurationManager.AppSettings["diadefault"].ToString();
            sb.Append(cod);

            //Operacion
            sb.Append(id_ope);

            //Libro
            sb.Append(id_libro);

            //Moneda
            Int16 mon = Formato.ObtieneMoneda(id_moneda);
            sb.Append(mon);

            //Indicador
            String ind = ConfigurationManager.AppSettings["fijo"].ToString();
            sb.Append(ind);

            sb.Append(".txt");

            return sb.ToString();
        }
    }
}
