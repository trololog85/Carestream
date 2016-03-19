using System;
using System.Collections;
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
using Carestream.AdmTramas.Facade.Log;
using Carestream.AdmTramas.Facade.RegistroVentas;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Utils;

namespace Carestream.AdmTramasPLE.Procesos
{
    /// <summary>
    /// Interaction logic for UpdateCUO.xaml
    /// </summary>
    public partial class UpdateCUO : Window
    {
        private List<RegistroVenta> result;

        public UpdateCUO()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.CargarFormulario();
            BuscarCUOCompras();
        }

        private void CargarFormulario()
        {
            this.CmbMes.ItemsSource = (IEnumerable)Combo.ListaMeses();
            DateTime dateTime = DateTime.Now.AddMonths(-1);
            this.TxtAnio.Text = dateTime.Year.ToString((IFormatProvider)CultureInfo.InvariantCulture);
            this.CmbMes.SelectedValue = (object)dateTime.Month.ToString((IFormatProvider)CultureInfo.InvariantCulture);
        }
        private void GuardarRegistro(object sender, RoutedEventArgs e)
        {
            RegistroVenta registro = (RegistroVenta)this.GridCuoVentas.SelectedCells[this.GridCuoVentas.SelectedIndex].Item;
            if (!this.ValidarIngreso(registro.NumeroCorrelativo))
                return;
            registro.NumeroCorrelativo = this.FormateaCorrelativo(registro.NumeroCorrelativo);
            this.GuardarCorrelativo(registro);
            this.BuscarCUOCompras();
        }

        private void BuscarCUOCompras()
        {
            this.result = new FLibroLog().ListarRegistroVentasCUOFaltante(this.ObtienePeriodo());
            this.GridCuoVentas.ItemsSource = (IEnumerable)this.result;
        }

        private DateTime ObtienePeriodo()
        {
            int year = int.Parse(this.TxtAnio.Text);
            int month = Convert.ToInt32(this.CmbMes.SelectedValue);
            return new DateTime(year, month, 1);
        }

        private bool ValidarIngreso(string NumeroCorrelativo)
        {
            if (NumeroCorrelativo == null)
            {
                Mensaje.MostrarMensaje("Debe colocar el correlativo", Mensaje.TipoMensaje.Informacion);
                return false;
            }

            int result = 0;

            if (int.TryParse(NumeroCorrelativo, out result))
                return true;

            Mensaje.MostrarMensaje("El valor ingresado no es correcto.", Mensaje.TipoMensaje.Informacion);
            return false;
        }

        private string FormateaCorrelativo(string correlativo)
        {
            char prefijo = this.GetPrefijo();
            string arg = Formato.GeneraCorrelativoSinPrefijo(short.Parse(correlativo));
            return prefijo + arg;
        }

        private char GetPrefijo()
        {
            if (Convert.ToBoolean((object)this.rbApertura.IsChecked))
                return 'A';
            if (Convert.ToBoolean((object)this.rbMensual.IsChecked))
                return 'M';
            return Convert.ToBoolean((object)this.rbCierre.IsChecked) ? 'C' : 'C';
        }

        private void GuardarCorrelativo(RegistroVenta registro)
        {
            FRegistroVenta fregistroVenta = new FRegistroVenta();
            string numeroCorrelativo = registro.NumeroCorrelativo;
            string numero = registro.Numero;
            int idLibroLog = Convert.ToInt32(registro.IdLibroLog);
            fregistroVenta.ActualizarCorrelativoVentas(numero, numeroCorrelativo, idLibroLog);
        }

        private void TxtCUO_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Textbox.ValidaEnter(e.Key))
                return;
            e.Handled = true;
            if (this.TxtCUO.Text != string.Empty)
                this.FiltrarResultado(this.TxtCUO.Text);
            else
                this.BuscarCUOCompras();
        }

        private void FiltrarResultado(string text)
        {
            if (this.result == null || !Enumerable.Any<RegistroVenta>((IEnumerable<RegistroVenta>)this.result))
                return;
            this.GridCuoVentas.ItemsSource = (IEnumerable)Enumerable.ToList<RegistroVenta>(Enumerable.Where<RegistroVenta>((IEnumerable<RegistroVenta>)this.result, (Func<RegistroVenta, bool>)(registro => registro.CodigoUnicoOperacion == text)));
        }

        private void TxtCUO_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !Textbox.ValidaNumerico(e.Key);
        }

        private void TxtAnio_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !Textbox.ValidaNumerico(e.Key);
        }
    }
}
