using System.Collections.Generic;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Interface
{
    public interface ITramaCompras
    {
        void GeneraTrama(List<RegistroCompra> registros, RutaArchivo ruta);
    }
}
