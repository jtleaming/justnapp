using Application.Tracks;
using Infrastructure.Interfaces;
using Moq;
using Xunit;

namespace Application.Tests
{
    public class GetTracksQueryTests
    {
        [Fact]
        public void GetLatest_ShouldReturn_TrackInfo()
        {
            var moqTracksService = new Mock<ITrackService>();
            var tracksQuery = new GetTracksQuery(moqTracksService.Object);
            var expexted = $@"
                        {{
                            ""artist"":""Solomon Burke"",
                            ""title"": ""Someone is Watching"",
                            ""uri"": ""https://open.spotify.com/embed/track/5AIi7YlHwURZe2BNcyU9nh""ls
                        }}";

            var actual = tracksQuery.GetLatest();

            Assert.Equal(expexted, actual);
        }
    }
}