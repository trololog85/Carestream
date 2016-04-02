using System.Net;
using System.Net.Http;
using System.Web.Http;
using MigraPle.Api.Controller.Interface;
using MigraPle.Model.Entities;

namespace MigraPLE_API.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        private readonly ILoginController _loginController;

        public LoginController()
        {

        }

        public LoginController(ILoginController loginController)
        {
            _loginController = loginController;
        }

        [HttpPost]
        public HttpResponseMessage Login(Login login)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            if (_loginController.AuthenticateUser(login))
            {
                response.Content = new StringContent("true");

                return response;
            }

            response.Content = new StringContent("false");

            return response;
        }

        [HttpGet]
        [Route("Session")]
        public HttpResponseMessage GetSession()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var date = _loginController.GetSession();

            response.Content = new StringContent(date.ToString());

            return response;
        }
    }
}
