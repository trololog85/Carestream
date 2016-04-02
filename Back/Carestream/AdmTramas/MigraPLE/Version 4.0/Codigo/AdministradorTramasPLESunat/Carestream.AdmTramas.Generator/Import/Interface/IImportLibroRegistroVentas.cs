using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.Generator.Import.Interface
{
    public interface IImportLibroRegistroVentas
    {
        List<RegistroVenta> LeeRegistro(Model.Entities.Import import);
    }
}
