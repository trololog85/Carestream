using System.Collections.Generic;
using Carestream.AdmTramas.Model.Entities;
using Carestream.AdmTramas.Model.Tipos;

namespace Carestream.AdmTramas.Facade.Generator.Interface
{
    public interface IFLibroLog
    {
        IEnumerable<LibroLog> Listar(string tipoLog);

        Result2 RegistrarLog(LibroLog libroLog);
    }
}
