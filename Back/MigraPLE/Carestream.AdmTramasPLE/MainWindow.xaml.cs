using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Carestream.AdmTramas.Common;
using Carestream.AdmTramas.Facade;
using Carestream.AdmTramas.Facade.Log;
using Carestream.AdmTramas.Facade.Mantenimientos;
using Carestream.AdmTramas.Utils;
using Carestream.AdmTramasPLE.Procesos;


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

                var qVentas = querys.FirstOrDefault(x => x.Codigo == "QueryVentas").Descripcion;
                var qLibroDiario = querys.FirstOrDefault(x => x.Codigo == "QueryLibroDiario").Descripcion;
                var qLibroMayor = querys.FirstOrDefault(x => x.Codigo == "QueryLibroMayor").Descripcion;
                var qCompras = querys.FirstOrDefault(x => x.Codigo == "QueryCompras").Descripcion;
                var qLibroDiaroDetalle = querys.FirstOrDefault(x => x.Codigo == "DiarioDetalle").Descripcion;

                Globals.queryVentas = qVentas;
                Globals.queryLibroDiario = qLibroDiario;
                Globals.queryLibroMayor = qLibroMayor;
                Globals.queryCompras = qCompras;
                Globals.queryDiarioDetalle = qLibroDiaroDetalle;

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
    }
}
