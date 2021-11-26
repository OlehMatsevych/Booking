using Booking.Application.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class CarService : ICarService
    {
        private readonly string _carUri = "http://localhost:23924/api/Cars/GetCars";

        public async Task<string> GetAllAsync()
        {
            var results = "";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(_carUri))
                {
                    results = await response.Content.ReadAsStringAsync();
                }
            }
            return results ;
        }
    }
}
