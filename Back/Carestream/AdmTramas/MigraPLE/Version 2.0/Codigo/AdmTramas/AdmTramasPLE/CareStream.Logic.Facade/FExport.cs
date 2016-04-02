using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;
using CareStream.Logic.IO;
using CareStream.Utils;

namespace CareStream.Logic.Facade
{
    public class FExport
    {
        public String ExportaArchivo(String rutaArchivo, Int32 id_archivo, String cod_archivo, String num_ruc, 
            Int32 id_ope, Int32 id_libro, String id_moneda,Int32 mes, Int32 anio, Int32 id_archivo_log)
        {
            String rpta = String.Empty;

            try
            {
                Export objEx = new Export();

                if (cod_archivo == Globals.ArchivoCompras)
                {
                    rpta = objEx.GenerarArchivoRegistroCompras(rutaArchivo, id_archivo, cod_archivo, num_ruc, id_ope, id_libro, id_moneda, mes, anio,
                    id_archivo_log);
                }
                else if (cod_archivo == Globals.ArchivoVentas)
                {
                    rpta = objEx.GenerarArchivoRegistroVentas(rutaArchivo, id_archivo, cod_archivo, num_ruc, id_ope, id_libro, id_moneda, mes, anio,
                    id_archivo_log);
                }
                else if (cod_archivo == Globals.ArchivoLibroDiario)
                {
                    rpta = objEx.GenerarArchivoLibroDiario(rutaArchivo, id_archivo, cod_archivo, num_ruc, id_ope, id_libro, id_moneda, mes, anio,
                    id_archivo_log);
                }
                else if (cod_archivo == Globals.ArchivoLibroMayor)
                {
                    rpta = objEx.GenerarArchivoLibroMayor(rutaArchivo, id_archivo, cod_archivo, num_ruc, id_ope, id_libro, id_moneda, mes, anio,
                    id_archivo_log);
                }
            }
            catch (System.Data.OleDb.OleDbException oleEx)
            {
                rpta = "Error: " + oleEx.Message;
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                rpta = "Error: " + sqlEx.Message;
            }
            catch (System.IO.IOException ioEX)
            {
                rpta = "Error: " + ioEX.Message;
            }
            catch (ApplicationException appEx)
            {
                rpta = "Error: " + appEx.Message;
            }
            catch (Exception ex)
            {
                rpta = "Error: " + ex.Message;
            }

            return rpta;
        }
    }
}
