using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Infrastructure.Network;
using Infrastructure.SpotifyServices;
using Moq;
using Xunit;

namespace Infrastructure.Tests
{
    public class TrackServiceTests
    {
        private string testFixture;

        public TrackServiceTests()
        {

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Infrastructure.Tests.TestFixtures.currentPlayingReturn.json");
            using (var streamReader = new StreamReader(stream))
            {
                testFixture = streamReader.ReadToEnd();
            }
        }

        [Fact]
        public async void CheckConnection_Returns200OK_FromSpotifyAsync()
        {
            var moqWebClientWrapper = new Mock<IWebClientWrapper>();
            var trackService = new TrackService(moqWebClientWrapper.Object);
            moqWebClientWrapper.Setup(wc => wc.GetAsync(It.IsAny<string>()))
                            .ReturnsAsync(new HttpResponseMessage
                            {
                                StatusCode = HttpStatusCode.OK
                            });
            Assert.Equal(HttpStatusCode.OK, await trackService.CheckConnectionAsync());
        }
        [Fact]
        public async void GetCurrentTrack_ShouldReturnJsonOfTrackInfo_WhenCalled()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var moqWebClientWrapper = new Mock<IWebClientWrapper>();
            var trackService = new TrackService(moqWebClientWrapper.Object);
            moqWebClientWrapper.Setup(wc => wc.GetAsync(It.IsAny<string>()))
                            .ReturnsAsync(new HttpResponseMessage
                            {
                                Content = new StringContent(testFixture)
                            });
            Assert.Equal(testFixture, await trackService.GetCurrentTrackAsync());
        }


    }
}