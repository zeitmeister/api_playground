using System.Net.Http;
using System.Threading.Tasks;

namespace RestApiWrapper
{
    public interface IRestApiRequesterService
    {
        HttpResponseMessage GetRequest(string requestUrl, string headerSceheme = "", string headerParameter = "");
        Task<HttpResponseMessage> PostRequest(string requestUrl, object postObject, string headerScheme = "", string headerParameter = "");
    }
}