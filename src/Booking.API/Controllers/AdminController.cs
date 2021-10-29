using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPut]
        [Route("ApproveRequest")]
        public IActionResult ApproveRequest(ApartmentRequestModel request)
        {
            try
            {
                _adminService.ApproveRequest(request);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        [Route("BlockUser")]
        public IActionResult BlockUser(UserModel user)
        {
            try 
            { 
                _adminService.BlockUser(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
