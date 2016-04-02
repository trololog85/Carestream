using System;
using System.Collections.Generic;
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
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramasPLE.Mantenimientos
{
    /// <summary>
    /// Interaction logic for Libros.xaml
    /// </summary>
    public partial class Libros : Window
    {
        private List<Libro> libros = new List<Libro>();



        public Libros()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var libro = new Libro
            {
                Codigo = "000",
                Id = 1,
                Nombre = "prueba"
            };

            libros.Add(libro);

            GridLibros.ItemsSource = libros;
        }

        
    }
}
