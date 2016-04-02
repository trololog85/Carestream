using System.Threading.Tasks;

namespace Carestream.AdmTramas.Facade.Generator.Interface
{
    public interface IFCargaLibro
    {
        Task<string> GuardarImport(Model.Entities.Import import);
    }
}
