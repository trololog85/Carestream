using System.Collections.Generic;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller.Interface
{
    public interface IArchivoController
    {
        IEnumerable<Archivo> GetArchivos();
    }
}