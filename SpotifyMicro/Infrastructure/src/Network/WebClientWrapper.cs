using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Infrastructure.Network
{
    public class WebClientWrapper : IWebClientWrapper
    {
        internal static HttpClient webRequest = new HttpClient();
        private string refreshToken = string.Empty;
        private readonly string basicAuth;
        private string bearerToken = null;
        private IAuthenticationService authenticationService;

        private string BearerToken
        { 
            get
            {
                if (bearerToken == null || !authenticationService.CheckExpirationAsync(bearerToken).Result)
                {
                    bearerToken = authenticationService.RefreshBearerToken(refreshToken, basicAuth);
                    return bearerToken;
                }
                return bearerToken;
            }
        }

        public WebClientWrapper(WebConfig config, IAuthenticationService authenticationService)
        {
            refreshToken = config.RefreshToken;
            basicAuth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{config.User}:{config.Password}"));
            this.authenticationService = authenticationService;
        }

        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            webRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.BearerToken);
            return webRequest.GetAsync(uri);
        }
    }
}