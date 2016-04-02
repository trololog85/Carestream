using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using MigraPle.Api.Windows.Utils;
using MigraPle.Api.Windows.Utils.Entities;
using MigraPle.Model.Entities;
using MigraPle.Windows.Search;

namespace MigraPle.Windows.Process
{
    public partial class Import : Window
    {
        private void InitializeWindow()
        {
            this.TxtNroRuc.Text = _configurationGetter.GetConfiguration("RucCliente");

            this.CmbMoneda.ItemsSource = Globals.Monedas;
            this.CmbMoneda.SelectedValue = "PEN";

            this.CmbIndicadorOpe.ItemsSource = Globals.IndicadorOperaciones;
            this.CmbIndicadorOpe.SelectedValue = 1;

            this.CmbContenidoLib.ItemsSource = Globals.LibroRegistro;
            this.CmbContenidoLib.SelectedValue = 1;
        }

        private async void ImportArchivo()
        {
            if (ValidarImport())
            {
                try
                {
                    this.PrgBarImport.IsIndeterminate = true;
                    this.LblMsgProgress.Content = "Copiando Archivo...";

                    _windowsUtils.CopyToShared(this.TxTRuta.Text);

                    var operacion = new Operacion
                    {
                        FechaOperacion = DateTime.Now,
                        IdArchivo = _archivo.Id,
                        NombreArchivo = this.TxTRuta.Text,
                        Periodo = _fechaPeriodo,
                        TipoOperacion = TipoOperacion.Import
                    };

                    this.LblMsgProgress.Content = "Leyendo Archivo...";

                    await Task.Run(() => _archivoFacade.ImportArchivo(operacion));

                    this.PrgBarImport.IsIndeterminate = false;
                    this.LblMsgProgress.Content = string.Empty;
                    this.TxTRuta.Text = string.Empty;

                    WindowsUtils.MostrarMensaje("Carga exitosa",TipoMensaje.Informacion);
                }
                catch (IOException exception)
                {
                    WindowsUtils.MostrarMensaje(exception);
                }
            }
        }

        public void OpenCalendar()
        {
            var window = new CalendarPeriodo();
            _windowsUtils.OpenDialog(window);

            _fechaPeriodo = window.FechaPeriodo;

            this.lblCalendario.Content = Formater.FormateaFecha(FormatoFecha.DDMMAAAA, _fechaPeriodo);
        }

        public void OpenArchivoHelper()
        {
            var window = new SearchLibro();
            _windowsUtils.OpenDialog(window);

            _archivo = window.Archivo;

            if(window.Archivo==null)
                return;

            this.lblNombreArchivo.Content = _archivo.Nombre;
        }

        private bool ValidarImport()
        {
            if (_archivo.Id == 0)
            {
                WindowsUtils.MostrarMensaje("Debe elegir un archivo", TipoMensaje.Informacion);
                return false;
            }

            if (this.TxTRuta.Text == string.Empty)
            {
                WindowsUtils.MostrarMensaje("Debe seleccionar la ruta del archivo", TipoMensaje.Informacion);
                return false;
            }

            if (_fechaPeriodo == Common.GetDefaultDate())
            {
                WindowsUtils.MostrarMensaje("Debe seleccionar el periodo", TipoMensaje.Informacion);
                return false;
            }

            return true;
        }
    }
}