using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApartmentProviderController : ControllerBase
    {
        private readonly IApartmentProviderService _providerService;
        public ApartmentProviderController(IApartmentProviderService providerService)
        {
            _providerService = providerService;
        }
        [HttpPost]
        [Route("CreateRequest")]
        public IActionResult CreateRequest(ApartmentRequestModel request)
        {
            _providerService.CreateRequest(request);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllProviders")]
        public IActionResult GetAllRequests()
        {
            var providers = _providerService.GetAllRequests();
            return Ok(providers);
        }
    }
}
