using System;
using System.Collections.Generic;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Facade.Generator.Interface
{
    public interface IFLibroLog
    {
        IEnumerable<LibroLog> Listar(string tipoLog);

        Tuple<string, int> RegistrarLog(LibroLog libroLog);
        List<LibroLog> ListarLibrosDiarios();
    }
}
