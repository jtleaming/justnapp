using System;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("Tracks")]
    public class TracksController : Controller
    {
        private readonly IGetTracksQuery tracksQuery;

        public TracksController(IGetTracksQuery tracksQuery)
        {
            this.tracksQuery = tracksQuery;
        }
        [HttpGet]
        public string GetLatestTrack()
        {
            return tracksQuery.GetLatest();
        }
    }
}