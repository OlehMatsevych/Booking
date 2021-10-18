using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task CreateAsync(UserModel user)
        {
            await _accountService.CreateAsync(user);
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserModel user)
        {
            var token = await _accountService.LoginAsync(user);
            return Ok(token);
        }

    }
}
