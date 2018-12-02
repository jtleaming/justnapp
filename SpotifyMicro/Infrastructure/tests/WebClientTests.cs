using System.Net.Http;
using FluentAssertions;
using Infrastructure.Network;
using Xunit;

namespace Infrastructure.Tests
{
    public class WebClientTests
    {
        [Fact]
        public async void GetAsync_ReturnsWebResponseMessage_WhenGivenUrl()
        {
            var webClientWrapper = new WebClientWrapper();
            var actual = await webClientWrapper.GetAsync("https://api.spotify.com/");
            actual.Should().BeOfType(typeof(HttpResponseMessage));
        }
    }
}