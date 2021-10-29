using Booking.Application.Models.Apartment;
using Booking.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.API.IntegrationTests.Controllers
{
    public class ApartmentEndpointTests : IntegrationTestBase
    {
        [Fact]
        public async Task GetApartmentsTestAsync_ShouldReturnOk()
        {
            //Arrange
            await AuthenticateAsync();
            
            //Act
            var response = await _httpClient.GetAsync("/api/Apartments/ApartmentsList/");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GetApartmentsByLocationTestAsync_ShouldReturnOk()
        {
            //Arrange
            await AuthenticateAsync();
            Location location = new Location()
            {
                City = "Russia",
                Country = "Moscow"
            };
            var json = JsonConvert.SerializeObject(location);
            var data = new StringContent(json,Encoding.UTF8,"application/json");
            //Act
            var response = await _httpClient.PostAsync("/api/Apartments/", data);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task AddAppartmentTestAsync_ShouldReturnOk()
        {
            //Arrange
            await AuthenticateAsync();
            ApartmentModel model = new ApartmentModel()
            {
                Id= Guid.NewGuid(),
                Location = new Location()
                {
                    City = "Russia",
                    Country = "Moscow"
                }
            };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            //Act
            var response = await _httpClient.PostAsync("/api/Apartments/AddAppartment/", data);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task UpdateAppartmentTestAsync_ShouldReturnNotAllowed()
        {
            //Arrange
            await AuthenticateAsync();
            var testId = Guid.NewGuid();
            ApartmentModel model = new ApartmentModel()
            {
                Id = testId,
                Location = new Location()
                {
                    City = "Russia",
                    Country = "Moscow"
                }
            };
            var json = JsonConvert.SerializeObject(model);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            //Act
            var response = await _httpClient.PutAsync("http://localhost:57094/api/Apartments/", data);

            //Assert
            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }
        [Fact]
        public async Task DeleteAppartmentById_ShouldReturnNotAllowed()
        {
            //Arrange
            await AuthenticateAsync();
            var TestId = Guid.NewGuid();

            var Id = TestId.ToString();
            var json = JsonConvert.SerializeObject(Id);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await _httpClient.DeleteAsync("http://localhost:57094/api/Apartments/");

            //Assert
            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }
    }
}
