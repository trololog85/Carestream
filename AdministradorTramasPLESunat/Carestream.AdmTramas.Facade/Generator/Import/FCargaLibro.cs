using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Interfaces;
using Carestream.AdmTramas.DataAccess.Repository.Versiones.Version_4_0;
using Carestream.AdmTramas.Facade.Generator.Interface;
using Carestream.AdmTramas.Facade.Log;
using Carestream.AdmTramas.Generator.Import.Interface;
using Carestream.AdmTramas.Model.Tipos;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramas.Facade.Generator.Import
{
    public class FCargaLibro : IFCargaLibro
    {        
        private readonly IImportLibroRegistroVentas _objImportVentas;
        private readonly IImportLibroRegistroCompras _objImportCompras;
        private readonly IImportLibroMayor _objImportLibroMayor;
        private readonly IImportLibroDiario _objImportLibroDiario;
        private readonly ILibroLogRepository _daLibroLog;
        private readonly IImportLibroDiarioDetalle _objImportLibroDiarioDetalle;
        private readonly IImportLibroNoDomiciliado _objImportLibroNoDomiciliado;

        public FCargaLibro(IImportLibroRegistroVentas objImportVentas, IImportLibroRegistroCompras objImportCompras,
            IImportLibroMayor objImportLibroMayor, IImportLibroDiario objImportLibroDiario, IImportLibroDiarioDetalle objImportLibroDiarioDetalle, IImportLibroNoDomiciliado objImportLibroNoDomiciliado)
        {
            _objImportVentas = objImportVentas;
            _objImportCompras = objImportCompras;
            _objImportLibroDiario = objImportLibroDiario;
            _objImportLibroDiarioDetalle = objImportLibroDiarioDetalle;
            _objImportLibroNoDomiciliado = objImportLibroNoDomiciliado;
            _objImportLibroMayor = objImportLibroMayor;
            _daLibroLog = new DALibroLog(new AdmTramasContainer());
        }

        public Task<string> GuardarImport(Model.Entities.Import import)
        {
            Task<string> result = null;

            var tipoLibro = import.Tipo;

            switch (tipoLibro)
            {
                case TipoLibro.Ventas:
                    result = Task.Run(()=>GuardarImport<RegistroVenta>(import));
                    break;
                case TipoLibro.Compras:
                    result = Task.Run(()=>GuardarImport<RegistroCompra>(import));
                    break;
                case TipoLibro.LibroDiario:
                    result = Task.Run(()=>GuardarImport<LibroDiario>(import));
                    break;
                case TipoLibro.LibroMayor:
                    result = Task.Run(()=>GuardarImport<LibroMayor>(import));
                    break;
                case TipoLibro.LibroDiarioDetalle:
                    result = Task.Run(() => GuardarImport<LibroDiarioDetalle>(import));
                    break;
                case TipoLibro.NoDomiciliado:
                    result = Task.Run(() => GuardarImport<RegistroNoDomiciliado>(import));
                    break;
            }

            return result;
        }

        private async Task<string> GuardarImport<T>(Model.Entities.Import import)
        {
            var prgb = import.ProgressBar;
            var lbl = import.LblMessage;

            if (!lbl.CheckAccess())
            {
                lbl.Dispatcher.Invoke(() => lbl.Content = "Leyendo Archivo...");
            }

            if (!prgb.CheckAccess())
            {
                prgb.Dispatcher.Invoke(() => prgb.Value = 0);    
            }

            //Leemos el archivo
            var lstImport = new List<T>();

            var result = await Task.Run(() => LeerArchivoImport<T>(import));

            if (result.Item2 != String.Empty)
                return result.Item2;

            if (!prgb.CheckAccess())
            {
                prgb.Dispatcher.Invoke(() => prgb.Value = 33);
            }

            if (!lbl.CheckAccess())
            {
                lbl.Dispatcher.Invoke(() => lbl.Content = "Insertando Encabezados...");
            }

            if (result.Item1 == null)
                return result.Item2;

            lstImport = result.Item1;

            //Insertamos la cabecera
            var result1 = await Task.Run(()=>InsertaCabeceraLogImport(import, lstImport.Count));

            if (result1.Item1 != String.Empty)
                return result1.Item1;

            var lstComplete = AgregarIdLog(lstImport, import.Tipo, result1.Item2);

            if (!prgb.CheckAccess())
            {
                prgb.Dispatcher.Invoke(() => prgb.Value = 66);
            }

            if (!lbl.CheckAccess())
            {
                lbl.Dispatcher.Invoke(() => lbl.Content = "Insertando Detalle...");
            }

            //Insertamos el detalle
            var result2 = await Task.Run(()=>InsertarDetalleImport<T>(result.Item1, import));

            if (!prgb.CheckAccess())
            {
                prgb.Dispatcher.Invoke(() => prgb.Value = 100);
            }

            if (!lbl.CheckAccess())
            {
                lbl.Dispatcher.Invoke(() => lbl.Content = "");
            }

            return result2;
        }

        private List<T> AgregarIdLog<T>(IEnumerable<T> lstDetalle,TipoLibro tipoLibro,
            int idLibroLog)
        {
            var lstResult = new List<T>();
            var lstVentas = new List<RegistroVenta>();
            var lstLibroDiario = new List<LibroDiario>();
            var lstCompras = new List<RegistroCompra>();
            var lstDiarioDetalles = new List<LibroDiarioDetalle>();
            var lstMayor = new List<LibroMayor>();
            var lstNoDomiciliado = new List<RegistroNoDomiciliado>();

            switch (tipoLibro)
            {
                case TipoLibro.LibroDiario:
                    lstLibroDiario = lstDetalle.Cast<LibroDiario>().ToList();

                    foreach (var libro in lstLibroDiario)
                    {
                        libro.IdLibroLog = idLibroLog;
                    }

                    lstResult = lstLibroDiario.Cast<T>().ToList();
                    break;
                case TipoLibro.Ventas:
                    lstVentas = lstDetalle.Cast<RegistroVenta>().ToList();

                    foreach (var libro in lstVentas)
                    {
                        libro.IdLibroLog = idLibroLog;
                    }

                    lstResult = lstVentas.Cast<T>().ToList();
                    break;
                case TipoLibro.Compras:
                    lstCompras = lstDetalle.Cast<RegistroCompra>().ToList();

                    foreach (var libro in lstCompras)
                    {
                        libro.IdLibroLog = idLibroLog;
                    }
                    lstResult = lstCompras.Cast<T>().ToList();
                    break;
                case TipoLibro.LibroDiarioDetalle:
                    lstDiarioDetalles = lstDetalle.Cast<LibroDiarioDetalle>().ToList();

                    foreach (var libro in lstDiarioDetalles)
                    {
                        libro.IdLibroLog = idLibroLog;
                    }
                    lstResult = lstDiarioDetalles.Cast<T>().ToList();
                    break;
                case TipoLibro.LibroMayor:
                    lstMayor = lstDetalle.Cast<LibroMayor>().ToList();

                    foreach (var libro in lstMayor)
                    {
                        libro.IdLibroLog = idLibroLog;
                    }
                    lstResult = lstMayor.Cast<T>().ToList();
                    break;
                case TipoLibro.NoDomiciliado:
                    lstNoDomiciliado = lstDetalle.Cast<RegistroNoDomiciliado>().ToList();

                    foreach (var libro in lstNoDomiciliado)
                    {
                        libro.IdLibroLog = idLibroLog;
                    }
                    lstResult = lstNoDomiciliado.Cast<T>().ToList();
                    break;
            }

            return lstResult;
        }

        private string InsertarDetalleImport<T>(IEnumerable<T> lstDetalle, 
            Model.Entities.Import import)
        {
            var message = String.Empty;

            try
            {
                switch (import.Tipo)
                {
                    case TipoLibro.Ventas:
                        var detalle = lstDetalle.Cast<RegistroVenta>().ToList();
                        _daLibroLog.GuardarDetalleImportVentas(detalle);
                        break;
                    case TipoLibro.Compras:
                        var detalle1 = lstDetalle.Cast<RegistroCompra>().ToList();
                        _daLibroLog.GuardarDetalleImportCompras(detalle1);
                        break;
                    case TipoLibro.LibroDiario:
                        var detalle2 = lstDetalle.Cast<LibroDiario>().ToList();
                        _daLibroLog.GuardarDetalleImportDiario(detalle2);
                        break;
                    case TipoLibro.LibroMayor:
                        var detalle3 = lstDetalle.Cast<LibroMayor>().ToList();
                        _daLibroLog.GuardarDetalleImportMayor(detalle3);
                        break;
                    case TipoLibro.LibroDiarioDetalle:
                        var detalle4 = lstDetalle.Cast<LibroDiarioDetalle>().ToList();
                        _daLibroLog.GuardarDetalleImportDiarioDetalle(detalle4);
                        break;
                    case TipoLibro.NoDomiciliado:
                        var detalle5 = lstDetalle.Cast<RegistroNoDomiciliado>().ToList();
                        _daLibroLog.GuardarDetalleNoDomicialado(detalle5);
                        break;
                }
            }
            catch (SqlException sqlEx)
            {
                message = String.Format("Exception: {0} {1} Fuente: {2}.", sqlEx.Message,
                    Environment.NewLine, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                message = String.Format("Exception: {0} {1} Source: {2}.", ex.Message,
                    Environment.NewLine, ex.StackTrace);
            }

            return message;
        }

        private Tuple<List<T>, string> LeerArchivoImport<T>(Model.Entities.Import import)
        {
            var lstImport = new List<T>();
            var message = String.Empty;

            try
            {
                switch (import.Tipo)
                {
                    case TipoLibro.Ventas:
                        lstImport = _objImportVentas.LeeRegistro(import).Cast<T>().ToList();
                        break;
                    case TipoLibro.Compras:
                        lstImport = _objImportCompras.LeeRegistro(import).Cast<T>().ToList();
                        break;
                    case TipoLibro.LibroDiario:
                        lstImport = _objImportLibroDiario.LeeRegistro(import).Cast<T>().ToList();
                        break;
                    case TipoLibro.LibroMayor:
                        lstImport = _objImportLibroMayor.LeeRegistro(import).Cast<T>().ToList();
                        break;
                    case TipoLibro.LibroDiarioDetalle:
                        lstImport = _objImportLibroDiarioDetalle.LeeRegistro(import).Cast<T>().ToList();
                        break;
                    case TipoLibro.NoDomiciliado:
                        lstImport = _objImportLibroNoDomiciliado.LeeRegistro(import).Cast<T>().ToList();
                        break;
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                message = String.Format("Exception: {0} {1} Fuente: {2}.", ex.Message,
                    Environment.NewLine, ex.StackTrace);
                return new Tuple<List<T>, string>(null, message);
            }
            catch (SqlException sqlEx)
            {
                message = String.Format("Exception: {0} {1} Fuente: {2}.", sqlEx.Message,
                    Environment.NewLine, sqlEx.StackTrace);
                return new Tuple<List<T>, string>(null, message);
            }
            catch (InvalidCastException invEx)
            {
                message = String.Format("Exception: {0} {1} Fuente: {2}.", invEx.Data,
                    Environment.NewLine, invEx.StackTrace);
                return new Tuple<List<T>, string>(null, message);
            }

            return new Tuple<List<T>, string>(lstImport,String.Empty);
        }

        private Tuple<string,int> InsertaCabeceraLogImport(Model.Entities.Import import,int registros)
        {
            //Insertamos la cabecera del log
            var libroLog = new Model.Entities.LibroLog
            {
                IdLibro = import.IdLibro,
                IndicadorLibro = import.Registro,
                IndicadorMoneda = import.Moneda,
                IndicadorOperacion = import.Operacion,
                NombreLibro = Archivo.ObtieneNombreArchivo(import.Ruta),
                RUC = import.Ruc,
                Registros = registros,
                TipoLog = "I",
                sFechaCarga = Formato.FormateaFecha("AAAA-MM-DD", DateTime.Now),
                sFechaGeneracion = String.Empty,
                FechaPeriodo = import.Periodo
            };

            var fLibroLog = new FLibroLog();

            return fLibroLog.RegistrarLog(libroLog);
        }
    }
}
