using System.Threading.Tasks;
using MigraPle.Model.Entities;

namespace MigraPle.Windows.Facade
{
    public interface IArchivoFacade
    {
        void GetArchivos();
        Task<string> ImportArchivo(Operacion operacion);
    }
}
