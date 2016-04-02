using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;
using CareStream.Logic.Excel;

namespace CareStream.Logic.Facade
{
    public class FEstructura
    {
        public List<Estructura> Listar()
        {
            DAEstructura objDA = new DAEstructura();

            List<Estructura> lst = objDA.Listar();
            
            return lst;
        }

        public String Guardar(String rutaArchivo,Estructura objEst)
        {
            String rpta = String.Empty;

            DAEstructura objDA = new DAEstructura();

            try
            {
                objDA.Guardar(objEst);
            }
            catch (System.Data.OptimisticConcurrencyException ocEx)
            {
                rpta = ocEx.Message;
            }
            catch (ApplicationException appEx)
            {
                rpta = appEx.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            Int32 id = 0;

            if (rpta == String.Empty)
            {
                id = objDA.ObtieneMaximoID();
            }
            else
            {
                return rpta;
            }

            BLInfoEstructura objBL = new BLInfoEstructura();

            try
            {
                objBL.Cargar(rutaArchivo, id);
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

        public String Eliminar(Estructura obj)
        {
            String rpta = String.Empty;

            DAEstructura objDA = new DAEstructura();

            try
            {
                objDA.Eliminar(obj);
            }
            catch (System.Data.OptimisticConcurrencyException ocEx)
            {
                rpta = ocEx.Message;
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
