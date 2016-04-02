using System.Net.Http;

namespace MigraPle.Windows.Proxy.Http
{
    public interface IHttpClientGetter
    {
        HttpClient GetHttpClient();
    }
}
