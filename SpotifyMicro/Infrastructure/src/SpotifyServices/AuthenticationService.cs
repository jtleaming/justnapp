using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Network;
using Newtonsoft.Json.Linq;

namespace Infrastructure.SpotifyServices
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> CheckExpirationAsync(string bearerToken)
        {
            WebClientWrapper.webRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            var results = await WebClientWrapper.webRequest.GetAsync("https://api.spotify.com/v1/me");
            return results.StatusCode == HttpStatusCode.OK;
        }

        public string RefreshBearerToken(string refreshToken, string basicAuth)
        {
            var bodyContent = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string> ("grant_type", "refresh_token"),
                    new KeyValuePair<string, string> ("refresh_token", refreshToken)
                }
            );

            WebClientWrapper.webRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuth);

            var results = WebClientWrapper.webRequest.PostAsync("https://accounts.spotify.com/api/token", bodyContent).Result;

            var content = results.Content.ReadAsStringAsync().Result;

            return JToken.Parse(content)["access_token"].ToString();
        }
    }
}