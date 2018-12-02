using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Network
{
    public interface IWebClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string uri);
    }
}