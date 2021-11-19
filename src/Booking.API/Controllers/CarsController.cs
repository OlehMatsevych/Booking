using Booking.Messaging.Receive.Receiver;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarReceiver _carReceiver;

        public CarsController(ICarReceiver carReceiver)
        {
            _carReceiver = carReceiver;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _carReceiver.ReceiveCar() ;
        }
    }
}
