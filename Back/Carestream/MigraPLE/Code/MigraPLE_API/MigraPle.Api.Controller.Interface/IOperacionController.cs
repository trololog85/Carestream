using System.Collections.Generic;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller.Interface
{
    public interface IOperacionController
    {
        string ImportArchivo(Operacion operacion);
        string ExportArchivo(Operacion operacion);
        IEnumerable<OperacionDetalle> GetDetalles(int idOperacion);
        IEnumerable<Operacion> GetOperaciones(int idArchivo);
    }
}