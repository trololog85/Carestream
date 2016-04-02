using System.Collections.Generic;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Interface
{
    public interface ITramaLibroDiario
    {
        void GeneraTrama(List<LibroDiario> registros, RutaArchivo ruta);
    }
}
