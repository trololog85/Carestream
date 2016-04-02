using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MigraPle.Model.Entities;
using MigraPle.Windows.Proxy.Http;

namespace MigraPle.Windows.Proxy
{
    public class LoginProxy : ILoginProxy
    {
        private readonly IHttpClientGetter _httpClientGetter;

        private LoginProxy(IHttpClientGetter httpClientGetter)
        {
            _httpClientGetter = httpClientGetter;
        }

        public LoginProxy():this(new HttpClientGetter())
        {
            
        }

        public async Task<bool> AuthenticateUser(Login login)
        {
            HttpResponseMessage response;

            using (var client = _httpClientGetter.GetHttpClient())
            {
                response =  await client.PostAsJsonAsync("api/Login",login);
            }

            return response.StatusCode==HttpStatusCode.OK;
        }
    }
}