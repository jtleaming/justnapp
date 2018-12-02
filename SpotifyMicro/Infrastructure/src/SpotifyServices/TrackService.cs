using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Network;

namespace Infrastructure.SpotifyServices
{
    public class TrackService : ITrackService
    {
        private readonly IWebClientWrapper webClientWrapper;

        public TrackService(IWebClientWrapper webClientWrapper)
        {
            this.webClientWrapper = webClientWrapper;
        }

        public async Task<HttpStatusCode> CheckConnectionAsync()
        {
            var results = await webClientWrapper.GetAsync("https://api.spotify.com/");
            return results.StatusCode;
        }

        public async Task<string> GetCurrentTrackAsync()
        {
            var response = await webClientWrapper.GetAsync("https://api.spotify.com/v1/me/player/currently-playing");
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}