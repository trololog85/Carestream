using System;
using System.Net.Http;
using System.Net.Http.Headers;
using MigraPle.Api.Configurations;

namespace MigraPle.Windows.Proxy.Http
{
    public class HttpClientGetter : IHttpClientGetter
    {
        private readonly IConfigurationGetter _configurationGetter;

        private HttpClientGetter(IConfigurationGetter configurationGetter)
        {
            _configurationGetter = configurationGetter;
        }

        public HttpClientGetter():this(new ConfigurationGetter())
        {
            
        }

        public HttpClient GetHttpClient()
        {
            var client = new HttpClient();

            var timeOut = int.Parse(_configurationGetter.GetConfiguration("apiTimeout"));

            client.BaseAddress = new Uri(_configurationGetter.GetConfiguration("migraPleAPI"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0,0 ,timeOut);

            return client;
        }
    }
}