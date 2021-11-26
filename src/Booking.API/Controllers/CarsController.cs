using Booking.Application.Services.Interfaces;
using Booking.Messaging.Receive.Receiver;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarReceiver _carReceiver;
        private readonly ICarService _carService;

        public CarsController(ICarReceiver carReceiver, ICarService carService)
        {
            _carReceiver = carReceiver;
            _carService = carService;
        }
        [HttpGet]
        [Route("GetLastCars")]
        public IEnumerable<string> Get()
        {
            return _carReceiver.ReceiveCar() ;
        }
        [HttpGet]
        [Route("GetAllCars")]
        public async Task<string> GetAllAsync()
        {
            return await _carService.GetAllAsync();
        }
    }
}
