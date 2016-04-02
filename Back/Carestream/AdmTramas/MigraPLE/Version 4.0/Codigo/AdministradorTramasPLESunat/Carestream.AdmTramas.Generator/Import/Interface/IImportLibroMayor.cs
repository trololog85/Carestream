using System.Collections.Generic;
using Carestream.AdmTramas.DataAccess.Model;

namespace Carestream.AdmTramas.Generator.Import.Interface
{
    public interface IImportLibroMayor
    {
        List<LibroMayor> LeeRegistro(Model.Entities.Import import);
    }
}
