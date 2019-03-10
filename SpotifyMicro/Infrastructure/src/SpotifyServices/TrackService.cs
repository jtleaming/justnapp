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
        private const string spotifyUrl = "https://api.spotify.com/";
        private const string currentPlayingUri = "v1/me/player/currently-playing";

        public TrackService(IWebClientWrapper webClientWrapper)
        {
            this.webClientWrapper = webClientWrapper;
        }

        public async Task<HttpStatusCode> CheckConnectionAsync()
        {
            var results = await webClientWrapper.GetAsync(spotifyUrl);
            return results.StatusCode;
        }

        public async Task<string> GetCurrentTrackAsync()
        {
            var response = await webClientWrapper.GetAsync($"{spotifyUrl}{currentPlayingUri}");
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}