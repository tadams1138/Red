using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace red.SystemInfo
{
    public class SystemInfoIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SystemInfoIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/SystemInfo", "text/html; charset=utf-8")]
        [InlineData("/SystemInfo/Data", "application/json; charset=utf-8")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url, string expected)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be(expected, "bob");
        }
    }
}