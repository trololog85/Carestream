using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;

namespace CareStream.Logic.Facade
{
    public class FArchivo
    {
        public List<Archivo> Listar()
        {
            DAArchivo objDA = new DAArchivo();

            List<Archivo> lst = new List<Archivo>();

            try
            {
                lst = objDA.Listar();
            }
            catch (Exception ex)
            {
                String s = ex.Message;
            }
            

            return lst;
        }

        public String Guardar(Archivo obj)
        {
            String rpta = String.Empty;

            DAArchivo objDA = new DAArchivo();

            try
            {
                objDA.Guardar(obj);
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }

        public String Actualizar(Archivo obj)
        {
            String rpta = String.Empty;

            DAArchivo objDA = new DAArchivo();

            try
            {
                objDA.Actualizar(obj);
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }

        public Int32 ObtieneIDxCod(String codigo)
        {
            DAArchivo objDA = new DAArchivo();

            return objDA.ObtieneArchivoxCod(codigo);
        }

        public String Eliminar(Archivo obj)
        {
            String rpta = String.Empty;

            DAArchivo objDA = new DAArchivo();

            try
            {
                objDA.Eliminar(obj);
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;
        }
    }
}
