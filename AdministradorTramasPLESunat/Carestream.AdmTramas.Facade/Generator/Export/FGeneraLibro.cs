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
                        progress.Dispatcher.Invoke(() => progress.Value = 0);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Obtienendo Informacion...");
                    }

                    var infoPeriodo = await Task.Run(() => ObtieneInformacionPeriodo<DataAccess.Model.RegistroVenta>(idLibroLog, tipoLibro));
                    var ventasModel = ConvierteInfoModel<RegistroVenta, DataAccess.Model.RegistroVenta>(infoPeriodo, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 33);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Validando Informacion...");
                    }

                    var validador = new ValidadorLibroVentas(new Validador.RegistroVenta(new Validador.Common()));
                    errores = await Task.Run(() => validador.ValidaRegistros(ventasModel));
                    total = infoPeriodo.Count;
                    var generador = new TramaVentas();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 66);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Generando Archivo...");
                    }

                    await Task.Run(() => generador.GeneraTrama(ventasModel, ruta));

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 100);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "");
                    }
                    break;
                case TipoLibro.Compras:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 0);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Obtienendo Informacion...");
                    }

                    var infoPeriodo1 = ObtieneInformacionPeriodo<DataAccess.Model.RegistroCompra>(idLibroLog, tipoLibro);

                    var comprasModel = ConvierteInfoModel<RegistroCompra, DataAccess.Model.RegistroCompra>(infoPeriodo1, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 33);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Validando Informacion...");
                    }

                    var validador1 = new ValidadorLibroCompras(new Validador.RegistroCompra(new Validador.Common()));

                    errores = await Task.Run(() => validador1.ValidaRegistros(comprasModel));
                    total = infoPeriodo1.Count;
                    var generador1 = new TramaCompras();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 66);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Generando Archivo...");
                    }

                    await Task.Run(() => generador1.GeneraTrama(comprasModel, ruta));

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 100);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "");
                    }
                    break;
                case TipoLibro.LibroMayor:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 0);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Obtienendo Informacion...");
                    }

                    var infoPeriodo2 = await Task.Run(() => ObtieneInformacionPeriodo<DataAccess.Model.LibroMayor>(idLibroLog, tipoLibro));

                    var mayorModel = ConvierteInfoModel<LibroMayor, DataAccess.Model.LibroMayor>(infoPeriodo2, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 33);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Validando Informacion...");
                    }

                    var validador2 = new ValidadorLibroMayor(new Validador.LibroMayor(new Validador.Common()));

                    errores = await Task.Run(() => validador2.ValidaRegistros(mayorModel));

                    total = infoPeriodo2.Count;

                    var generador2 = new TramaLibroMayor();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 66);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Generando Archivo...");
                    }

                    await Task.Run(() => generador2.GeneraTrama(mayorModel, ruta));

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 100);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "");
                    }
                    break;
                case TipoLibro.LibroDiario:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 0);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Obtienendo Informacion...");
                    }

                    var infoPeriodo3 = await Task.Run(() => ObtieneInformacionPeriodo<DataAccess.Model.LibroDiario>(idLibroLog, tipoLibro));

                    var diarioModel = ConvierteInfoModel<LibroDiario, DataAccess.Model.LibroDiario>(infoPeriodo3, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 33);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Validando Informacion...");
                    }

                    var validador3 = new ValidadorLibroDiario(new Validador.LibroDiario(new Validador.Common()));

                    errores = await Task.Run(() => validador3.ValidaRegistros(diarioModel));

                    total = infoPeriodo3.Count;

                    var generador3 = new TramaLibroDiario();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 66);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Generando Archivo...");
                    }

                    await Task.Run(() => generador3.GeneraTrama(diarioModel, ruta));

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 100);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "");
                    }
                    break;
                case TipoLibro.LibroDiarioDetalle:
                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 0);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Obtienendo Informacion...");
                    }

                    var infoPeriodo4 = await Task.Run(() => ObtieneInformacionPeriodo<DataAccess.Model.LibroDiarioDetalle>(idLibroLog, tipoLibro));

                    var detalleModel = ConvierteInfoModel<LibroDiarioDetalle, DataAccess.Model.LibroDiarioDetalle>(infoPeriodo4, tipoLibro);

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 33);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Validando Informacion...");
                    }

                    var validador4 = new ValidadorLibroDiarioDetalle(new Validador.LibroDiarioDetalle(new Validador.Common()));

                    errores = await Task.Run(() => validador4.ValidaRegistros(detalleModel));

                    total = infoPeriodo4.Count;

                    var generador4 = new TramaLibroDetalle();

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 66);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "Generando Archivo...");
                    }

                    await Task.Run(() => generador4.GeneraTrama(detalleModel, ruta));

                    if (!progress.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => progress.Value = 100);
                    }

                    if (!label.CheckAccess())
                    {
                        progress.Dispatcher.Invoke(() => label.Content = "");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            //5. Insertamos la cabecera
            var result = InsertaCabeceraLogExport(export, total, ruta.NombreArchivo,errores);

            if (result.Item1 != String.Empty)
                return new ExportResult{Message = result.Item1};

            //6. Inserta los errores en la BD
            var msg = InsertaErrores(errores,result.Item2);

            if(msg!=String.Empty)
                return new ExportResult{Message = msg};

            if(result.Item1!=String.Empty)
                return new ExportResult{Message = result.Item1};

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


        private Tuple<string, int> InsertaCabeceraLogExport(Model.Entities.Export export, int registros, 
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
