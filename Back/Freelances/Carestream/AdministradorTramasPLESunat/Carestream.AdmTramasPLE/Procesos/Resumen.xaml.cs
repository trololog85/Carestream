using System;
using System.Collections.Generic;
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
using Carestream.AdmTramas.Facade.Errores;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramasPLE.Procesos
{
    /// <summary>
    /// Interaction logic for Resumen.xaml
    /// </summary>
    public partial class Resumen : Window
    {
        private readonly string _ruta;
        private int _idLibroLog;
        private List<ErrorLinea> _errores = new List<ErrorLinea>(); 

        public Resumen()
        {
            InitializeComponent();
        }

        public Resumen(int idLibroLog,string ruta):
            this()
        {
            _ruta = ruta;
            _idLibroLog = idLibroLog;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarFormulario();
        }

        private void CargarFormulario()
        {
            TxtArchivo.Text = _ruta;

            var fErrores = new FErrorDetalles();

            _errores = fErrores.Listar(_idLibroLog).ToList();

            var lineas = _errores.GroupBy(x => x.Linea)
                .Select(group => group.Key);

            LstLineas.ItemsSource = lineas;
        }

        private void LstLineas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var linea = Convert.ToInt32(LstLineas.SelectedValue);

            var errorFiltro = _errores.Where(x => x.Linea == linea).ToList();

            LstDetalle.ItemsSource = errorFiltro;
            //LstDetalle.
        }
    }
}
