using System.Collections.Generic;
using System.Threading.Tasks;
using MigraPle.Model.Entities;

namespace MigraPle.Windows.Proxy
{
    public interface IArchivoProxy
    {
        Task<IEnumerable<Archivo>> GetArchivos();
        Task<string> ImportArchivo(Operacion operacion);
    }
}