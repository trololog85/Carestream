using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.Generator.Import.Interface
{
    public interface IImportLibroDiario
    {
        List<LibroDiario> LeeRegistro(Model.Entities.Import import);
    }
}
