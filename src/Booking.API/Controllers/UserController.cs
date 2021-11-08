using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("AddReservation")]
        public IActionResult AddReservation(ReservationModel model)
        {
            _userService.AddReservation(model);
            return Ok();
        }
        [HttpDelete]
        [Route("CancelReservation")]
        public IActionResult CancelReservation(ReservationModel model)
        {
            _userService.CancelReservation(model.Id);
            return Ok();
        }
        [HttpDelete]
        [Route("SubscribeForNews")]
        public IActionResult SubscribeForNews(ReservationModel model)
        {
            //_userService.CancelReservation(model.Id);
            return Ok();
        }
    }
}
