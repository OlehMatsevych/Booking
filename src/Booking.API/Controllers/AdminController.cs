using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            _adminService.ApproveRequest(request);
            return Ok();
        }
        [HttpPost]
        [Route("BlockUser")]
        public IActionResult BlockUser(UserModel user)
        {
            _adminService.BlockUser(user);
            return Ok();
        }
    }
}
