using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Infrastructure.Network
{
    public class WebClientWrapper : IWebClientWrapper
    {
        private static HttpClient webRequest = new HttpClient();

        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            webRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
            return webRequest.GetAsync(uri);
        }
    }
}