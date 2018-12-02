using System.Net.Http;
using FluentAssertions;
using Infrastructure.Interfaces;
using Infrastructure.Network;
using Moq;
using Xunit;

namespace Infrastructure.Tests
{
    public class WebClientTests
    {
        [Fact]
        public async void GetAsync_ReturnsWebResponseMessage_WhenGivenUrl()
        {
            var moqAuthenticationService = new Mock<IAuthenticationService>();
            var webClientWrapper = new WebClientWrapper(new WebConfig {RefreshToken = "123456"}, moqAuthenticationService.Object);
            var actual = await webClientWrapper.GetAsync("https://api.spotify.com/");
            actual.Should().BeOfType(typeof(HttpResponseMessage));
        }
    }
}