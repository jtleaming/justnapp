using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> CheckExpirationAsync(string bearerToken);
        string RefreshBearerToken(string refreshToken, string basicAuth);
    }
}