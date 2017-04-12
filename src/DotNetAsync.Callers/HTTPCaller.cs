using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DotNetAsync.Callers
{
    public class HTTPCaller
    {
        private readonly string baseUri;

        public HTTPCaller(string baseUri)
        {
            this.baseUri = baseUri;
        }


        public async Task<HttpResponseMessage> CallApiAsync(string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await client.GetAsync(uri);
            }
        }

        public async Task<string> CallApiStringAsync(string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await client.GetStringAsync(uri);
            }
        }
    }
}
