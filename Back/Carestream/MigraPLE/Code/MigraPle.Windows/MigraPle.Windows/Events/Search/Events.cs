using System.Collections.Generic;
using System.Linq;
using MigraPle.Model.Entities;

namespace MigraPle.Windows.Search
{
    public partial class SearchLibro
    {
        public void LoadGrid(List<Archivo> archivos)
        {
            this.GridLibro.ItemsSource = archivos;
        }

        public void FiltrarLibros()
        {
            var searchString = this.txtNombreLibro.Text.ToLower();

            var libros = _libros.Where(l => l.Nombre.ToLower().Contains(searchString)).ToList();

            LoadGrid(libros);
        }
    }
}
