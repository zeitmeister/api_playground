using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestApiWrapper
{
    public class RestApiRequesterService : IRestApiRequesterService
    {
        public HttpResponseMessage GetRequest(string requestUrl, string headerScheme = "", string headerParameter = "")
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(headerScheme) && !string.IsNullOrEmpty(headerParameter))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(headerScheme, headerParameter);
                }

                return client.GetAsync(requestUrl).Result;
            }
        }

        public async Task<HttpResponseMessage> PostRequest(string requestUrl, object postObject, string headerScheme = "", string headerParameter = "")
        {

            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(headerScheme) && !string.IsNullOrEmpty(headerParameter))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(headerScheme, headerParameter);
                }
                if (postObject != null)
                {
                    return await client.PostAsJsonAsync(requestUrl, postObject);
                }
                HttpContent httpContent = (HttpContent) postObject;
                return await client.PostAsync(requestUrl, httpContent);
                // var responseBody = await postTask.Content.ReadAsStringAsync();

            }


        }
    }
}
