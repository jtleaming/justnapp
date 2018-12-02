using System;
using Application.Interfaces;
using Infrastructure.Interfaces;

namespace Application.Tracks
{
    public class GetTracksQuery : IGetTracksQuery
    {
        private readonly ITrackService trackService;

        public GetTracksQuery(ITrackService trackService)
        {
            this.trackService = trackService;
        }

        public string GetLatest()
        {
            return trackService.GetCurrentTrackAsync().Result;
        }
    }
}