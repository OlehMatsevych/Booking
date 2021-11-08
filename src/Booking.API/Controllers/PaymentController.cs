using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using LiqPay.SDK.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost("Create")]
        public async Task<LiqPayResponse> PayAsync(PaymentModel payment)
        {
            return await _paymentService.PayAsync(payment);
        }

    }
}
