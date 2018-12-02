using System.IO;
using System.Reflection;
using Application.Tracks;
using Domain;
using Infrastructure.Interfaces;
using Moq;
using Xunit;

namespace Application.Tests
{
    public class GetTracksQueryTests
    {

        public GetTracksQueryTests()
        {
        }

        [Fact]
        public void GetLatest_ShouldReturn_TrackInfo()
        {
            var moqTracksService = new Mock<ITrackService>();
            var moqTrackInfo = new Mock<ITrackInfo>();
            var tracksQuery = new GetTracksQuery(moqTracksService.Object, moqTrackInfo.Object);
            var expexted = $@"{{
  ""artist"": ""Solomon Burke"",
  ""title"": ""Someone is Watching"",
  ""uri"": ""https://open.spotify.com/embed/track/5AIi7YlHwURZe2BNcyU9nh""
}}";

            moqTracksService.Setup(ts => ts.GetCurrentTrackAsync())
                            .ReturnsAsync(@"{{""response"": ""json""}}");
            moqTrackInfo.Setup(ti => ti.GetTrackInfo(It.IsAny<string>()))
                        .Returns(
                            new TrackInfo
                            {
                                Artist = "Solomon Burke",
                                Title = "Someone is Watching",
                                Uri = "https://open.spotify.com/embed/track/5AIi7YlHwURZe2BNcyU9nh"
                            }
                        );

            var actual = tracksQuery.GetLatest();

            Assert.Equal(expexted, actual);
        }
    }
}