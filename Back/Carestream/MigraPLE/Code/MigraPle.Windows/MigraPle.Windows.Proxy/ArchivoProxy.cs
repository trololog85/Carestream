using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MigraPle.Model.Entities;
using MigraPle.Windows.Proxy.Http;
using Newtonsoft.Json;

namespace MigraPle.Windows.Proxy
{
    public class ArchivoProxy : IArchivoProxy
    {
        private readonly IHttpClientGetter _httpClientGetter;

        private ArchivoProxy(IHttpClientGetter httpClientGetter)
        {
            _httpClientGetter = httpClientGetter;
        }

        public ArchivoProxy():this(new HttpClientGetter())
        {
            
        }

        public async Task<IEnumerable<Archivo>> GetArchivos()
        {
            string response;

            using (var client = _httpClientGetter.GetHttpClient())
            {
                response = await client.GetStringAsync("Archivo");
            }

            var list = JsonConvert.DeserializeObject<List<Archivo>>(response);

            return list;
        }

        public async Task<string> ImportArchivo(Operacion operacion)
        {
            HttpResponseMessage response;

            using (var client = _httpClientGetter.GetHttpClient())
            {
                response = await client.PostAsJsonAsync("Import", operacion);
            }

            return response.Content.ToString();
        }
    }
}