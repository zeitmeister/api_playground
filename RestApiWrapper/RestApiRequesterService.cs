using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestApiWrapper
{
    public class RestApiRequesterService : IRestApiRequesterService
    {
        public HttpResponseMessage GetRequest(string requestUrl, string headerSceheme = "", string headerParameter = "")
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(headerSceheme) && !string.IsNullOrEmpty(headerParameter))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(headerSceheme, headerParameter);
                }

                return client.GetAsync(requestUrl).Result;
            }
        }

        public async Task<HttpResponseMessage> PostRequest(string requestUrl, object postObject, string headerScheme = "", string headerParameter = "")
        {

            using (var client = new HttpClient())
            {
                var postTask = await client.PostAsJsonAsync(requestUrl, postObject);
                return postTask;
                // var responseBody = await postTask.Content.ReadAsStringAsync();

            }


        }
    }
}
