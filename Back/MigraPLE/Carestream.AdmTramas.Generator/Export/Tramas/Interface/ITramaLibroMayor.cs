using System.Collections.Generic;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Interface
{
    public interface ITramaLibroMayor
    {
        void GeneraTrama(List<LibroMayor> registros, RutaArchivo ruta);
    }
}
