using Booking.Application.Helpers;
using Booking.Application.Models.Apartment;
using Booking.Application.Services.Apartment;
using Booking.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Route("api/Apartments")]
    [ApiController]
    [Authorize]
    public class ApartmentController : ControllerBase
    {
        //Service
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        [Route("ApartmentsList")]
        public IActionResult GetApartments()
        {
            var apartments =  _apartmentService.GetApartments();
            return Ok(apartments);
        }

        [HttpPost("{Location}")]
        public IActionResult GetApartmentsByLocation(Location location)
        {
            var apartments = _apartmentService.GetApartmentsByLocationAsync(location);
            return Ok(apartments);
        }

        [HttpPost]
        public async Task<IActionResult> AddAppartment(ApartmentModel model)
        {
            var apartment = await _apartmentService.CreateApartmentsAsync(model);
            return Ok(apartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppartment(Guid id, ApartmentModel model)
        {
            var updatedApartment = await _apartmentService.UpdateApartmentsAsync(id,model);
            return Ok(updatedApartment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppartmentById(Guid id)
        {
            var status = _apartmentService.DeleteApartmentsAsync(id);
            return Ok(status);
        }
    }
}
