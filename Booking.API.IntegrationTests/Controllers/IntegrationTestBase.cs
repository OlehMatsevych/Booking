using Booking.Application.Models;
using Booking.DataAccess.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Booking.API.IntegrationTests.Controllers
{
    public class IntegrationTestBase
    {
        protected readonly HttpClient _httpClient;
        public IntegrationTestBase()
        {
            var factory = new WebApplicationFactory<Startup>()
                   .WithWebHostBuilder(builder =>
                   {
                       builder.ConfigureServices(services =>
                       {
                           services.RemoveAll(typeof(BookingContext));
                           services.AddDbContext<BookingContext>(options =>
                           {
                               options.UseInMemoryDatabase("BookingDb");
                           });
                       });
                   });

            _httpClient = factory.CreateClient();
        }
        protected async Task AuthenticateAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }
        private async Task<string> GetJwtAsync()
        {
            var response = await _httpClient.PostAsJsonAsync("api/Account/Login/", new UserModel
            {
                UserName = "Jartytqwertyu23i231223",
                Email = "JareJqwertyuio22332@test.com",
                PhoneNumber = "+311978295612",
                Password = "Jard23J23"
            });
            var registrationResponse = await response.Content.ReadAsStringAsync();
            var responseToObject = JsonConvert.DeserializeObject<JwtReponse>(registrationResponse);
            return responseToObject.Token;
        }
    }
}
