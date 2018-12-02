using System;
using System.IO;
using System.Reflection;
using System.Text;
using Infrastructure.SpotifyServices;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Infrastructure.Tests
{
    public class AuthenticationServiceTests
    {
        private readonly string refreshToken = string.Empty;
        private readonly JToken config;

        public AuthenticationServiceTests()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Infrastructure.Tests.appsettings.Development.json");
            using (var streamReader = new StreamReader(stream))
            {
                config = JToken.Parse(streamReader.ReadToEnd())["webConfig"];
            }
        }

        [Fact]
        public void CheckExpirationAsync_ShouldRetunFalse_WhenBearerTokenIsInvalid()
        {
            var isExperied = new AuthenticationService().CheckExpirationAsync("12344556").Result;

            Assert.False(isExperied);
        }

        [Fact]
        public void RefreshBearerToken_ReturnsToken_WhenCalled()
        {
            var authService = new AuthenticationService();
            var token = authService.RefreshBearerToken(config["refreshToken"].ToString(), Convert.ToBase64String(Encoding.ASCII.GetBytes($"{config["user"].ToString()}:{config["password"].ToString()}")));

            Assert.True(authService.CheckExpirationAsync(token).Result);
        }
    }
}