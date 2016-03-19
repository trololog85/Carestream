using System;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Converter
{
    public class LibroLogConverter
    {
        public static LibroLog ConvertOut(DataAccess.Model.LibroLog log)
        {
            return new LibroLog
            {
                Id = log.Id,
                IdLibro = log.IdLibro,
                IndicadorLibro = log.IndicadorLibro,
                IndicadorMoneda = log.IndicadorMoneda,
                IndicadorOperacion = log.IndicadorOperacion,
                NombreLibro = log.NombreLibro,
                RUC = log.RUC,
                Registros = log.Registros,
                TipoLog = log.TipoLog,
                TotalErrores = Convert.ToInt32(log.Errores),
                sFechaCarga = (log.FechaCarga==null?string.Empty:Formato.FormateaFecha("DD/MM/AAAA",System.Convert.ToDateTime(log.FechaCarga))),
                sFechaGeneracion = (log.FechaGeneracion == null ? string.Empty : Formato.FormateaFecha("DD/MM/AAAA", System.Convert.ToDateTime(log.FechaGeneracion)))
            };
        }

        public static DataAccess.Model.LibroLog ConvertIn(LibroLog log)
        {
            return new DataAccess.Model.LibroLog
            {
                IdLibro = log.IdLibro,
                TipoLog = log.TipoLog,
                FechaCarga =
                    (log.sFechaCarga == string.Empty ? (DateTime?) null : Convert.ToDateTime(log.sFechaCarga)),
                FechaGeneracion =
                    (log.sFechaGeneracion == string.Empty
                        ? (DateTime?) null
                        : Convert.ToDateTime(log.sFechaGeneracion)),
                IndicadorLibro = log.IndicadorLibro,
                IndicadorMoneda = log.IndicadorMoneda,
                IndicadorOperacion = log.IndicadorOperacion,
                Registros = log.Registros,
                NombreLibro = log.NombreLibro,
                RUC = log.RUC,
                Errores = log.TotalErrores,
                FechaPeriodo = log.FechaPeriodo
            };
        }
    }
}
