using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MigraPle.Api.Controller.Interface;
using MigraPle.Model.Entities;

namespace MigraPLE_API.Controllers
{
    [RoutePrefix("api")]
    public class OperacionController : ApiController
    {
        private readonly IOperacionController _operacionController;

        public OperacionController()
        {

        }

        public OperacionController(IOperacionController operacionController)
        {
            _operacionController = operacionController;
        }

        [HttpPost]
        [Route("Import")]
        public HttpResponseMessage Import(Operacion operacion)
        {
            var response = _operacionController.ImportArchivo(operacion);

            var httpResponse = Request.CreateResponse(HttpStatusCode.OK);

            httpResponse.Content = new StringContent(response);

            return httpResponse;
        }

        [HttpGet]
        [Route("Detalle/{id}")]
        public IEnumerable<OperacionDetalle> GetOperacionDetalles(int idOperacion)
        {
            var response = _operacionController.GetDetalles(idOperacion);

            return response;
        }
    }
}
