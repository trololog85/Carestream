using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.DataAccess.Repository.Interfaces
{
    public interface ILibroRepository
    {
        List<Libro> Listar();
        void Guardar(Libro libro);
        void Actualizar(Libro libro);
        int ObtieneLibroxCod(string codigo);
        void Eliminar(int cod);
    }
}
