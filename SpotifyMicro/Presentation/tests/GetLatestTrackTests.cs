using Application.Interfaces;
using Moq;
using Presentation.Controllers;
using Xunit;

namespace Presentation.Tests
{
    public class GetLatestTrackTests
    {
        [Fact]
        public void GetLatestTrack_ShouldReturnLatestTrack_WhenCalled()
        {
            var getTracksQueryMoq = new Mock<IGetTracksQuery>();
            var tracksController = new TracksController(getTracksQueryMoq.Object);
            var expected = $@"
                        {{
                            ""artist"":""Solomon Burke"",
                            ""title"": ""Someone is Watching"",
                            ""uri"": ""https://open.spotify.com/embed/track/5AIi7YlHwURZe2BNcyU9nh""ls
                        }}";
            getTracksQueryMoq.Setup(t => t.GetLatest()).Returns(expected);

            var actual = tracksController.GetLatestTrack();

            Assert.Equal(expected, actual);

        }
    }
}