using System.Collections.Generic;
using MigraPle.Api.Controller.Interface;
using MigraPle.DataAccess.Repository;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller
{
    public class ArchivoControllerLogic:IArchivoController
    {
        private readonly IArchivoRepository _archivoRepository;

        public ArchivoControllerLogic(IArchivoRepository archivoRepository)
        {
            _archivoRepository = archivoRepository;
        }

        public IEnumerable<Archivo> GetArchivos()
        {
            return _archivoRepository.GetArchivos();
        }
    }
}
