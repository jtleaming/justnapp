using System.IO;
using System.Reflection;
using Domain;
using FluentAssertions;
using Xunit;

namespace Domains.Tests
{
    public class TrackInfoTests
    {
        private readonly string testFixture;

        public TrackInfoTests()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Domain.Tests.currentPlayingReturn.json");
            using (var streamReader = new StreamReader(stream))
            {
                testFixture = streamReader.ReadToEnd();
            }
        }

        [Fact]
        public void GetTrackInfo_SetsTrackInfoProperties_WhenGivenSpotifyTrackJson()
        {
            var expexted = new TrackInfo
            {
                Artist = "Solomon Burke",
                Title = "Cry to Me",
                Uri = "https://open.spotify.com/embed/track/2sCf9tz6LHByczuVT7rqIx"
            };

            var actual = new TrackInfo().GetTrackInfo(testFixture);

            actual.Should().BeEquivalentTo(expexted);
        }
    }
}