using System.Net;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITrackService
    {
        Task<HttpStatusCode> CheckConnectionAsync();
        Task<string> GetCurrentTrackAsync();
    }
}