using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareStream.Data.Access;
using CareStream.Logic.Excel;


namespace CareStream.Logic.Facade
{
    public class FInputDetalle
    {
        public List<InputRegistroVenta> ObtieneDetalleRegistroVenta(Int32 idarchivo_log)
        {
            DAInputDetalle objDA = new DAInputDetalle();

            List<InputRegistroVenta> lst = new List<InputRegistroVenta>();

            try
            {
                lst = objDA.ObtieneDetalleRegistroVenta(idarchivo_log);
            }
            catch (Exception ex)
            {
                String s = ex.Message;
            }

            return lst;
        }

        public List<InputRegistroCompra> ObtieneDetalleRegistroCompra(Int32 id_archivo_log)
        {
            DAInputDetalle objDA = new DAInputDetalle();

            List<InputRegistroCompra> lst = new List<InputRegistroCompra>();

            try
            {
                lst = objDA.ObtieneDetalleRegistroCompra(id_archivo_log);
            }
            catch (Exception ex)
            {
                String s = ex.Message;
            }

            return lst;
        }

        public List<InputRegistroVenta> ObtieneDetalleRegistroVenta(Int32 mes, Int32 anio, Int32 id_archivo_log)
        {
            DAInputDetalle objDA = new DAInputDetalle();

            List<InputRegistroVenta> lst = new List<InputRegistroVenta>();

            try
            {
                lst = objDA.ObtieneDetalleExport(mes, anio, id_archivo_log);
            }
            catch (Exception ex)
            {
                String s = ex.Message;
            }

            return lst;
        }
    }
}
