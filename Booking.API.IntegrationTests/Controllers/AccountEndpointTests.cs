using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Booking.API.IntegrationTests.Controllers
{
    public class AccountEndpointTests
    {
        private readonly HttpClient _httpClient;
        public AccountEndpointTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _httpClient = server.CreateClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }
        [Theory]
        [InlineData("POST")]
        public async Task LoginUserAsync_ShouldReturnOk(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "api/Account/Login/");
            //Act
            var response = await _httpClient.SendAsync(request);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("POST")]
        public async Task CreatUserAsync_ShouldReturnOk(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "api/Account/Create/");
            //Act
            var response = await _httpClient.SendAsync(request);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
