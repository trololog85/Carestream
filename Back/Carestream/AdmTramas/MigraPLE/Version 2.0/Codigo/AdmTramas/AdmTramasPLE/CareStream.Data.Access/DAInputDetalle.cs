using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CareStream.Utils;
using CareStream.Data.Access;
using CareStream.Logic.Excel;


namespace CareStream.Data.Access
{
    public class DAInputDetalle
    {
        public List<InputRegistroVenta> ObtieneDetalleRegistroVenta(Int32 idarchivo_log)
        {
            List<InputRegistroVenta> lst = new List<InputRegistroVenta>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.RegistroVentaxCarga(idarchivo_log).ToList<InputRegistroVenta>();
            }

            return lst;
        }

        public List<InputRegistroCompra> ObtieneDetalleRegistroCompra(Int32 id_archivo_log)
        {
            List<InputRegistroCompra> lst = new List<InputRegistroCompra>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ObtieneRegistroCompra_x_IdLog(id_archivo_log).ToList<InputRegistroCompra>();
            }

            return lst;
        }

        public List<InputLibroDiario> ObtieneDetalleLibroDiario(Int32 id_archivo_log)
        {
            List<InputLibroDiario> lst = new List<InputLibroDiario>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.LibroDiarioxCarga(id_archivo_log).ToList<InputLibroDiario>();
            }

            return lst;
        }

        public List<InputLibroMayor> ObtieneDetalleLibroMayor(Int32 id_archivo_log)
        {
            List<InputLibroMayor> lst = new List<InputLibroMayor>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.LibroMayorxCarga(id_archivo_log).ToList<InputLibroMayor>();
            }

            return lst;
        }

        public List<InputRegistroVenta> ObtieneDetalleExport(Int32 mes, Int32 anio,Int32 id_archivo_log)
        {
            List<InputRegistroVenta> lst = new List<InputRegistroVenta>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.GetVentas_x_Periodo(mes, anio, id_archivo_log).ToList<InputRegistroVenta>();
            }

            return lst;
        }

        public List<InputRegistroCompra> ObtieneDetalleExportRegCompra(Int32 mes, Int32 anio, Int32 id_archivo_log)
        {
            List<InputRegistroCompra> lst = new List<InputRegistroCompra>();

            using (BDTramaPLEEntities ent = new BDTramaPLEEntities())
            {
                lst = ent.ObtieneRegistroCompraExport(id_archivo_log).ToList<InputRegistroCompra>();
            }

            return lst;
        }
    }
}
