using System.Threading.Tasks;
using MigraPle.Api.Windows.Utils;
using MigraPle.Model.Entities;
using MigraPle.Windows.Proxy;

namespace MigraPle.Windows.Facade
{
    public class ArchivoFacade : IArchivoFacade
    {
        private readonly IArchivoProxy _archivoProxy;

        private ArchivoFacade(IArchivoProxy archivoProxy)
        {
            _archivoProxy = archivoProxy;
        }

        public ArchivoFacade():this(new ArchivoProxy())
        {
            
        }

        public async void GetArchivos()
        {
            var response = await _archivoProxy.GetArchivos();

            Globals.Archivos = response;
        }

        public async Task<string> ImportArchivo(Operacion operacion)
        {
            var response = await _archivoProxy.ImportArchivo(operacion);

            return response;
        }
    }
}