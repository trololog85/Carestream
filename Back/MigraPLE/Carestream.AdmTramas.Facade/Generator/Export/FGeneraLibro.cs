using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Carestream.AdmTramas.Converter.Compras;
using Carestream.AdmTramas.Converter.LibroDiario;
using Carestream.AdmTramas.Converter.LibroDiarioDetalle;
using Carestream.AdmTramas.Converter.LibroMayor;
using Carestream.AdmTramas.Converter.Ventas;
using Carestream.AdmTramas.DataAccess.Model;
using Carestream.AdmTramas.DataAccess.Repository.Interfaces;
using Carestream.AdmTramas.DataAccess.Repository.Versiones.Version_4_0;
using Carestream.AdmTramas.Facade.Generator.Interface;
using Carestream.AdmTramas.Facade.Log;
using Carestream.AdmTramas.Generator.Export.Tramas.Version_4_0;
using Carestream.AdmTramas.Generator.Export.Validador;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Model.Tipos;
using Carestream.AdmTramas.Utils;
using LibroDiario = Carestream.AdmTramas.Model.Entities.LibroDiario;
using LibroDiarioDetalle = Carestream.AdmTramas.Model.Entities.LibroDiarioDetalle;
using LibroMayor = Carestream.AdmTramas.Model.Entities.LibroMayor;
using RegistroCompra = Carestream.AdmTramas.Model.Entities.RegistroCompra;
using RegistroVenta = Carestream.AdmTramas.Model.Entities.RegistroVenta;
using Validador = Carestream.AdmTramas.Generator.Export.Validador.Version_4_0;

namespace Carestream.AdmTramas.Facade.Generator.Export
{
    public class FGeneraLibro:IFGeneraLibro
    {
        private readonly ILibroLogRepository _libroLogRepository = new DALibroLog(new AdmTramasContainer());

        public async Task<ExportResult> ExportaArchivo(Model.Entities.Export export)
        {
            var idLibroLog = export.IdLibroLog;
            var tipoLibro = export.TipoLibro;

            var errores = new List<Error>();

            var total = 0;

            var progress = export.ProgressBar;
            var label = export.LblMessage;

            //4. Genera la trama
            var ruta = ObtieneNombreArchivo(export);

            //2. Convertimos la info al modelo
            switch (tipoLibro)
            {
                case TipoLibro.Ventas:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 5));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Obtienendo Informacion..."));
                    }

                    var taskInfoPeriodo = new Task<List<DataAccess.Model.RegistroVenta>>(()=>ObtieneInformacionPeriodo<DataAccess.Model.RegistroVenta>(idLibroLog, tipoLibro));

                    //var infoPeriodo = await Task.Run(() => ObtieneInformacionPeriodo<DataAccess.Model.RegistroVenta>(idLibroLog, tipoLibro));

                    taskInfoPeriodo.Start();

                    await taskInfoPeriodo;

                    var infoPeriodoResult = taskInfoPeriodo.Result;

                    var ventasModel = ConvierteInfoModel<RegistroVenta, DataAccess.Model.RegistroVenta>(infoPeriodoResult, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 33));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Validando Informacion..."));
                    }

                    var validador = new ValidadorLibroVentas(new Validador.RegistroVenta(new Validador.Common()));

                    var taskValidar = new Task<List<Error>>(() => validador.ValidaRegistros(ventasModel));

                    taskValidar.Start();

                    await taskValidar;

                    var resultTaskValidar = taskValidar.Result;

                    errores = resultTaskValidar;

                    //errores = await Task.Run(() => validador.ValidaRegistros(ventasModel));
                    total = infoPeriodoResult.Count;

                    var generador = new TramaVentas();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 66));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Generando Archivo..."));
                    }

                    var generarTrama = new Task(()=>generador.GeneraTrama(ventasModel, ruta));

                    generarTrama.Start();

                    await generarTrama;

                    //await Task.Run(() => generador.GeneraTrama(ventasModel, ruta));

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 100));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = ""));
                    }
                    break;
                case TipoLibro.Compras:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 5));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Obtienendo Informacion..."));
                    }

                    //var infoPeriodo1 = ObtieneInformacionPeriodo<DataAccess.Model.RegistroCompra>(idLibroLog, tipoLibro);

                    var taskInfoPeriodo1 = new Task<List<DataAccess.Model.RegistroCompra>>(() => ObtieneInformacionPeriodo<DataAccess.Model.RegistroCompra>(idLibroLog, tipoLibro));

                    taskInfoPeriodo1.Start();

                    await taskInfoPeriodo1;

                    var taskInfoPeriodo1Result = taskInfoPeriodo1.Result;

                    var comprasModel = ConvierteInfoModel<RegistroCompra, DataAccess.Model.RegistroCompra>(taskInfoPeriodo1Result, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 33));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Validando Informacion..."));
                    }

                    var validador1 = new ValidadorLibroCompras(new Validador.RegistroCompra(new Validador.Common()));

                    var taskErrores = new Task<List<Error>>(()=>validador1.ValidaRegistros(comprasModel));

                    taskErrores.Start();

                    await taskErrores;

                    //errores = await Task.Run(() => validador1.ValidaRegistros(comprasModel));

                    var resultTaskErrores = taskErrores.Result;

                    errores = resultTaskErrores;

                    total = taskInfoPeriodo1Result.Count;

                    var generador1 = new TramaCompras();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 66));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Generando Archivo..."));
                    }

                    //await Task.Run(() => generador1.GeneraTrama(comprasModel, ruta));

                    var generarTrama1 = new Task(() => generador1.GeneraTrama(comprasModel, ruta));

                    generarTrama1.Start();

                    await generarTrama1;

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 100));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = ""));
                    }
                    break;
                case TipoLibro.LibroMayor:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 0));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Obtienendo Informacion..."));
                    }

                    var taskInfoPeriodo2 = new Task<List<DataAccess.Model.LibroMayor>>(()=>ObtieneInformacionPeriodo<DataAccess.Model.LibroMayor>(idLibroLog, tipoLibro));

                    //var infoPeriodo2 = await Task.Run(() => ObtieneInformacionPeriodo<DataAccess.Model.LibroMayor>(idLibroLog, tipoLibro));

                    taskInfoPeriodo2.Start();

                    await taskInfoPeriodo2;

                    var taskInfoPeriodo2Result = taskInfoPeriodo2.Result;

                    var mayorModel = ConvierteInfoModel<LibroMayor, DataAccess.Model.LibroMayor>(taskInfoPeriodo2Result, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 33));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Validando Informacion..."));
                    }

                    var validador2 = new ValidadorLibroMayor(new Validador.LibroMayor(new Validador.Common()));

                    var taskErrores2 = new Task<List<Error>>(()=>validador2.ValidaRegistros(mayorModel));

                    taskErrores2.Start();

                    await taskErrores2;

                    var taskErroresResult = taskErrores2.Result;

                    //errores = await Task.Run(() => validador2.ValidaRegistros(mayorModel));

                    errores = taskErroresResult;

                    total = taskInfoPeriodo2Result.Count;

                    var generador2 = new TramaLibroMayor();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 66));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Generando Archivo..."));
                    }

                    var generarTrama2 = new Task(() => generador2.GeneraTrama(mayorModel, ruta));

                    generarTrama2.Start();

                    await generarTrama2;

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 100));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = ""));
                    }
                    break;
                case TipoLibro.LibroDiario:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 0));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Obtienendo Informacion..."));
                    }

                    var taskInfoPeriodo3 = new Task<List<DataAccess.Model.LibroDiario>>(() => ObtieneInformacionPeriodo<DataAccess.Model.LibroDiario>(idLibroLog, tipoLibro));

                    //var infoPeriodo3 = await Task.Run(() => ObtieneInformacionPeriodo<DataAccess.Model.LibroDiario>(idLibroLog, tipoLibro));

                    taskInfoPeriodo3.Start();

                    await taskInfoPeriodo3;

                    var taskInfoPeriodoResult3 = taskInfoPeriodo3.Result;

                    var diarioModel = ConvierteInfoModel<LibroDiario, DataAccess.Model.LibroDiario>(taskInfoPeriodoResult3, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 33));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Validando Informacion..."));
                    }

                    var validador3 = new ValidadorLibroDiario(new Validador.LibroDiario(new Validador.Common()));

                    var taskErrores3 = new Task<List<Error>>(() => validador3.ValidaRegistros(diarioModel));

                    taskErrores3.Start();

                    await taskErrores3;

                    var taskErrores3Result = taskErrores3.Result;

                    //errores = await Task.Run(() => validador3.ValidaRegistros(diarioModel));

                    total = taskErrores3Result.Count;

                    var generador3 = new TramaLibroDiario();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 66));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Generando Archivo..."));
                    }

                    //await Task.Run(() => generador3.GeneraTrama(diarioModel, ruta));

                    var generarTrama3 = new Task(() => generador3.GeneraTrama(diarioModel, ruta));

                    generarTrama3.Start();

                    await generarTrama3;

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 100));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = ""));
                    }
                    break;
                case TipoLibro.LibroDiarioDetalle:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 0));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Obtienendo Informacion..."));
                    }

                    var taskInfoPeriodo4 = new Task<List<DataAccess.Model.LibroDiarioDetalle>>(() => ObtieneInformacionPeriodo<DataAccess.Model.LibroDiarioDetalle>(idLibroLog, tipoLibro));

                    //var infoPeriodo4 = await Task.Run(() => ObtieneInformacionPeriodo<DataAccess.Model.LibroDiarioDetalle>(idLibroLog, tipoLibro));

                    var taskInfoPeriodoResult4 = taskInfoPeriodo4.Result;

                    var detalleModel = ConvierteInfoModel<LibroDiarioDetalle, DataAccess.Model.LibroDiarioDetalle>(taskInfoPeriodoResult4, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 33));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Validando Informacion..."));
                    }

                    var validador4 = new ValidadorLibroDiarioDetalle(new Validador.LibroDiarioDetalle(new Validador.Common()));

                    var taskErrores4 = new Task<List<Error>>(() => validador4.ValidaRegistros(detalleModel));

                    var taskErrores4Result = taskErrores4.Result;

                    //errores = await Task.Run(() => validador4.ValidaRegistros(detalleModel));

                    total = taskErrores4Result.Count;

                    var generador4 = new TramaLibroDetalle();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 66));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = "Generando Archivo..."));
                    }

                    var generarTrama4 = new Task(() => generador4.GeneraTrama(detalleModel, ruta));

                    generarTrama4.Start();

                    await generarTrama4;

                    //await Task.Run(() => generador4.GeneraTrama(detalleModel, ruta));

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<double>(() => progress.Value = 100));
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(new Func<object>(() => label.Content = ""));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            //5. Insertamos la cabecera
            var result = InsertaCabeceraLogExport(export, total, ruta.NombreArchivo,errores);

            if (result.Mensaje != String.Empty)
                return new ExportResult { Message = result.Mensaje };

            //6. Inserta los errores en la BD
            var msg = InsertaErrores(errores,result.Id);

            if(msg!=String.Empty)
                return new ExportResult{Message = msg};

            if (result.Mensaje != String.Empty)
                return new ExportResult { Message = result.Mensaje };

            if (errores.Any())
                return new ExportResult
                {
                    Message = String.Empty,
                    Errores= errores
                };

            return new ExportResult
            {
                Message = String.Empty
            };
        }


        private Result2 InsertaCabeceraLogExport(Model.Entities.Export export, int registros, 
            string nombreArchivo, IEnumerable<Error> errores)
        {
            var total = errores.SelectMany(x => x.Detalles).Count();

            var libroLog = new Model.Entities.LibroLog
            {
                IdLibro = export.IdLibro,
                IndicadorLibro = String.Empty,
                IndicadorMoneda = String.Empty,
                IndicadorOperacion = String.Empty,
                NombreLibro = nombreArchivo,
                RUC = String.Empty,
                Registros = registros,
                TipoLog = "E",
                sFechaCarga = String.Empty,
                sFechaGeneracion = Formato.FormateaFecha("AAAA-MM-DD", DateTime.Now),
                TotalErrores = total
            };

            var fLibroLog = new FLibroLog();

            return fLibroLog.RegistrarLog(libroLog);
        }

        private List<T> ObtieneInformacionPeriodo<T>(int IdLibroLog,TipoLibro tipoLibro)
        {
            var info = new List<T>();

            switch (tipoLibro)
            {
                case TipoLibro.Ventas:
                    info = _libroLogRepository.ConsultaImportVentas(IdLibroLog).Cast<T>().ToList();
                    break;
                case TipoLibro.Compras:
                    info = _libroLogRepository.ConsultaRegistroCompras(IdLibroLog).Cast<T>().ToList();
                    break;
                case TipoLibro.LibroMayor:
                    info = _libroLogRepository.ConsultaLibroMayor(IdLibroLog).Cast<T>().ToList();
                    break;
                case TipoLibro.LibroDiario:
                    info = _libroLogRepository.ConsultaLibroDiario(IdLibroLog).Cast<T>().ToList();
                    break;
                case TipoLibro.LibroDiarioDetalle:
                    info = _libroLogRepository.ConsultaLibroDiarioDetalle(IdLibroLog).Cast<T>().ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoLibro");
            }

            return info;
        }

        private List<T> ConvierteInfoModel<T,M>(List<M> lstData,TipoLibro tipoLibro)
        {
            var result = new List<T>();

            switch (tipoLibro)
            {
                case TipoLibro.Ventas:
                    var model1 = RegistroVentaConverter.ConvertList(lstData.Cast<DataAccess.Model.RegistroVenta>());
                    result = model1.Cast<T>().ToList();
                    break;
                case TipoLibro.Compras:
                    var model2 = RegistroComprasConverter.ConvertList(lstData.Cast<DataAccess.Model.RegistroCompra>());
                    result = model2.Cast<T>().ToList();
                    break;
                case TipoLibro.LibroMayor:
                    var model3 = LibroMayorConverter.ConvertList(lstData.Cast<DataAccess.Model.LibroMayor>());
                    result = model3.Cast<T>().ToList();
                    break;
                case TipoLibro.LibroDiario:
                    var model4 = LibroDiarioConverter.ConvertList(lstData.Cast<DataAccess.Model.LibroDiario>());
                    result = model4.Cast<T>().ToList();
                    break;
                case TipoLibro.LibroDiarioDetalle:
                    var model5 = LibroDiarioDetalleConverter.ConvertList(lstData.Cast<DataAccess.Model.LibroDiarioDetalle>());
                    result = model5.Cast<T>().ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoLibro");
            }

            return result;
        }

        private RutaArchivo ObtieneNombreArchivo(Model.Entities.Export export)
        {
            var nombreLibro = new NombreLibro
            {
                Anio = export.Anio.ToString(CultureInfo.InvariantCulture),
                CodigoMoneda = Formato.ObtieneMoneda(export.IdMoneda),
                CodigoOperacion = export.IdOperacion,
                CodigoOportunidad = "00",
                Dia = "00",
                Identificador = "LE",
                IdentificadorLibro = export.CodigoLibro,
                Indicador = "1",
                Mes = Formato.RellenaNumero(export.Mes),
                NumeroRuc = export.NumeroRuc,
            };

            var nombreArchivo = Formato.ObtieneNombreArchivo(nombreLibro);

            return new RutaArchivo
            {
                Ruta = export.RutaArchivoExport,
                NombreArchivo = nombreArchivo
            };
        }

        private string InsertaErrores(List<Error> errores, int idLibroLog)
        {
            var daError = new DAErrorDetalle(new AdmTramasContainer());

            try
            {
                daError.GuardarErrorDetalle(errores, idLibroLog);
            }
            catch (Exception ex)
            {
                return String.Format("Exception: {0} {1} Source: {2}.", ex.Message,
                    Environment.NewLine, ex.InnerException);
            }

            return String.Empty;
        }
    }
}
