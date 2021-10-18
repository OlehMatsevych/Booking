using Booking.Application.Services.Apartment;
using Booking.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        //Service
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public IActionResult GetApartments()
        {
            var apartments =  _apartmentService.GetApartments();
            return Ok(apartments);
        }

        [HttpGet("{Location}")]
        public async Task<IActionResult> GetApartmentsByLocation(Location location)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddAppartment(string TOADD)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppartment(string id, string TOUPDATE)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppartmentById(string id)
        {
            return Ok();
        }
    }
}
