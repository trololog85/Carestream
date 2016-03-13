using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.Generator.Import.Interface
{
    public interface IImportLibroNoDomiciliado
    {
        List<RegistroNoDomiciliado> LeeRegistro(Model.Entities.Import import);
    }
}
