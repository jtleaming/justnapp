using System;
using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Application.Tracks
{
    public class GetTracksQuery : IGetTracksQuery
    {
        private readonly ITrackService trackService;
        private readonly ITrackInfo trackInfo;

        public GetTracksQuery(ITrackService trackService, ITrackInfo trackInfo)
        {
            this.trackService = trackService;
            this.trackInfo = trackInfo;
        }

        public string GetLatest()
        {
            var result = trackService.GetCurrentTrackAsync().Result;
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(trackInfo.GetTrackInfo(result), Formatting.Indented, settings);
        }
    }
}