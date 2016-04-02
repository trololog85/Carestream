using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
using Carestream.AdmTramas.Facade.Generator.Interface;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramasPLE.Procesos
{
    /// <summary>
    /// Interaction logic for ProcesarDiario.xaml
    /// </summary>
    public partial class ProcesarDiario : Window
    {
        private readonly IFLibroLog _libroLog;

        public ProcesarDiario(IFLibroLog libroLog)
        {
            _libroLog = libroLog;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarFormulario();
        }

        private void CargarFormulario()
        {
            this.GridLibroLog.ItemsSource = _libroLog.ListarLibrosDiarios();
        }

        private void GridLibroLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var libroLog = (LibroLog)GridLibroLog.SelectedItem;

            if (libroLog == null)
                return;

            var fechaPeriodo = Formato.ObtieneFecha(libroLog.sFechaCarga, "DD/MM/AAAA");
            TxtMes.Text = fechaPeriodo.Month.ToString();
            TxtAnio.Text = fechaPeriodo.Year.ToString();
        }
    }
}
