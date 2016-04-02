using System.Windows;
using MigraPle.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using MigraPle.Api.Windows.Utils;

namespace MigraPle.Windows.Search
{
    /// <summary>
    /// Interaction logic for SearchLibro.xaml
    /// </summary>
    public partial class SearchLibro : Window
    {
        private readonly List<Archivo> _libros = Globals.Archivos.ToList();

        public Archivo Archivo { get; set; }

        public SearchLibro()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid(_libros);
        }

        private void txtNombreLibro_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(this.txtNombreLibro.Text.Trim()==string.Empty)
                LoadGrid(_libros);

            FiltrarLibros();
        }

        private void txtNombreLibro_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.txtNombreLibro.Text.Trim() == string.Empty)
                LoadGrid(_libros);

            FiltrarLibros();
        }

        private void GridLibro_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Archivo = (Archivo)GridLibro.SelectedItem;
            this.Close();
        }
    }
}
