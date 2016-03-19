using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Carestream.AdmTramas.Converter;
using Carestream.AdmTramas.Facade.Generator.Interface;
using Carestream.AdmTramas.Facade.Log;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;
using Version = Carestream.AdmTramas.Model.Tipos.Version;

namespace Carestream.AdmTramasPLE.Procesos
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Window
    {
        private readonly IFLibroLog _libroLog;
        private readonly IFLibro _cargaLibro;
        private Libro libro = null;

        public Import(IFLibro cargaLibro, IFLibroLog libroLog)
        {
            _libroLog = libroLog;
            _cargaLibro = cargaLibro;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarFormulario();
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarInput()) return;

            var import = GeneraLibro();

            var version = VersionConverter.Convert(CmbVersion.SelectedValue.ToString());

            PrgBarImport.Value = 0;

            var result = await CargarArchivo(version,import);

            MostrarMensaje(result);

            CargarGrilla();
        }

        private Task<string> CargarArchivo(Version version,AdmTramas.Model.Entities.Import import)
        {
            var fLibrolog = VersionSelector.GetImport(version);

            var result = Task.Run(()=>fLibrolog.GuardarImport(import));

            return result;
        }

        private AdmTramas.Model.Entities.Import GeneraLibro()
        {
            var item = (Libro)CmbArchivo.SelectedItem;
            string mes = this.CmbMes.SelectedValue.ToString();
            string text = this.TxtAnio.Text;

            var import = new AdmTramas.Model.Entities.Import
            {
                IdLibro = item.Id,
                Moneda = CmbMoneda.SelectedValue.ToString(),
                Operacion = CmbIndicadorOpe.SelectedValue.ToString(),
                Registro = CmbContenidoLib.SelectedValue.ToString(),
                Ruc = TxtNroRuc.Text,
                Ruta = TxTRuta.Text,
                Tipo = Formato.EligeTipoLibro(item.Id),
                ProgressBar = PrgBarImport,
                LblMessage = LblMsgProgress,
                Periodo = Formato.GeneraFecha(text, mes)
            };

            return import;
        }

        private void MostrarMensaje(string result)
        {
            if (result != "")
            {
                Mensaje.MostrarMensaje(result, Mensaje.TipoMensaje.Error);
                ResetControls();
            }
            else
            {
                Mensaje.MostrarMensaje("Proceso satisfactorio", Mensaje.TipoMensaje.Informacion);
            }
        }

        private void ResetControls()
        {
            PrgBarImport.Value = 0;
            LblMsgProgress.Content = String.Empty;
        }

        private bool ValidarInput()
        {
            if (TxTRuta.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe colocar la ruta del archivo.", Mensaje.TipoMensaje.Informacion);
                return false;
            }
            
            libro = (Libro) CmbArchivo.SelectedItem;

            if (libro.Id == 0)
            {
                Mensaje.MostrarMensaje("Debe elegir el archivo a cargar.", Mensaje.TipoMensaje.Informacion);
                return false;
            }

            if (TxtNroRuc.Text.Trim() == String.Empty)
            {
                Mensaje.MostrarMensaje("Debe ingresar el Número de RUC.", Mensaje.TipoMensaje.Informacion);
                return false;
            }
            
            return true;
        }

        private void CargarFormulario()
        {
            TxtNroRuc.Text = "20515033841";

            //Archivos
            CmbArchivo.ItemsSource = _cargaLibro.Listar();
            CmbArchivo.SelectedIndex = 0;

            //Moneda
            CmbMoneda.ItemsSource = Combo.ListaIndicadordeMoneda();
            CmbMoneda.SelectedValue = "PEN";

            //Operaciones
            CmbIndicadorOpe.ItemsSource = Combo.ListaIndicadorOperaciones();
            CmbIndicadorOpe.SelectedValue = '1';

            //Registro
            CmbContenidoLib.ItemsSource = Combo.ListaIndicadorLibroRegistro();
            CmbContenidoLib.SelectedValue = '1';

            //Version
            CmbVersion.ItemsSource = Combo.VersionPLE();
            CmbVersion.SelectedValue = "4.0";

            this.CmbMes.ItemsSource = Combo.ListaMeses();

            DateTime dateTime = DateTime.Now.AddMonths(-1);
            this.TxtAnio.Text = dateTime.Year.ToString(CultureInfo.InvariantCulture);
            this.CmbMes.SelectedValue = dateTime.Month.ToString(CultureInfo.InvariantCulture);

            //LibroLog
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            GridLibroLog.ItemsSource = _libroLog.Listar("I");
        }

        private void GridLibroLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var libroLog = (LibroLog) GridLibroLog.SelectedItem;

            if (libroLog == null)
                return;

            TxtNroRuc.Text = libroLog.RUC.ToString(CultureInfo.InvariantCulture);
            CmbIndicadorOpe.SelectedValue = libroLog.IndicadorOperacion;
            CmbMoneda.SelectedValue = libroLog.IndicadorMoneda;
            CmbContenidoLib.SelectedValue = libroLog.IndicadorLibro;
            CmbArchivo.SelectedValue = libroLog.IdLibro;
        }

        private void GridLibroLog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var libroLog = (LibroLog) GridLibroLog.SelectedItem;

            if (libroLog == null)
                return;

            CmbArchivo.SelectedValue = libroLog.IdLibro;

            var item = (Libro)CmbArchivo.SelectedItem;

            var export = new AdmTramas.Model.Entities.Export
            {
                 IdLibroLog = libroLog.Id,
                 IndicadorLibro = libroLog.IndicadorLibro,
                 IdMoneda = libroLog.IndicadorMoneda,
                 IdOperacion = libroLog.IndicadorOperacion,
                 NumeroRuc = libroLog.RUC,
                 RutaArchivoImport = TxTRuta.Text,
                 TipoLibro = Formato.EligeTipoLibro(libroLog.IdLibro),
                 CodigoLibro = item.Codigo,
                 IdLibro = item.Id
            };

            var window = new Export(export,new FLibroLog());

            window.Show();
            window.ShowActivated = true;
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            TxTRuta.Text = Archivo.SeleccionarArchivo();
        }
    }
}
