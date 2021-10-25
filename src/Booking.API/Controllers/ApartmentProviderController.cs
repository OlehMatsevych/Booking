using Microsoft.AspNetCore.Http;
using Booking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Application.Models;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPost]
        [Route("GetAllProviders")]
        public IActionResult GetAllProviders()
        {
            var providers = _providerService.GetAllProviders();
            return Ok(providers);
        }
    }
}
