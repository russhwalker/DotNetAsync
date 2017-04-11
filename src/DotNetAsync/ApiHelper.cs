using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAsync
{
    public class ApiHelper
    {

        private readonly string baseUri;

        public ApiHelper(string baseUri)
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
