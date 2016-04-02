using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.Generator.Import.Interface
{
    public interface IImportLibroRegistroCompras
    {
        List<RegistroCompra> LeeRegistro(Model.Entities.Import import);
    }
}
