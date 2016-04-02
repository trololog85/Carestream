using System.Collections.Generic;
using Carestream.AdmTramas.Facade.Generator.Interface;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Mocks
{
    public class DataLibro : IFLibro
    {
        public IEnumerable<Libro> Listar()
        {
            var libro = new Libro
            {
                Id = 0,
                Codigo = "0",
                Nombre = "MockData"
            };

            return new List<Libro>() {libro};
        }
    }
}
