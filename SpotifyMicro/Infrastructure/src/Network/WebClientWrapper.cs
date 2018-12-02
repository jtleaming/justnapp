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
            webRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "BQDEYNIqj5hkTNdmlHaHWoteFu-dphTJSKA7Ze9RysfCJub2iT-4hFwfXsMnokoXCi4iKg_BQ7rC3ZCk7GIeaSTh6DKPW7cOP0P9WDh7aZxPe68WiULf67R8nhVL1MfwNZS9sE-0M7yzpq9j-6IiOLqYdpj9");
            return webRequest.GetAsync(uri);
        }
    }
}