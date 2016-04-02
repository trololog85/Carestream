using System.Collections.Generic;
using MigraPle.Api.Controller.Interface;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller.Mock
{
    public class ArchivoControllerMock:IArchivoController
    {
        public IEnumerable<Archivo> GetArchivos()
        {
            return new List<Archivo>
            {
                new Archivo
                {
                    Id = 1,
                    Nombre = "Libro Compras"
                },
                new Archivo
                {
                    Id = 2,
                    Nombre = "Libro Ventas"
                }
            };
        }
    }
}