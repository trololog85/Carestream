using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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

        public FCargaLibro(IImportLibroRegistroVentas objImportVentas, IImportLibroRegistroCompras objImportCompras,
            IImportLibroMayor objImportLibroMayor, IImportLibroDiario objImportLibroDiario, IImportLibroDiarioDetalle objImportLibroDiarioDetalle)
        {
            _objImportVentas = objImportVentas;
            _objImportCompras = objImportCompras;
            _objImportLibroDiario = objImportLibroDiario;
            _objImportLibroDiarioDetalle = objImportLibroDiarioDetalle;
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

                    //result = Task.Run(()=>GuardarImport<RegistroVenta>(import));

                    result = new Task<string>(() => GuardarImport<RegistroVenta>(import).Result);
                    result.Start();
                    break;
                case TipoLibro.Compras:
                    //result = Task.Run(()=>GuardarImport<RegistroCompra>(import));

                    result = new Task<string>(() => GuardarImport<RegistroCompra>(import).Result);
                    result.Start();
                    break;
                case TipoLibro.LibroDiario:
                    //result = Task.Run(()=>GuardarImport<LibroDiario>(import));

                    result = new Task<string>(() => GuardarImport<LibroDiario>(import).Result);
                    result.Start();
                    break;
                case TipoLibro.LibroMayor:
                    //result = Task.Run(()=>GuardarImport<LibroMayor>(import));

                    result = new Task<string>(() => GuardarImport<LibroMayor>(import).Result);
                    result.Start();
                    break;
                case TipoLibro.LibroDiarioDetalle:
                    //result = Task.Run(() => GuardarImport<LibroDiarioDetalle>(import));

                    result = new Task<string>(() => GuardarImport<LibroDiarioDetalle>(import).Result);
                    result.Start();
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
                lbl.Dispatcher.Invoke(new Func<object>(() => lbl.Content = "Leyendo Archivo..."));
            }

            if (!prgb.CheckAccess())
            {
                prgb.Dispatcher.Invoke(new Func<double>(() => prgb.Value = 0));    
            }

            //Leemos el archivo
            var lstImport = new List<T>();

            var taskRead = new Task<Result<T>>(()=>LeerArchivoImport<T>(import));

            taskRead.Start();

            /*
             * Code for Framework 4.5
             * Microsoft sucks
             */
            //var result = await Task.Run(() => LeerArchivoImport<T>(import));

            await taskRead;

            var result = taskRead.Result;

            if (result.Mensaje != String.Empty)
                return result.Mensaje;

            if (!prgb.CheckAccess())
            {
                prgb.Dispatcher.Invoke(new Func<double>(() => prgb.Value = 33));
            }

            if (!lbl.CheckAccess())
            {
                lbl.Dispatcher.Invoke(new Func<object>(() => lbl.Content = "Insertando Encabezados..."));
            }

            if (result.Source == null)
                return result.Mensaje;

            lstImport = result.Source;

            //Insertamos la cabecera
            var taskInsertHead = new Task<Result2>(()=>InsertaCabeceraLogImport(import, lstImport.Count));

            taskInsertHead.Start();

            await taskInsertHead;

            var result1 = taskInsertHead.Result;

            /*
             * Code for Framework 4.5
             * Microsoft sucks
             */
            //var result1 = await Task.Run(()=>InsertaCabeceraLogImport(import, lstImport.Count));

            if (result1.Mensaje != String.Empty)
                return result1.Mensaje;

            var lstComplete = AgregarIdLog(lstImport, import.Tipo, result1.Id);

            if (!prgb.CheckAccess())
            {
                prgb.Dispatcher.Invoke(new Func<double>(() => prgb.Value = 66));
            }

            if (!lbl.CheckAccess())
            {
                lbl.Dispatcher.Invoke(new Func<object>(() => lbl.Content = "Insertando Detalle..."));
            }

            //Insertamos el detalle

            /*
             * Code for Framework 4.5
             * Microsoft sucks
             */
            //var result2 = await Task.Run(()=>InsertarDetalleImport<T>(lstComplete, import));

            var taskInsertDetail = new Task<string>(()=>InsertarDetalleImport<T>(lstComplete, import));

            taskInsertDetail.Start();

            await taskInsertDetail;

            var result2 = taskInsertDetail.Result;

            if (!prgb.CheckAccess())
            {
                prgb.Dispatcher.Invoke(new Func<double>(() => prgb.Value = 100));
            }

            if (!lbl.CheckAccess())
            {
                lbl.Dispatcher.Invoke(new Func<object>(() => lbl.Content = ""));
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

        private Result<T> LeerArchivoImport<T>(Model.Entities.Import import)
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
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                message = String.Format("Exception: {0} {1} Fuente: {2}.", ex.Message,
                    Environment.NewLine, ex.StackTrace);
                return new Result<T>
                {
                    Mensaje = message,
                    Source = null
                };
            }
            catch (SqlException sqlEx)
            {
                message = String.Format("Exception: {0} {1} Fuente: {2}.", sqlEx.Message,
                    Environment.NewLine, sqlEx.StackTrace);
                return new Result<T>
                {
                    Mensaje = message,
                    Source = null
                };
            }
            catch (InvalidCastException invEx)
            {
                message = String.Format("Exception: {0} {1} Fuente: {2}.", invEx.Data,
                    Environment.NewLine, invEx.StackTrace);
                return new Result<T>
                {
                    Mensaje = message,
                    Source = null
                };
            }

            return new Result<T>
                {
                    Mensaje = String.Empty,
                    Source = lstImport
                };
        }

        private Result2 InsertaCabeceraLogImport(Model.Entities.Import import,int registros)
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
                sFechaGeneracion = String.Empty
            };

            var fLibroLog = new FLibroLog();

            return fLibroLog.RegistrarLog(libroLog);
        }
    }
}
