using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Facade;
using Carestream.AdmTramas.Facade.Generator.Import;
using Carestream.AdmTramas.Facade.Log;
using Carestream.AdmTramas.Facade.Mantenimientos;
using Carestream.AdmTramas.Utils;
using Carestream.AdmTramasPLE.Mantenimientos;
using Carestream.AdmTramasPLE.Procesos;
using Version = Carestream.AdmTramas.Model.Tipos.Version;


namespace Carestream.AdmTramasPLE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string result = String.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuArchivoImport_Click(object sender, RoutedEventArgs e)
        {
            var window = new Import(new FLibro(),new FLibroLog());

            window.Show();
            window.ShowActivated = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var taskDb = new Task(CallDataBase);

            var task2 = taskDb.ContinueWith((antecedent) =>
            {
                txtStatus.Text = result;
            },TaskScheduler.FromCurrentSynchronizationContext());

            taskDb.Start();
        }

        private void CallDataBase()
        {
            try
            {
                var fCodigoDetalle = new FCodigoDetalle();

                var querys = fCodigoDetalle.Listar(1);
                Globals.LstTipoDocumento = fCodigoDetalle.Listar(3).ToList();
                Globals.LstComprobante = fCodigoDetalle.Listar(2).ToList();
                Globals.LstCodigoAduana = fCodigoDetalle.Listar(4).ToList();
                Globals.LstCodigoMoneda = fCodigoDetalle.Listar(5).ToList();
                Globals.LstCodigoBienes = fCodigoDetalle.Listar(6).ToList();
                Globals.LstExoneraciones = fCodigoDetalle.Listar(7).ToList();

                var qVentas = querys.FirstOrDefault(x => x.Codigo == "QueryVentas").Descripcion;
                var qLibroDiario = querys.FirstOrDefault(x => x.Codigo == "QueryLibroDiario").Descripcion;
                var qLibroMayor = querys.FirstOrDefault(x => x.Codigo == "QueryLibroMayor").Descripcion;
                var qCompras = querys.FirstOrDefault(x => x.Codigo == "QueryCompras").Descripcion;
                var qLibroDiaroDetalle = querys.FirstOrDefault(x => x.Codigo == "DiarioDetalle").Descripcion;
                var qNoDomiciliado = querys.FirstOrDefault(x => x.Codigo == "QueryNoDomiciliado").Descripcion;

                Globals.queryVentas = qVentas;
                Globals.queryLibroDiario = qLibroDiario;
                Globals.queryLibroMayor = qLibroMayor;
                Globals.queryCompras = qCompras;
                Globals.queryDiarioDetalle = qLibroDiaroDetalle;
                Globals.queryNoDomiciliado = qNoDomiciliado;

            }
            catch (Exception ex)
            {
                Mensaje.MostrarMensaje(String.Format("Ocurrio un error: {0} Detalle: {1} {2} Trace: {3}",
                    Environment.NewLine,ex.Message,Environment.NewLine,ex.StackTrace),Mensaje.TipoMensaje.Error);

                result = "Error en la conexión.";
                return;
            }

            result = String.Format("{0} a las {1}", "Conexión exitosa", DateTime.Now);
        }

        private void ActualizarCUO_Click(object sender, RoutedEventArgs e)
        {
            var window = new UpdateCUO();

            window.Show();
            window.ShowActivated = true;
        }
    }
}
