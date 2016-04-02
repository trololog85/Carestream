using System;
using System.Threading.Tasks;
using Carestream.AdmTramas.Model.Entities;

namespace Carestream.AdmTramas.Facade.Generator.Interface
{
    public interface IFGeneraLibro
    {
        Task<ExportResult> ExportaArchivo(Model.Entities.Export export);
    }
}
