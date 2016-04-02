using System.Threading.Tasks;
using MigraPle.Windows.Proxy.Http;

namespace MigraPle.Windows.Proxy
{
    public class ConnectionProxy : IConnectionProxy
    {
        private readonly IHttpClientGetter _httpClientGetter;

        private ConnectionProxy(IHttpClientGetter httpClientGetter)
        {
            _httpClientGetter = httpClientGetter;
        }

        public ConnectionProxy():this(new HttpClientGetter())
        {
            
        }

        public async Task<string> GetSession()
        {
            string response;

            using (var client = _httpClientGetter.GetHttpClient())
            {
                response = await client.GetStringAsync("Session");
            }

            return response;
        }
    }
}