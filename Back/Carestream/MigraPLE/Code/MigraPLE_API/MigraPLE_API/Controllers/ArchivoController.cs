using System.Collections.Generic;
using System.Web.Http;
using MigraPle.Api.Controller.Interface;
using MigraPle.Model.Entities;

namespace MigraPLE_API.Controllers
{
    [RoutePrefix("api")]
    public class ArchivoController : ApiController
    {
        private readonly IArchivoController _archivoController;

        public ArchivoController()
        {
            
        }

        public ArchivoController(IArchivoController archivoController)
        {
            _archivoController = archivoController;
        }

        [HttpGet]
        [Route("Archivo")]
        public IEnumerable<Archivo> Get()
        {
            return _archivoController.GetArchivos();
        }
    }
}
