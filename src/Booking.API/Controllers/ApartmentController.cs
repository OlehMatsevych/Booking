using Booking.Application.Models.Apartment;
using Booking.Application.Services.Apartment;
using Booking.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Route("api/Apartments")]
    [ApiController]
    [Authorize]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet]
        [Route("ApartmentsList")]
        public IActionResult GetApartments()
        {
            try 
            { 
                var apartments =  _apartmentService.GetApartments();
                return Ok(apartments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{Location}")]
        public IActionResult GetApartmentsByLocation(Location location)
        {
            try
            { 
                var apartments = _apartmentService.GetApartmentsByLocationAsync(location);
                return Ok(apartments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAppartment(ApartmentModel model)
        {
            try
            { 
                var apartment = await _apartmentService.CreateApartmentsAsync(model);
                return Ok(apartment);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppartment(Guid id, ApartmentModel model)
        {
            try
            {
                var updatedApartment = _apartmentService.UpdateApartmentsAsync(id, model);
                return Ok(updatedApartment);
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppartmentById(Guid id)
        {
            try
            {
                var status = _apartmentService.DeleteApartmentsAsync(id);
                return Ok(status);
            }
            catch (Exception)
            {
                return BadRequest(); 
            }
        }
    }
}
