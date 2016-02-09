using System.Collections.Generic;

namespace Carestream.AdmTramas.Facade.Generator.Interface
{
    public interface IFLibro
    {
        IEnumerable<Model.Entities.Libro> Listar();
    }
}
