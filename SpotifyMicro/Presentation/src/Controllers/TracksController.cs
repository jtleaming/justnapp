using System;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [EnableCors("DevPolicy")]
    [Route("Tracks")]
    public class TracksController : Controller
    {
        private readonly IGetTracksQuery tracksQuery;

        public TracksController(IGetTracksQuery tracksQuery)
        {
            this.tracksQuery = tracksQuery;
        }
        [HttpGet]
        public ActionResult<string> GetLatestTrack()
        {
            try
            {
                return Ok( tracksQuery.GetLatest());
            }
            catch (System.Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}