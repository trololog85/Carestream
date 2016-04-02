using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;
using CareStream.Logic.Excel;
using CareStream.Utils;


namespace CareStream.Logic.Facade
{
    public class FInput
    {
        public String CargarArchivo(String rutaArchivo,String cod_archivo, String ruc, Char iOpe, String iMoneda, Char iRegistro, 
            Int32 idArchivo)
        {
            String rpta = String.Empty;

            try
            {
                Input objIn = new Input();

                if (cod_archivo == Globals.ArchivoVentas)
                {
                    objIn.CargarRegistroVenta(rutaArchivo, ruc, iOpe, iMoneda, iRegistro, idArchivo);
                }
                else if (cod_archivo == Globals.ArchivoCompras)
                {
                    objIn.CargarRegistroCompra(rutaArchivo, ruc, iOpe, iMoneda, iRegistro, idArchivo);
                }
                else if (cod_archivo == Globals.ArchivoLibroDiario)
                {
                    objIn.CargaLibroDiario(rutaArchivo, ruc, iOpe, iMoneda, iRegistro, idArchivo);
                }
                else if (cod_archivo == Globals.ArchivoLibroMayor)
                {
                    objIn.CargaLibroMayor(rutaArchivo, ruc, iOpe, iMoneda, iRegistro, idArchivo);
                }
            }
            catch (System.Data.OleDb.OleDbException oleEx)
            {
                rpta = oleEx.Message;
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                rpta = sqlEx.Message;
            }
            catch (ApplicationException appEx)
            {
                rpta = appEx.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
