using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Facade.Generator.Export;
using Carestream.AdmTramas.Facade.Generator.Interface;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Model.Tipos;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramasPLE.Procesos
{
    /// <summary>
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : Window
    {
        private readonly AdmTramas.Model.Entities.Export _export;
        private readonly IFLibroLog _libroLog;

        public Export(IFLibroLog libroLog)
        {
            _libroLog = libroLog;
            InitializeComponent();
        }

        public Export(AdmTramas.Model.Entities.Export export, IFLibroLog libroLog)
            : this(libroLog)
        {
            _export = export;
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            TxtRutaExport.Text = Archivo.SeleccionarRuta();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarFormulario();
        }

        private void CargarFormulario()
        {
            //Cargar ComboMeses
            CmbMes.ItemsSource = Combo.ListaMeses();

            var fecha = DateTime.Now.AddMonths(-1);

            TxtAnio.Text = fecha.Year.ToString(CultureInfo.InvariantCulture);
            CmbMes.SelectedValue = fecha.Month.ToString(CultureInfo.InvariantCulture);

            //Cargar Versiones
            CmbVersion.ItemsSource = Combo.VersionPLE();
            CmbVersion.SelectedValue = "4.0";

            CargarDatosExport();
            CargarGrilla();
        }

        private void CargarDatosExport()
        {
            TxtrutaOrigen.Text = _export.RutaArchivoImport;
            var tipoLibro = _export.TipoLibro;
            chkSubLibro.IsEnabled = (tipoLibro == TipoLibro.LibroDiario);
        }

        private async void BtnGenerar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarInput()) return;
            
            ObtieneExport();

            await GenerarArchivo();

            var path = TxtRutaExport.Text;

            Archivo.OpenPath(path);

            CargarGrilla();
        }

        private bool ValidarInput()
        {
            if (TxtRutaExport.Text == string.Empty)
            {
                Mensaje.MostrarMensaje("Debe colocar la ruta del archivo.", Mensaje.TipoMensaje.Informacion);
                return false;
            }

            return true;
        }

        private void ObtieneExport()
        {
            _export.Anio = Int32.Parse(TxtAnio.Text);
            _export.RutaArchivoExport = TxtRutaExport.Text;
            _export.Mes = Convert.ToInt32(CmbMes.SelectedValue);
            _export.ProgressBar = PrgProgreso;
            _export.LblMessage = LblProgreso;

            Globals.PeriodoInformado = new DateTime(_export.Anio, _export.Mes, 1);
        }

        private async Task<ExportResult> GenerarArchivo()
        {
            var generador = new FGeneraLibro();

            var generadorTask = new Task<ExportResult>(() => generador.ExportaArchivo(_export).Result);

            generadorTask.Start();

            await generadorTask;

            //var result = Task.Run(()=>generador.ExportaArchivo(_export));

            return generadorTask.Result;
        }

        private void CargarGrilla()
        {
            GridLibroLog.ItemsSource = _libroLog.Listar("E");
        }

        private void GridLibroLog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var libroLog = (LibroLog)GridLibroLog.SelectedItem;

            if (libroLog == null)
                return;

            var ruta = libroLog.NombreLibro;

            var window = new Resumen(libroLog.Id, ruta);

            window.Show();
            window.ShowActivated = true;
        }
    }
}
