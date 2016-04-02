using System.IO;
using MigraPle.Api.Utilities.Interfaces;

namespace MigraPle.Api.Utilities
{
    public class FileUtilities : IFileUtilities
    {
        public string GetNombreArchivo(string ruta)
        {
            var fi = new FileInfo(ruta);

            return fi.Name;
        }
    }
}