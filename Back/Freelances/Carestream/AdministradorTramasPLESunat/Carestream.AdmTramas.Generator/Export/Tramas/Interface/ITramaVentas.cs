using System.Collections.Generic;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Generator.Export.Tramas.Interface
{
    public interface ITramaVentas
    {
        void GeneraTrama(List<RegistroVenta> registros, RutaArchivo ruta);
    }
}
