using System.Collections.Generic;

namespace MigraPle.Api.Processor.Interface
{
    public interface IFileProcessor
    {
        IEnumerable<string> ImportProcess(string ruta);
    }
}