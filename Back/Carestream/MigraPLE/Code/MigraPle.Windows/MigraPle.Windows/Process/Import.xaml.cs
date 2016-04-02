using System;
using System.Windows;
using MigraPle.Api.Configurations;
using MigraPle.Api.Windows.Utils;
using MigraPle.Api.Windows.Utils.Interfaces;
using MigraPle.Model.Entities;
using MigraPle.Windows.Facade;
using MigraPle.Windows.Search;

namespace MigraPle.Windows.Process
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Window
    {
        private readonly IConfigurationGetter _configurationGetter;
        private readonly IWindowsUtils _windowsUtils;
        private readonly IArchivoFacade _archivoFacade;
        private DateTime _fechaPeriodo;

        private Archivo _archivo;

        private Import(IConfigurationGetter configurationGetter,IWindowsUtils windowsUtils, IArchivoFacade archivoFacade)
        {
            _configurationGetter = configurationGetter;
            _windowsUtils = windowsUtils;
            _archivoFacade = archivoFacade;
            InitializeComponent();
        }

        public Import():this(new ConfigurationGetter(),new WindowsUtils(), new ArchivoFacade())
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeWindow();
        }

        private void lblNombreArchivo_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenArchivoHelper();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            this.TxTRuta.Text = _windowsUtils.SelectFile();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ImportArchivo();
        }

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            OpenCalendar();
        }
    }
}
